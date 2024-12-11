using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_Clinic.Models
{
    public class Patient
    {
        [Key]
        
        public int PID { get; set; }

        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        [JsonIgnore]
        public ICollection<Booking> Bookings { get; set; }
    }

}
