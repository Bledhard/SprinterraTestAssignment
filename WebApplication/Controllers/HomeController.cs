using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SprinterraTestAssignment.Logger.Interfaces;
using SprinterraTestAssignment.WebApplication.Models;

namespace SprinterraTestAssignment.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomLogger _logger;

        public HomeController(ICustomLogger logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ContentResult CalculateFigureArea([FromBody] List<FigurePoint> points)
        {
            decimal firstSum = 0,
                secondSum = 0;

            for (int i = 1; i < points.Count - 1; i++)
            {
                firstSum += points[i].Y * (points[i - 1].X + points[i + 1].X);
                secondSum += points[i].X * (points[i + 1].Y + points[i - 1].Y);
            }

            firstSum /= 2;
            secondSum /= 2;

            var isValidArea = firstSum == secondSum;

            if (isValidArea)
                return Content("{ \"isValidArea\":" + isValidArea.ToString().ToLower() + ", \"value\":" + firstSum + "}", "application/json");
            else
                return Content("{ \"isValidArea\":" + isValidArea.ToString().ToLower() + ", \"value\": \"" + firstSum + "/" + secondSum + "\"}", "application/json");
        }

        public IActionResult Logger()
        {
            return View();
        }
    }
}
