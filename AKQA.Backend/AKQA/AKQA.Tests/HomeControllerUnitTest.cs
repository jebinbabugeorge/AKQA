using System;
using AKQA.BusinessLayer;
using AKQA.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AKQA.Tests
{
    [TestClass]
    public class HomeControllerUnitTest
    {
        [TestMethod]
        public void ProcessRequest()
        {
            Person person = new Person();
            person.Name = "Jebin Babu George";
            person.Salary = 123.45;
            person.SalaryInWords = "";

            string expected = "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FOURTY-FIVE CENTS";

            ConvertNumberToWord ctnw = new ConvertNumberToWord();

            string actual = ctnw.GetSalaryInWords(person.Salary);

            Assert.AreEqual(expected, actual);
        }
    }
}
