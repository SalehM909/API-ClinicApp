using API_Clinic.Models;
using API_Clinic.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Clinic.Controllers
{
    // BookingController class handles HTTP requests related to booking appointments
    // It interacts with the IBookingService to manage booking operations.
    [Route("api/bookings")]
    [ApiController] // Specifies that this class is an API controller, which automatically handles model validation and response formatting.
    public class BookingController : ControllerBase
    {
        // IBookingService instance used to interact with the service layer for booking operations
        private readonly IBookingService _bookingService;

        // Constructor that accepts an IBookingService and initializes the _bookingService field
        // This allows dependency injection of the booking service into the controller
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // Endpoint to book an appointment by accepting a Booking object in the request body
        [HttpPost("book")]
        public IActionResult BookAppointment(int patientID, int clinicID, DateTime date, int slotNumber)
        {
            var booking = new Booking
            {
                PatientID = patientID,
                ClinicID = clinicID,
                Date = date,
                SlotNumber = slotNumber
            };

            // Calling the service method synchronously
            _bookingService.BookAppointment(booking);

            // Returns a 200 OK response when the appointment is successfully booked
            return Ok();
        }

        // Endpoint to retrieve all appointments for a specific clinic by clinic ID
        [HttpGet("appointmentsByClinic/{clinicId}")]
        public ActionResult<IEnumerable<Booking>> GetAppointmentsByClinic(int clinicId)
        {
            // Retrieves appointments for the given clinic ID from the booking service
            var appointments = _bookingService.GetAppointmentsByClinic(clinicId); // Calling synchronously

            // Returns the appointments as a 200 OK response
            return Ok(appointments);
        }

        // Endpoint to retrieve all appointments for a specific patient by patient name
        [HttpGet("appointmentsByPatientName/{patientName}")]
        public ActionResult<IEnumerable<Booking>> GetAppointmentsByPatientName(string patientName)
        {
            // Retrieves appointments for the given patient name from the booking service
            var appointments = _bookingService.GetAppointmentsByPatientName(patientName);
            if (appointments == null || !appointments.Any())
            {
                return NotFound();
            }
            return Ok(appointments);
        }

        // Endpoint to retrieve all appointments for a specific patient by patient ID
        [HttpGet("appointmentsByPatient/{patientId}")]
        public ActionResult<IEnumerable<Booking>> GetAppointmentsByPatient(int patientId)
        {
            // Retrieves appointments for the given patient ID from the booking service
            var appointments = _bookingService.GetAppointmentsByPatient(patientId); // Calling synchronously

            // Returns the appointments as a 200 OK response
            return Ok(appointments);
        }
    }
}
