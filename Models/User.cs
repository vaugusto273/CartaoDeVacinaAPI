namespace CartaoDeVacinaAPI.Models
{
    public class User
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty; //! Temporary solution

        public int Age {get; set;}
        public string Gender {get; set;} = string.Empty;

        public ICollection<VaccinationRecord> VaccinationRecords {get;set;} 
            = new List<VaccinationRecord>();
    }
}