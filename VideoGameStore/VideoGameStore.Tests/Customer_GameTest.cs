/* Filename: Customer_GameTest.cs
 * Description: This class is responsible for unit testing for the Customer_Game class.
 * 
 * Revision History:
 *      Greg Shalay 2016-10-27: Created constructor and field tests. 
 *      Ryan Pease 2016-11-01: Updated formatting and method names. 

*/

using System;
using NUnit.Framework;
using VideoGameStore.Models;

namespace VideoGameStore.Tests
{
    [TestFixture]
    public class Customer_GameTest
    {
        [Test]
        // This test is responsible for checking the customer_id field
        public void Customer_GameTest_ConstructorWithNoValues_ShouldPass()
        {
            // Arrange
            // Act
            Customer_Game customerGame = new Customer_Game();

            // Assert
            Assert.IsNotNull(customerGame);
        }

        [Test]
        // This test is responsible for checking the customer_game_id field
        public void Customer_GameTest_CustomerGameIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer_Game customerGame = new Customer_Game();
            int expected = 464;
            int actual;

            // Act
            customerGame.customer_game_id = expected;

            // Assert
            actual = customerGame.customer_game_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the customer_id field
        public void Customer_GameTest_CustomerIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer_Game customerGame = new Customer_Game();
            int expected = 344;
            int actual;

            // Act
            customerGame.customer_id = expected;

            // Assert
            actual = customerGame.customer_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the game_id field
        public void Customer_GameTest_GameIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer_Game customerGame = new Customer_Game();
            int expected = 43;
            int actual;

            // Act
            customerGame.game_id = expected;

            // Assert
            actual = customerGame.game_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the date_purchased field
        public void Customer_GameTest_DatePurchasedWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer_Game customerGame = new Customer_Game();
            DateTime expected = new DateTime(2000, 1, 1);
            DateTime actual = new DateTime();

            // Act
            customerGame.date_purchased = expected;
            
            // Assert
            actual = customerGame.date_purchased;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the rating field
        public void Customer_GameTest_RatingWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer_Game customerGame = new Customer_Game();
            int expected = 43;
            int? actual;

            // Act
            customerGame.rating = expected;

            // Assert
            actual = customerGame.rating;
            Assert.AreEqual(expected, actual);
        }
    }
}
