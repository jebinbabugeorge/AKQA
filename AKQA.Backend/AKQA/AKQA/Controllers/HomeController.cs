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
                ConvertNumberToWord cntw = new ConvertNumberToWord();

                model.SalaryInWords = cntw.GetSalaryInWords(model.Salary);

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
