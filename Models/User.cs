namespace CartaoDeVacinaAPI.Models
{
    public class User
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty; //! Temporary solution

        public ICollection<VaccinationRecord> VaccinationRecords {get;set;} 
            = new List<VaccinationRecord>();
    }
}