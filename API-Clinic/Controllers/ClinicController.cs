using API_Clinic.Models;
using API_Clinic.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Clinic.Controllers
{
    // ClinicController class handles HTTP requests related to clinic operations
    // It interacts with the IClinicService to manage clinic data.
    [Route("api/clinics")]
    [ApiController] // Specifies that this class is an API controller, which automatically handles model validation and response formatting.
    public class ClinicController : ControllerBase
    {
        // IClinicService instance used to interact with the service layer for clinic operations
        private readonly IClinicService _clinicService;

        // Constructor that accepts an IClinicService and initializes the _clinicService field
        // This allows dependency injection of the clinic service into the controller
        public ClinicController(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }

        // Endpoint to add a new clinic by accepting a Clinic object in the request body
        [HttpPost("add")]
        public IActionResult AddClinic(string Specialization, int NumOfSlots)
        {
            var clinic = new Clinic
            {
                Specialization = Specialization,
                NumberOfSlots = NumOfSlots
            };

            // Calling the synchronous AddClinic method of the clinic service
            _clinicService.AddClinic(clinic);

            // Returns a Created response indicating that the resource was successfully created
            return CreatedAtAction(nameof(GetClinic), new { clinicId = clinic.CID }, clinic);
        }

        // Endpoint to retrieve a clinic by its unique ID
        [HttpGet("{clinicId}")]
        public ActionResult<Clinic> GetClinic(int clinicId)
        {
            // Retrieves the clinic by ID from the clinic service
            var clinic = _clinicService.GetClinicById(clinicId);

            if (clinic == null)
            {
                return NotFound(); // Returns a 404 if the clinic is not found
            }

            // Returns the clinic as a 200 OK response
            return Ok(clinic);
        }

        // Endpoint to retrieve all clinics
        [HttpGet]
        public ActionResult<IEnumerable<Clinic>> GetAllClinics()
        {
            // Retrieves all clinics from the clinic service
            var clinics = _clinicService.GetAllClinics();

            // Returns the clinics as a 200 OK response
            return Ok(clinics);
        }
    }

}
