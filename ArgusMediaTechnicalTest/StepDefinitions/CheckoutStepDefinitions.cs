using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace ArgusMedisTechnicalTest.StepDefinitions
{
    [Binding]
    public class CheckoutStepDefinitions
    {
        #region Properties
        private OrderDetails orderDetails;
        #endregion

        #region Constructor
        public CheckoutStepDefinitions(OrderDetails orderDetails)
        {
            this.orderDetails = orderDetails;
        }
        #endregion

        [Given(@"A group of Two people orders '([^']*)' starters, '([^']*)' mains and '([^']*)' drinks '([^']*)' 1900")]
        [Given(@"A group of Four people orders '([^']*)' starters, '([^']*)' mains and '([^']*)' drinks '([^']*)' 1900")]
        public void GivenAGroupOfFourPeopleOrdersStartersMainsAndDrinks(int startersCount, int mainsCount, int drinksCount, string conditionType)
        {
            this.orderDetails.TakeOrder(startersCount, mainsCount, drinksCount, conditionType);
        }

        [Given(@"A group of Four people orders '([^']*)' starters, '([^']*)' mains and '([^']*)' drinks")]
        [When(@"One person cancels their order, the updated order is now '([^']*)' starters, '([^']*)' mains and '([^']*)' drinks")]
        public void GivenAGroupOfFourPeopleOrdersStartersMainsAndDrinks(int startersCount, int mainsCount, int drinksCount)
        {
            this.orderDetails.PlaceOrder(startersCount, mainsCount, drinksCount);
        }

        [When(@"are joined by Two people orders '([^']*)' starters, '([^']*)' mains and '([^']*)' drinks '([^']*)' 2000")]
        public void WhenAreJoinedByTwoPeopleOrdersStartersMainsAndDrinks(int startersCount, int mainsCount, int drinksCount, string conditionType)
        {
            this.orderDetails.AddOrder(startersCount, mainsCount, drinksCount, conditionType);
        }

        [Given(@"the order is sent to the endpoint the total is calculated")]
        [When(@"the order is sent to the endpoint the total is calculated")]
        public void WhenTheOrderIsSentToTheEndpointTheTotalIsCalculated()
        {
            this.orderDetails.CalculateFinalBill();
        }

        [Then(@"the final  bill should be £'([^']*)'")]
        public void ThenTheFinalBillShouldBe(double expectedResults)
        {
            Console.WriteLine(expectedResults);
            Assert.AreEqual(expectedResults, this.orderDetails.FinalBill);
        }

    }
}
