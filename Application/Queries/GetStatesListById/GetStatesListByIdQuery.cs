using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetStateListById
{
    public class GetStatesListByIdQuery : IRequest<States>
    {
        public int Id { get; set; }

        public GetStatesListByIdQuery(int id)
        {
            Id = id;
        }
    } 
}
