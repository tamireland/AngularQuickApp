// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL;
using AngularQuickApp.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Logging;
using AngularQuickApp.Helpers;

namespace AngularQuickApp.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailSender _emailSender;


        public ProductController(IUnitOfWork unitOfWork, ILogger<ProductController> logger, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailSender = emailSender;
        }



        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var allProducts = _unitOfWork.Products.GetAllProductsData();
            return Ok(Mapper.Map<IEnumerable<ProductViewModel>>(allProducts));
        }



        [HttpGet("throw")]
        public IEnumerable<ProductViewModel> Throw()
        {
            throw new InvalidOperationException("This is a test exception: " + DateTime.Now);
        }



        [HttpGet("email")]
        public async Task<string> Email()
        {
            string recepientName = "QickApp Tester"; //         <===== Put the recepient's name here
            string recepientEmail = "test@ebenmonney.com"; //   <===== Put the recepient's email here

            string message = EmailTemplates.GetTestEmail(recepientName, DateTime.UtcNow);

            (bool success, string errorMsg) = await _emailSender.SendEmailAsync(recepientName, recepientEmail, "Test Email from AngularQuickApp", message);

            if (success)
                return "Success";

            return "Error: " + errorMsg;
        }



        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value: " + id;
        }



        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }



        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }



        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
