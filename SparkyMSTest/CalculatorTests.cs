﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyMSTest
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void AddNumber_InputTwoInts_GetCorrectAddition()
        {
            //Arrange
            Calculator calc = new Calculator();


            //Act
            int result = calc.AddNumbers(10, 20);


            //Assert
            Assert.AreEqual(30, result);
        }

        
    }
}
