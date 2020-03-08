
using System.Collections.Generic;
using GraphQL.Types;
using RaffleDrawing.Api.GraphQL.Types;
using RaffleDrawing.Api.Repositories;
using RaffleDrawing.Data;
using RaffleDrawing.Models;
namespace RaffleDrawing.Api.GraphQL
{
    public struct DonationArguments{
     public string name;
     public string email;
     public int? amountMin;
     public int? amountMax;
     public int? eventID;

       
    }
    public class RaffleDrawingQuery: ObjectGraphType
    {
         public RaffleDrawingQuery(RaffleRepository raffleRepository)
        {
            Field<ListGraphType<DonationType>>(
                    "donations",
                arguments: new QueryArguments(new QueryArgument<StringGraphType>(){Name="name"}, 
                                              new QueryArgument<StringGraphType>(){Name="email"}, 
                                              new QueryArgument<IntGraphType>(){Name="amountMin"},
                                              new QueryArgument<IntGraphType>(){Name="amountMax"}, 
                                              new QueryArgument<IntGraphType>(){Name="event"}
                                              ), 
                resolve: context => {
                    DonationArguments donationArgs = new DonationArguments { name = context.GetArgument<string>("name"), 
                                                                             email=context.GetArgument<string>("email"), 
                                                                             amountMin = context.GetArgument<int>("amountMin"), 
                                                                             amountMax = context.GetArgument<int>("amountMax"), 
                                                                             eventID = context.GetArgument<int>("event")
                                                                           };
                    IEnumerable<Donation> results;
                        results = raffleRepository.GetDonations(donationArgs);
              
                    return results;
                }
            );  
            Field<ListGraphType<EventType>>(
                    "events", 
                    resolve: context => raffleRepository.GetEvents()
            ); 
            Field<ListGraphType<WinnerType>>(
                    "winners", 
                    resolve: context => raffleRepository.GetWinners()
            );   
        }
    }
}