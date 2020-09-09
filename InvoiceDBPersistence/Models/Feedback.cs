using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDBPersistence.Models
{
    public class Feedback
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FeedbackComments { get; set; }
    }
}
