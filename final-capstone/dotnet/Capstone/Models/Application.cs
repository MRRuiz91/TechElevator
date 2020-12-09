using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Application
    {
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string PromptResponse { get; set; }
        public int Status { get; set; } = 1;


    }
}
