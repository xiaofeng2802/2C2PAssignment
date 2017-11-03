﻿using _2C2PAssignment.Business.Helper;
using _2C2PAssignment.Business.Validator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2C2PAssignment.Tests.Validators
{
    [TestFixture]
    public class VisaValidatorTest
    {
        [Test]
        [TestCase("1234567890123456")]
        [TestCase("2234567890123456")]
        [TestCase("3234567890123456")]
        [TestCase("0234567890123456")]
        public void Validate_GivenCardNumberDontStartWithFourWithValidDate_Should_ReturnUnknownCardTypeWithValidExpiryDate(string cardNumber)
        {
            //Arr
            VisaValidator visa = new VisaValidator();
            SystemDatetime.Now = () => new DateTime(2017, 11, 3);
            //Act
            var result = visa.Validate(cardNumber, new Business.Dtos.ExpiryDateData() { Month = 11, Year = 2017 });
            //Assert
            Assert.True(result != null);
            Assert.True(result.IsValid);
            Assert.True(result.Type == Business.Dtos.CardType.Unknown);
        }
    }
}