using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult Index()
        {
            List<Project> starredProjects = Project.GetProjects();
            return View(starredProjects);
        }
    }
}
