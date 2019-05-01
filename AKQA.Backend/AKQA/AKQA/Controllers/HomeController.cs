using AKQA.BusinessLayer;
using AKQA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AKQA.Controllers
{
    public class HomeController : ApiController
    {
        private readonly IConvertNumberToWord _convertNumberToWord;

        public HomeController(IConvertNumberToWord convertNumberToWord)
        {
            _convertNumberToWord = convertNumberToWord;
        }

        /// <summary>
        /// The API that processes the request to convert the salary into equivalent words
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost()]
        [Route("home/processrequest")]
        public HttpResponseMessage ProcessSalary(Person model)
        {
            try
            {
                model.SalaryInWords = _convertNumberToWord.GetSalaryInWords(model.Salary);

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
