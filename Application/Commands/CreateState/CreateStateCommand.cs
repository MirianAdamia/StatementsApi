using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.CreateState
{
    public class CreateStateCommand : IRequest<int>
    {
        public string? Title { get; set; }
        public string? Descripion { get; set; }
        public string? Mobile { get; set; }
        public IFormFile Image { get; set; }
    }
}
