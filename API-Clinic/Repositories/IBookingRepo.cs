using API_Clinic.Models;

namespace API_Clinic.Repositories
{
    public interface IBookingRepo
    {
        void BookAppointment(Booking booking);
        List<Booking> GetAppointmentsByClinic(int clinicId);
        List<Booking> GetAppointmentsByPatient(int patientId);
        IEnumerable<Booking> GetAppointmentsByPatientName(string patientName);
    }
}