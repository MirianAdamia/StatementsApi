using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UpdateState
{
    public class UpdateStateCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Descripion { get; set; }
        public string? Mobile { get; set; }
        public IFormFile? Image { get; set; }
    }
}
