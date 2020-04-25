using Setup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Setup.Model.SetupViewModels
{
    public class AccountIndexData
    {
        public IEnumerable<Account> Accounts { get; set; }
        public IEnumerable<Place> Places { get; set; }
    }
}
