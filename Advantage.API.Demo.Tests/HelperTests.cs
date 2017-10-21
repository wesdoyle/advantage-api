using Advantage.API.Demo.Models;
using NUnit.Framework;
using System;

namespace Advantage.API.Demo.Tests
{
    [TestFixture]
    public class HelperTests
    {
        [Test]
        [TestCase(0, false)]
        [TestCase(1, false)]
        [TestCase(2, false)]
        [TestCase(14, true)]
        [TestCase(30, true)]
        [TestCase(100, true)]
        public void Orders_Are_Not_Complete_For_Span_Within_LeadTime(int days, bool result)
        {
            var placed = DateTime.Now.AddDays(-days);

            var order = new Order
            {
                Id = 1234,
                Customer = new Customer
                {
                    Id = 1,
                    Email = "testuser@example.com",
                    Name = "TestCustomer",
                    State = "DE"
                },
                Placed = DateTime.Now.AddDays(-days),
                Completed = Helpers.GetRandOrderCompleted(placed)
            };

            var completedHasResult = false;

            if(order.Completed != null)
            {
                completedHasResult = true;
            }

            Assert.AreEqual(completedHasResult, result);
        }
    }
}
