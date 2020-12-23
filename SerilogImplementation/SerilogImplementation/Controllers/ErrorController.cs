using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SerilogImplementation.Models;

namespace SerilogImplementation.Controllers
{
    /// <summary>
    /// Note: It's a good practice to use logging in a single controller. 
    /// </summary>
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string errorMessage)
        {
            _logger.LogError(errorMessage);

            //We are showing the message to our user. Which is a bad practice. We could leak system info. This could lead to hacking.\
            //This is only for testing purpose. Find something new to resolve this.
            var error = new ErrorViewModel
            {
                ErrorMessage = errorMessage
            };
            return View(error);
        }
    }
}
