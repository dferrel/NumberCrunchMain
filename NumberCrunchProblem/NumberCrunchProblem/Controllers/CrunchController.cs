using Microsoft.AspNetCore.Mvc;
using NumberCrunchProblem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberCrunchProblem.Controllers
{
    public class CrunchController : Controller
    {

        public IActionResult Results(int MaxResults, int DoctorScore, int PatientScore)
        {
            ResultsModel rModel = new ResultsModel(MaxResults,DoctorScore,PatientScore);
            
            return View(rModel);
        }
    }
}
