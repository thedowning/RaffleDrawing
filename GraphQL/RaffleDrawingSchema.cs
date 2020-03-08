using GraphQL.Types;
using GraphQL;
using System;
using RaffleDrawing.Data;
using Microsoft.Extensions.DependencyInjection;
using RaffleDrawing.Api.Repositories;

namespace RaffleDrawing.Api.GraphQL
{
    public class RaffleDrawingSchema: Schema
    {
        public RaffleDrawingSchema(IServiceProvider provider) : base() => Query = new RaffleDrawingQuery(provider.GetRequiredService<RaffleRepository>());
    }
}