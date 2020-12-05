using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.API.Error
{
    public class ErrorDto
    {
        public List<string> Errors { get; set; }
        public int Status { get; set; }

        public ErrorDto()
        {
            Errors = new List<string>();
        }
    }
}
