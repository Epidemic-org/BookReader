using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.ViewModels
{
    public class ResultObjectVm
    {
        public int Id { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Extra { get; set; }
    }
}
