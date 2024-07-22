using CreditCardApplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardApps
{
    public class CreditCardEvaluator
    {
        private readonly IFrequentFLyerNumberValidator _frequentFLyerNumberValidator;
        private const int AutoReferrealMaxAge = 20;
        private const int HighIncomeThreshold = 100_000;
        private const int LowIncomeThreshold = 20_000;

        public CreditCardEvaluator(IFrequentFLyerNumberValidator frequentFLyerNumberValidator)
        {
            _frequentFLyerNumberValidator = frequentFLyerNumberValidator ?? throw new System.ArgumentNullException(nameof(frequentFLyerNumberValidator));
        }

        public CreditCardApplicationDecision Evaluate(CreditCardApplication application)
        {
            if(application.GrossAnnualIncome >= HighIncomeThreshold)
            {
                return CreditCardApplicationDecision.AutoAccepted;
            }

            var isValidFlyerNumber = _frequentFLyerNumberValidator.IsValid(application.FrequentFlyerNumber);

            if(!isValidFlyerNumber) 
            {
                return CreditCardApplicationDecision.ReferredToHuman;
            }

            if(application.Age <= AutoReferrealMaxAge) 
            {
                return CreditCardApplicationDecision.ReferredToHuman;
            }

            if(application.GrossAnnualIncome < LowIncomeThreshold)
            {
                return CreditCardApplicationDecision.AutoDeclined;
            }

            return CreditCardApplicationDecision.ReferredToHuman;
        }

    }
}
