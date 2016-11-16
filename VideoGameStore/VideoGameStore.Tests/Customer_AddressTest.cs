/* Filename: Customer_AddressTest.cs
 * Description: This class is responsible for unit testing for the Customer_Address class.
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
    public class Customer_AddressTest
    {       
        [Test]
        // This test is responsible for checking the constructor
        public void Customer_AddressTest_ConstructorWithNoValues_ShouldPass()
        {
            // Arrange
            // Act
            Customer_Address customerAddress = new Customer_Address();

            // Assert
            Assert.IsNotNull(customerAddress);
        }

        [Test]
        // This test is responsible for checking the customer_id field
        public void Customer_AddressTest_CustomerIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer_Address customerAddress = new Customer_Address();
            int expected = 10;
            int actual;

            // Act
            customerAddress.customer_id = expected;

            // Assert
            actual = customerAddress.customer_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the address_id field
        public void Customer_AddressTest_AddressIDWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer_Address customerAddress = new Customer_Address();
            int expected = 10;
            int actual;

            // Act
            customerAddress.address_id = expected;

            // Assert
            actual = customerAddress.address_id;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        // This test is responsible for checking the address_name field
        public void Customer_AddressTest_AddressNameWithCorrectType_ShouldPass()
        {
            // Arrange
            Customer_Address customerAddress = new Customer_Address();
            string expected = "23 Wilson Ave";
            string actual;

            // Act
            customerAddress.address_name = expected;

            // Assert
            actual = customerAddress.address_name;
            Assert.AreEqual(expected, actual);
        }
    }
}
