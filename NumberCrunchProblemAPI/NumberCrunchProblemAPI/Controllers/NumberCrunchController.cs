using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NumberCrunchProblemAPI.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberCrunchProblemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberCrunchController : ControllerBase
    {
        private readonly ILogger<NumberCrunchController> _logger;

        public NumberCrunchController(ILogger<NumberCrunchController> logger)
        {
            _logger = logger;
        }

        
        [HttpPost]
        public ActionResult<List<ResultSet>> CrunchNumbers(ResultQuery query)
        {
            NumberCrunchMGR mgr = new NumberCrunchMGR();
            
            return mgr.generateResults(query); ;
        }
    }
}
