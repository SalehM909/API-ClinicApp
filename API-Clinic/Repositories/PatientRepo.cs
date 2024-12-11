using API_Clinic.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Clinic.Repositories
{
    // PatientRepo class implements the IPatientRepo interface
    // It is responsible for interacting with the ApplicationDbContext to perform CRUD operations on the Patient data.
    public class PatientRepo : IPatientRepo
    {
        // ApplicationDbContext instance used to interact with the database
        private readonly ApplicationDbContext _context;

        // Constructor that accepts an ApplicationDbContext and initializes the _context field
        // This allows dependency injection of the database context into the repository
        public PatientRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        // Method to add a new Patient to the database
        public void AddPatient(Patient patient)
        {
            // Adds the given patient entity to the Patients DbSet in the context
            _context.Patients.Add(patient);

            // Saves the changes to the database
            _context.SaveChanges();
        }

        // Method to retrieve a Patient by their unique ID
        public Patient GetPatientById(int patientId)
        {
            // Finds a patient by their ID in the Patients DbSet
            // If no patient is found, it returns null
            return _context.Patients.Find(patientId);
        }

        // Method to retrieve all Patients from the database
        public IEnumerable<Patient> GetAllPatients()
        {
            // Retrieves all patients from the Patients DbSet
            return _context.Patients.ToList();
        }

    }

}
