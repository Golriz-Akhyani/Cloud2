using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Setup.Data;
using Setup.Models;
using System;
using System.Linq;

namespace Setup.Model
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SetupContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SetupContext>>()))
            {
                if (context.Account.Any())
                {
                    return;
                }

                var accounts = new Account[]
                {
                                       new Account
                    {
                        FirstName = "Chloe",
                        LastName = "Yu",
                        CompanyName = "UBC",
                        Email = "c_yu@gmail.com",
                        Telephone = "778 898 7654",
                        Street = "2454 Grandvile",
                        City = "Vancouver",
                        Province = "BC",
                        ZipCode = "V8G 2P9",
                        UserName = "c.yu"
                    },

                    new Account
                    {
                        FirstName = "Sina",
                        LastName = "Kestkar",
                        CompanyName = "Microsoft",
                        Email = "s.k@gmailcom",
                        Telephone = "778 453 7654",
                        Street = "721 Grandvile",
                        City = "Vancouver",
                        Province = "BC",
                        ZipCode = "V8G 2P9",
                        UserName = "s.k"
                     },

                    new Account
                    {
                        FirstName = "John",
                        LastName = "Mcleen",
                        CompanyName = "HighTec",
                        Email = "John.Mcleen@gmail.com",
                        Telephone = "604 673 8374",
                        Street = "6787 Marine Dr.",
                        City = "Richmond",
                        Province = "BC",
                        ZipCode = "H3F 3T5",
                        UserName = "John.Mcleen"
                     }
                };

                context.Account.AddRange(accounts);
                context.SaveChanges();

                var places = new Place[]
                {
                    new Place
                    {
                        PlaceName="Starbucks",
                        License="A0147211",
                        Address="Georgia Street",
                        Wifi=true,
                        Whiteboard=false,
                        Washroom=true,
                        Description="NA"
                    },
                    new Place
                    {
                        PlaceName="Tim Horton",
                        License="A0147212",
                        Address="Easert Street",
                        Wifi=true,
                        Whiteboard=true,
                        Washroom=true,
                        Description="NA"
                    },
                    new Place
                    {
                        PlaceName="Bal Cafe",
                        License="A0147213",
                        Address="Keuber Street",
                        Wifi=true,
                        Whiteboard=false,
                        Washroom=false,
                        Description="NA"
                    },
                    new Place
                    {
                        PlaceName="Parallel 49 ",
                        License="A0147214",
                        Address="Win Street",
                        Wifi=true,
                        Whiteboard=true,
                        Washroom=true,
                        Description="NA" }
                };
                foreach (Place p in places)
                {
                    context.Place.Add(p);
                }
                context.SaveChanges();

                var placeAccount = new PlaceAssign[]
            {
                new PlaceAssign {
                    AccountID = accounts.Single (c => c.UserName == "c.yu" ).AccountID,
                    PlaceID = places.Single (i => i.PlaceName == "Tim Horton").PlaceID
                    },
               
                new PlaceAssign {
                    AccountID = accounts.Single (c => c.UserName == "s.k" ).AccountID,
                    PlaceID = places.Single (i => i.PlaceName == "Bal Cafe").PlaceID
                    },
              
                new PlaceAssign {
                    AccountID = accounts.Single (c => c.UserName == "John.Mcleen" ).AccountID,
                    PlaceID = places.Single (i => i.PlaceName == "Starbucks").PlaceID
                    }

            };

                foreach (PlaceAssign ci in placeAccount)
                {
                    context.PlaceAssign.Add(ci);
                }
                context.SaveChanges();

            }
        }
    }
}