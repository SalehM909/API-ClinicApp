using API_Clinic.Models;
using API_Clinic.Repositories;

namespace API_Clinic.Services
{
    // BookingService class implements the IBookingService interface
    // It acts as a service layer, interacting with the IBookingRepo (repository) to manage booking-related operations.
    public class BookingService : IBookingService
    {
        // IBookingRepo instance used to interact with the repository layer for booking operations
        private readonly IBookingRepo _bookingRepo;

        // Constructor that accepts an IBookingRepo and initializes the _bookingRepo field
        // This allows dependency injection of the booking repository into the service
        public BookingService(IBookingRepo bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        // Method to book an appointment by delegating the operation to the repository
        public void BookAppointment(Booking booking)
        {
            // Calls the synchronous BookAppointment method of the booking repository
            _bookingRepo.BookAppointment(booking);
        }

        // Method to retrieve all appointments for a specific clinic by delegating the operation to the repository
        public List<Booking> GetAppointmentsByClinic(int clinicId)
        {
            // Calls the synchronous GetAppointmentsByClinic method of the booking repository
            return _bookingRepo.GetAppointmentsByClinic(clinicId);
        }

        public IEnumerable<Booking> GetAppointmentsByPatientName(string patientName)
        {
            return _bookingRepo.GetAppointmentsByPatientName(patientName);
        }

        // Method to retrieve all appointments for a specific patient by delegating the operation to the repository
        public List<Booking> GetAppointmentsByPatient(int patientId)
        {
            // Calls the synchronous GetAppointmentsByPatient method of the booking repository
            return _bookingRepo.GetAppointmentsByPatient(patientId);
        }
    }
}
