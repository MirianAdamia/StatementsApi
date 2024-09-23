using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class States : StateList
    {
        public string Mobile { get; set; }
        public string Descripion { get; set; }
    }

    public class StateList
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ImageContentType { get; set; }
        public string? Image { get; set; }
    }
}
