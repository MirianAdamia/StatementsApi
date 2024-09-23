using Domain.Entities;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetStateListsOrFilterByTitle
{
	public class GetStateListsOrFilterByTitleQueryHandler : IRequestHandler<GetStateListsOrFilterByTitleQuery,IEnumerable<StateList>>
	{
        private readonly ApplicationDbContext _context;
        public GetStateListsOrFilterByTitleQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StateList>> Handle(GetStateListsOrFilterByTitleQuery request, CancellationToken cancellationToken)
		{
            var states = await _context.States
                .Where(state => string.IsNullOrEmpty(request.Title) || state.Title.ToLower() == request.Title.ToLower())
                .Select(state => new StateList
                {
                    Id = state.Id,
                    Title = state.Title,
                    Image = state.Image,
                    ImageContentType = state.ImageContentType
                })
                .ToListAsync(cancellationToken);

            return states;
        }
	}
}
