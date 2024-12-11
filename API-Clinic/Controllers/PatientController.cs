using API_Clinic.Models;
using API_Clinic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicWebApp.Controllers
{
    // PatientController class handles HTTP requests related to patient operations
    // It interacts with the IPatientService to manage patient data.
    [Route("api/patients")]
    [ApiController] // Specifies that this class is an API controller, which automatically handles model validation and response formatting.
    public class PatientController : ControllerBase
    {
        // IPatientService instance used to interact with the service layer for patient operations
        private readonly IPatientService _patientService;

        // Constructor that accepts an IPatientService and initializes the _patientService field
        // This allows dependency injection of the patient service into the controller
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // Endpoint to add a new patient by accepting a Patient object in the request body
        [HttpPost("add")]
        public IActionResult AddPatient(string name, int age, string gender)
        {
            var patient = new Patient
            {
                Name = name,
                Age = age,
                Gender = gender
            };

            // Calls the AddPatient method of the patient service to add the patient
            _patientService.AddPatient(patient);

            // Returns a Created response indicating that the resource was successfully created
            return CreatedAtAction(nameof(GetPatient), new { patientId = patient.PID }, patient);
        }

        // Endpoint to retrieve a patient by their unique ID
        [HttpGet("{patientId}")]
        public ActionResult<Patient> GetPatient(int patientId)
        {
            // Retrieves the patient by ID from the patient service
            var patient = _patientService.GetPatientById(patientId);

            if (patient == null)
            {
                return NotFound(); // Returns a 404 if the patient is not found
            }

            // Returns the patient as a 200 OK response
            return Ok(patient);
        }

        // Endpoint to retrieve all patients
        [HttpGet]
        public ActionResult<IEnumerable<Patient>> GetAllPatients()
        {
            // Retrieves all patients from the patient service
            var patients = _patientService.GetAllPatients();

            // Returns the patients as a 200 OK response
            return Ok(patients);
        }
    }
}
