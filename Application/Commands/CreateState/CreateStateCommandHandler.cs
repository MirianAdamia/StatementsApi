using Application.Queries;
using Domain.Entities;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.CreateState
{
    public class CreateStateCommandHandler : IRequestHandler<CreateStateCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateStateCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateStateCommand request, CancellationToken cancellationToken)
        {
            byte[] fileBytes;

            using (var memoryStream = new MemoryStream())
            {
                request.Image.CopyTo(memoryStream);
                fileBytes = memoryStream.ToArray();
            }
            string base64String = Convert.ToBase64String(fileBytes);


            var state = new States()
            {
                Title = request.Title,
                Mobile = request.Mobile,
                Descripion = request.Descripion,
                Image = base64String,
                ImageContentType = request.Image.ContentType
            };

            await _context.States.AddAsync(state);
            await _context.SaveChangesAsync(cancellationToken);


            return state.Id;
        }
    }
}
