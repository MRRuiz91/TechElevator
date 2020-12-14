using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Application
    {
        public int? ApplicationId { get; set; }
        public string Username { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
        public string PromptResponse { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Status { get; set; } = 1;


    }
    public class MiniApp
    {
        public int? ApplicationId { get; set; }
        public int Status { get; set; }
        public string Username { get; set; }
    }
}
