using API_Clinic.Models;

namespace API_Clinic.Services
{
    public interface IBookingService
    {
        void BookAppointment(Booking booking);
        List<Booking> GetAppointmentsByClinic(int clinicId);
        IEnumerable<Booking> GetAppointmentsByPatientName(string patientName);
        List<Booking> GetAppointmentsByPatient(int patientId);
    }
}