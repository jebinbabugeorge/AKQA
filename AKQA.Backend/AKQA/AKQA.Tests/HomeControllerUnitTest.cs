using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AKQA.BusinessLayer;
using AKQA.Controllers;
using AKQA.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AKQA.Tests
{
    [TestClass]
    public class HomeControllerUnitTest
    {
        private HomeController _controller;

        [TestInitialize]
        public void Init()
        {
            Mock<IConvertNumberToWord> ctnw = new Mock<IConvertNumberToWord>();
            ctnw.Setup(x => x.GetSalaryInWords(0));
            _controller = new HomeController(ctnw.Object);
            _controller.Request = new HttpRequestMessage();
            _controller.Configuration = new HttpConfiguration();

        }

        [TestMethod]
        public void ShouldProcessBaseRequest()
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

        [TestMethod]
        public void ShouldProcessZeroRequest()
        {
            Person person = new Person();
            person.Name = "Jebin Babu George";
            person.Salary = 0;
            person.SalaryInWords = "";

            string expected = "ZERO DOLLARS";

            ConvertNumberToWord ctnw = new ConvertNumberToWord();

            string actual = ctnw.GetSalaryInWords(person.Salary);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldProcessRequestWithoutDecimal()
        {
            Person person = new Person();
            person.Name = "Jebin Babu George";
            person.Salary = 123;
            person.SalaryInWords = "";

            string expected = "ONE HUNDRED AND TWENTY-THREE DOLLARS";

            ConvertNumberToWord ctnw = new ConvertNumberToWord();

            string actual = ctnw.GetSalaryInWords(person.Salary);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldProcessRequestInMillions()
        {
            Person person = new Person();
            person.Name = "Jebin Babu George";
            person.Salary = 1231231;
            person.SalaryInWords = "";

            string expected = "ONE MILLION TWO HUNDRED AND THIRTY-ONE THOUSAND TWO HUNDRED AND THIRTY-ONE DOLLARS";

            ConvertNumberToWord ctnw = new ConvertNumberToWord();

            string actual = ctnw.GetSalaryInWords(person.Salary);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldThrowBadRequestForError()
        {
            Person p = null;
            var result = _controller.ProcessSalary(p);

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [TestMethod]
        public void ShouldReturnSuccess()
        {
            Person p = new Person { Name = "Jebin", Salary = 123.45, SalaryInWords = "" };
            var result = _controller.ProcessSalary(p);

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
