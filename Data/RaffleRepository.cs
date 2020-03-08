using System.Collections.Generic;
using System.Linq;
using RaffleDrawing.Api.GraphQL;
using RaffleDrawing.Data;
using RaffleDrawing.Models;

namespace RaffleDrawing.Api.Repositories
{
    public class RaffleRepository
    {
        private readonly RaffleContext _raffleContext;
        public RaffleRepository(RaffleContext raffleContext)
        {
            _raffleContext = raffleContext;
        }

        public IEnumerable<Donation> GetDonations(DonationArguments donationArgs)
        {
                        
            return _raffleContext.Donations.Where(donation => (donationArgs.name == null || donation.Name == donationArgs.name) 
                                                           && (donationArgs.email == null || donation.Name == donationArgs.name) 
                                                           && (donationArgs.amountMin == 0 || donation.Amount >= donationArgs.amountMin) 
                                                           && (donationArgs.amountMax == 0 || donation.Amount <= donationArgs.amountMax) 
                                                           && (donationArgs.eventID == 0 || donation.Event == donationArgs.eventID) 
                                                           );
        }

        public IEnumerable<Event> GetEvents()
        {
            return _raffleContext.Events;
        }

        public IEnumerable<Winner> GetWinners()
        {
            return _raffleContext.Winners;
        }
    }
}
