

namespace Domain
{
    public class AppUser
    {
        public string userName { get; set; }
        public string Oib { get; set; }
        public string Name { get; set; }
        public string surname { get; set; }

        public Boolean smoker { get; set; }

        public string birthday { get; set; }
        public Boolean gender { get; set; }
        
        public Boolean isDisable { get; set; }
        = false;
      
    }
}
