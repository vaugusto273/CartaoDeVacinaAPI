using System.Text.Json.Serialization;

namespace CartaoDeVacinaAPI.Models
{
    public class VaccinationRecord
    {
        public int Id { get; set; }

        // FK For user
        public int UserID { get; set; }

        [JsonIgnore]
        public User? User { get; set; }

        // FK For Vaccines
        public int VaccineID { get; set; }

        [JsonIgnore]
        public Vaccine? Vaccine { get; set; }

        public int DoseNumber { get; set; }

        public DateTime ApplicationDate { get; set; }

        public string? Notes { get; set; }
    }
}
