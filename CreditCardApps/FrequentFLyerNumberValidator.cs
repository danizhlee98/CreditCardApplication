using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardApps
{
    public class FrequentFLyerNumberValidator : IFrequentFLyerNumberValidator
    {
        public bool IsValid (string frequentFlyerNumber)
        {
            throw new NotImplementedException("Simulate this real dependency being hard to use");
        }

        public void IsValid (string frequentFlyerNumber, out bool IsValid)
        {
            throw new NotImplementedException("Simulate this real dependency being hard to use");
        }
    }
}
