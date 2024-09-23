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

namespace Application.Commands.UpdateState
{
    public class UpdateStateCommandHandler : IRequestHandler<UpdateStateCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public UpdateStateCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateStateCommand request, CancellationToken cancellationToken)
        {
            var state = await _context.States.FindAsync(request.Id);
            if (state == null)
                return -1;

            byte[] fileBytes = new byte[0];

            if (request.Image != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    request.Image.CopyTo(memoryStream);
                    fileBytes = memoryStream.ToArray();
                }
            }

            string base64String = Convert.ToBase64String(fileBytes);

            state.Title = request.Title ?? state.Title;
            state.Mobile = request.Mobile ?? state.Mobile;
            state.Descripion = request.Descripion ?? state.Descripion;
            state.Image = request.Image == null ? state.Image : base64String;
            state.ImageContentType = request.Image == null ? state.ImageContentType : request.Image?.ContentType;

            _context.Entry(state).State = EntityState.Modified;

            await _context.SaveChangesAsync(cancellationToken);

            return state.Id;
        }
    }
}
