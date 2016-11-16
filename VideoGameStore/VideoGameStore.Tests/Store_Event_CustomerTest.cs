/* Filename: Store_Event_CustomerTest.cs
 * Description: This class is responsible for unit testing for the Store_Event_Customer class.
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
    public class Store_Event_CustomerTest
    {
        [Test]
        // This test is responsible for checking the constructor
        public void Store_Event_CustomerTest_ConstructorWithNoValues_ShouldPass()
        {
            // Arrange
            // Act
            Store_Event_Customer sec = new Store_Event_Customer();

            // Assert
            Assert.IsNotNull(sec);
        }

        [Test]
        // This test is responsible for checking the store_event_customer_id field
        public void Store_Event_CustomerTest_StoreEventCustomerIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Store_Event_Customer sec = new Store_Event_Customer();
            int expected = 999;
            int actual;

            // Act
            sec.store_event_customer_id = expected;
            actual = sec.store_event_customer_id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the store_event_id field
        public void Store_Event_CustomerTest_StoreEventIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Store_Event_Customer sec = new Store_Event_Customer();
            int expected = 12;
            int actual;

            // Act
            sec.store_event_id = expected;
            actual = sec.store_event_id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the customer_id field
        public void Store_Event_CustomerTest_CustomerIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Store_Event_Customer sec = new Store_Event_Customer();
            int expected = 999;
            int actual;

            // Act
            sec.customer_id = expected;
            actual = sec.customer_id;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
