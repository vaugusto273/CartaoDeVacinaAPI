namespace CartaoDeVacinaAPI.Models
{
    public class Vaccine
    {
        public int Id { get; set; }
        public string VaccineName { get; set; } = string.Empty; //! Temporary solution

        public ICollection<VaccinationRecord> VaccinationRecords {get;set;} 
            = new List<VaccinationRecord>();
    }
}