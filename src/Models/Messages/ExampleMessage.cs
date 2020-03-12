using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svnTrack.Models.Messages
{
    public class ExampleMessage
    {
        public ExampleMessage(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
