using System;
using GraphQL.Types;
using RaffleDrawing.Models;
namespace RaffleDrawing.Api.GraphQL.Types
{
    public class WinnerType: ObjectGraphType<Winner>
    {
         public WinnerType()
        {
            Field(t=> t.ID);
            Field(t=> t.Name);
            Field(t=> t.Email);
            Field(t=> t.Prize);
            Field(t=> t.Event);

        }
    }

}