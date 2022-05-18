using MediatR;

namespace DomainServices.Period
{
    public class Commands
    {
        public  record DeletePeriod(int IdPeriod ):IRequest;
        public class CreatePeriod: IRequest<int>
        {
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public int IdPeriod { get; set; }
        }
        public class UpdatePeriod : IRequest
        {
            public DateTime StartDate { get; set; }  
          
            public DateTime EndDate { get; set; }   
            public int PeriodId { get; set; }   


        }
    }
}

