using Domain.Entities;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetStateListById
{
	public class GetStatesListByIdQueryHandler : IRequestHandler<GetStatesListByIdQuery,States>
	{
        private readonly ApplicationDbContext _context;
        public GetStatesListByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<States> Handle(GetStatesListByIdQuery request, CancellationToken cancellationToken)
		{

            var state = await _context.States
                .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

            return state;
        }
	}
}
