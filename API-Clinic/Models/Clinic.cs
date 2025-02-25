﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_Clinic.Models
{
    public class Clinic
    {
        [Key]
       
        public int CID { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Range (1, 20)]
        public int NumberOfSlots { get; set; }

        [JsonIgnore]
        public ICollection<Booking> Bookings { get; set; }
    }
}
