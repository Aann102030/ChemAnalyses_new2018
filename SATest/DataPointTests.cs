﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Calibration;
using System;
using System.Reflection;

namespace SATest
{
    [TestClass]
    public class DataPointTests
    {
        [TestMethod, Owner("ZVV 60325-2")]
        public void SimplePositiveConcentration()
        {
            // Arrange
            DataPoint dp1 = Mock.Of<DataPoint>(d => d.Concentration == 1);
            //Check
            Assert.AreEqual(1, dp1.Concentration);
        }

        [TestMethod, Owner("ZVV 60325-2")]
        public void SimpleNegativeConcentration()
        {
            // Arrange
            Action ac = () => Mock.Of<DataPoint>(d => d.Concentration == 0);
            //Check if an exception is thrown
            Assert.ThrowsException<TargetInvocationException>(ac);

            Exception except = null;
            try
            {
                DataPoint dp1 = Mock.Of<DataPoint>(d => d.Concentration == 0);
            }
            catch (Exception ex)
            {
                except = ex;
            }
            //Check the real type of the inner exception
            Assert.IsInstanceOfType(except.InnerException, typeof(ArgumentOutOfRangeException));
            // and its text
            Assert.IsTrue(String.Equals(except.InnerException.Message.Substring(0,
                except.InnerException.Message.IndexOf("\r\n")),
                "Концентрация должна быть положительным числом!"));
            
        }

        [TestMethod, Owner("ZVV 60325-2")]
        public void SimplePositiveValue()
        {
            // Arrange
            DataPoint dp1 = Mock.Of<DataPoint>(d => d.Value == 1);
            //Check
            Assert.AreEqual(1, dp1.Value);
        }

        [TestMethod, Owner("ZVV 60325-2")]
        public void SimpleNegativeValue()
        {
            // Arrange
            Action ac = () => Mock.Of<DataPoint>(d => d.Value == 0);
            //Check if an exception is thrown
            Assert.ThrowsException<TargetInvocationException>(ac);

            // Arrange
            Exception except = null;
            try
            {
                DataPoint dp1 = Mock.Of<DataPoint>(d => d.Concentration == 0);
            }
            catch (Exception ex)
            {
                except = ex;
            }
            //Check the real type of the inner exception
            Assert.IsInstanceOfType(except.InnerException, typeof(ArgumentOutOfRangeException));
        }


        [TestMethod, Owner("ZVV 60325-2")]
        public void EqualsTest()
        {
            //Arrange
            decimal v = 1; 
            decimal c = 1;

            var dp1 = Mock.Of<DataPoint>(d => d.Concentration == c && d.Value == v);

            DataPoint dp2 = new DataPoint(c, v);
            Assert.IsTrue(dp2.Equals(dp1));
        }
    }
}