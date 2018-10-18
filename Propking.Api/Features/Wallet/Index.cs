using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Propking.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Propking.Api.Features.Position
{
    public class Index
    {
        public class Query: IRequest<Model>
        {

        }

        public class Model
        {
            public List<Fii> Fiis { get; set; }

            public class Fii
            {
                public int Id { get; set; }
                public string Code { get; set; }
                public int Quantity { get; set; }
            }
        }

        public class Handler : IRequestHandler<Query, Model>
        {
            private readonly SystemContext _dbContext;

            public Handler(SystemContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Model> Handle(Query request, CancellationToken cancellationToken)
            {
                var wallet = await _dbContext.Positions
                    .Include(x => x.Fii)
                    .OrderBy(x => x.Fii.Code)
                    .Select(x => new Model.Fii()
                    {
                        Code = x.Fii.Code,
                        Id = x.Id,
                        Quantity = x.CalculateSummary().Quantity
                    })
                    .ToListAsync();

                return new Model { Fiis = wallet };
            }
        }
    }
}
