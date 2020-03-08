using System;
using GraphQL.Types;
using RaffleDrawing.Models;
namespace RaffleDrawing.Api.GraphQL.Types
{
    public class EventType: ObjectGraphType<Event>
    {
         public EventType()
        {
            Field(t=> t.ID);
            Field(t=> t.Name);
        }
    }

}