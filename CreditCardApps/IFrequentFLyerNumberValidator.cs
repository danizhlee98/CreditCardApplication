using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardApps
{
    public interface IFrequentFLyerNumberValidator
    {
        bool IsValid (string frequentFLyerNumber);

        void IsValid (string frequentFLyerNumber, out bool isValid);
    }
}
