using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Camunda
{
    public class ReviewInfo
    {
        public string Author { get; set; }
        public int QuestionId { get; set; }
        public string PID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool Ended { get; set; }
        public bool CanApplyForReview { get; set; }
        public string Reviewer { get; set; }

    }
}
