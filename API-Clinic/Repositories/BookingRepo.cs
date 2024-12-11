using API_Clinic.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Clinic.Repositories
{
    // BookingRepo class implements the IBookingRepo interface
    // It is responsible for interacting with the ApplicationDbContext to perform CRUD operations on the Booking data.
    public class BookingRepo : IBookingRepo
    {
        // ApplicationDbContext instance used to interact with the database
        private readonly ApplicationDbContext _context;

        // Constructor that accepts an ApplicationDbContext and initializes the _context field
        // This allows dependency injection of the database context into the repository
        public BookingRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        // Method to book an appointment by adding a new Booking to the database
        public void BookAppointment(Booking booking)
        {
            // Ensure that the number of available slots in the associated clinic is not exceeded
            var clinic = _context.Clinics.Find(booking.ClinicID);

            // If the clinic exists and has available slots, proceed to book the appointment
            if (clinic != null && clinic.NumberOfSlots > 0)
            {
                // Adds the booking entity to the Bookings DbSet
                _context.Bookings.Add(booking);

                // Decreases the available slots in the clinic by one
                clinic.NumberOfSlots--;

                // Saves the changes to the database
                _context.SaveChanges();
            }
        }

        // Method to retrieve all appointments (bookings) for a specific clinic
        public List<Booking> GetAppointmentsByClinic(int clinicId)
        {
            // Retrieves all bookings for the given clinic ID, including the associated patient information
            return _context.Bookings
                .Where(b => b.ClinicID == clinicId) // Filters by clinic ID
                .Include(b => b.Patient)            // Includes the related Patient data
                .ToList();                          // Converts the result to a list synchronously
        }

        public IEnumerable<Booking> GetAppointmentsByPatientName(string patientName)
        {
            return _context.Bookings
                .Where(b => b.Patient.Name.ToLower() == patientName.ToLower())
                .Include(b => b.Patient)  // Include the related patient data
                .ToList();
        }


        // Method to retrieve all appointments (bookings) for a specific patient
        public List<Booking> GetAppointmentsByPatient(int patientId)
        {
            // Retrieves all bookings for the given patient ID, including the associated clinic information
            return _context.Bookings
                .Where(b => b.PatientID == patientId) // Filters by patient ID
                .Include(b => b.Clinic)               // Includes the related Clinic data
                .ToList();                            // Converts the result to a list synchronously
        }
    }
}
