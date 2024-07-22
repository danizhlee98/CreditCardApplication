using CreditCardApplications;
using Xunit;
using Moq;

namespace CreditCardApps.Tests
{
    public class CreditCardEvaluation
    {
        [Fact]
        public void AcceptHighIncomeApplication()
        {
            var mockValidator = new Mock<IFrequentFLyerNumberValidator>();

            var sut = new CreditCardEvaluator(mockValidator.Object);

            var application = new CreditCardApplication { GrossAnnualIncome = 1_000 };

            CreditCardApplicationDecision decision = sut.Evaluate(application);

            Assert.Equal(CreditCardApplicationDecision.AutoAccepted, decision);

        }

        [Fact]
        public void ReferYoungApplication()
        {
            Mock<IFrequentFLyerNumberValidator> mockValidator = new Mock<IFrequentFLyerNumberValidator>();

            var sut = new CreditCardEvaluator(mockValidator.Object);

            var application = new CreditCardApplication { Age = 19 };

            CreditCardApplicationDecision decision = sut.Evaluate(application);

            Assert.Equal(CreditCardApplicationDecision.ReferredToHuman, decision);
        }

        [Fact]
        public void DeclineLowApplication()
        {
            Mock<IFrequentFLyerNumberValidator> mockValidator = new Mock<IFrequentFLyerNumberValidator>();

            mockValidator.Setup(column => column.IsValid("x")).Returns(true);

            var sut = new CreditCardEvaluator(mockValidator.Object);

            var application = new CreditCardApplication
            {
                GrossAnnualIncome = 19_999,
                Age = 42,
                FrequentFlyerNumber = "x"
            };

            CreditCardApplicationDecision decision = sut.Evaluate(application);

            Assert.Equal(CreditCardApplicationDecision.AutoDeclined, decision);


        }
    }
}