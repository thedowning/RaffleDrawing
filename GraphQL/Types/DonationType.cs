using System;
using GraphQL.Types;
using RaffleDrawing.Models;
namespace RaffleDrawing.Api.GraphQL.Types
{
    public class DonationType: ObjectGraphType<Donation>
    {
         public DonationType()
        {
            Field(t=> t.ID);
            Field(t=> t.Name);
            Field(t=> t.Email);
            Field(t=> t.Datetime);
            Field(t=> t.Message);
            Field(t=> t.Amount);
            Field(t=> t.Event);
        }
    }

}