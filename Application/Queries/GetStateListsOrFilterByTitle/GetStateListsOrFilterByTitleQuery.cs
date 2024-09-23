using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetStateListsOrFilterByTitle
{
    public class GetStateListsOrFilterByTitleQuery : IRequest<IEnumerable<StateList>>
    {
        public string Title { get; set; }

        public GetStateListsOrFilterByTitleQuery(string title)
        {
            Title = title;
        }
    } 
}
