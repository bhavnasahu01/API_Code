using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticeApplication.MyLogging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticeApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : Controller
    {
        //1. Strongly coupled/tightly coupled 
        //2. Loosely coupled




        ////1.
        //private readonly IMyLogger _myLogger;
        //public DemoController()
        //{
        //    _myLogger = new LogToFile();
        //}

        //[HttpGet]
        //public ActionResult Index()
        //{
        //    _myLogger.Log("Index method is started");
        //    return Ok();

        //}



        //2
        private readonly IMyLogger _myLogger;
        public DemoController(IMyLogger myLogger)
        {
            _myLogger = myLogger;
        }

        [HttpGet]
        public ActionResult Index()
        {
            _myLogger.Log("Index method is started");
            return Ok();

        }


        //private readonly  LogToDB _log;
        //public DemoController(LogToDB log)
        //{
        //    _log = log;
        //}
        //[HttpGet]
        //public ActionResult Index()
        //{
        //    _log.Log("Index method is started");
        //    return Ok();

        //}

    }
}

