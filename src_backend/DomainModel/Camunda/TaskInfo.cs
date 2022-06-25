using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Camunda
{
    public class TaskInfo
    {
        public string TID { get; set; }
        public string TaskKey { get; set; }
        public string TaskName { get; set; }
        public string QuestionAuthor { get; set; }
        public int QuestionId { get; set; }
        public string PID { get; set; }
        public DateTime StartTime { get; set; }
        public string Reviewer { get; set; }

    }
}
