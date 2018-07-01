using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using SprinterraTestAssignment.Logger;
using SprinterraTestAssignment.Logger.Enumerators;
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
            _logger.Info("Index page opened");
            return View();
        }

        [HttpPost]
        public ContentResult CalculateFigureArea([FromBody] List<FigurePoint> points)
        {
            _logger.Info("CalculateFigureArea - Trying to calculate area of figure");

            var logPoints = new StringBuilder();
            points.ForEach(p => logPoints.AppendFormat("[{0}, {1}], ", p.X, p.Y));
            logPoints.Length -= 2; // remove ", " after last point
            _logger.Info("given points " + logPoints);

            decimal firstSum = 0,
                secondSum = 0;

            for (int i = 1; i < points.Count - 1; i++)
            {
                firstSum += points[i].Y * (points[i - 1].X + points[i + 1].X);
                secondSum += points[i].X * (points[i + 1].Y + points[i - 1].Y);
            }


            firstSum /= 2;
            secondSum /= 2;

            _logger.Info("firstSum = " + firstSum);
            _logger.Info("secondSum = " + secondSum);

            var isValidArea = firstSum == secondSum;

            if (isValidArea)
            {
                _logger.Info("This figure matches the criteria, returning area");
                return Content("{ \"isValidArea\":" + isValidArea.ToString().ToLower() + ", \"value\":" + firstSum + "}", "application/json");
            }
            else
            {
                _logger.Warn("Figure with this points doesn't match criteria.");
                return Content("{ \"isValidArea\":" + isValidArea.ToString().ToLower() + ", \"value\": \"" + firstSum + " / " + secondSum + "\"}", "application/json");
            }
        }

        public IActionResult Logger(string searchString = "")
        {
            var logs = _logger.Get();

            ViewData["searchString"] = "All";

            if (!String.IsNullOrEmpty(searchString))
            {
                ViewData["searchString"] = searchString;
                var keys = new List<string>(logs.Keys);
                foreach (string key in keys)
                {
                    logs[key] = logs[key].Where(l => l.LogLevel.ToString() == searchString).ToList();
                }
            }

            ViewData["logs"] = logs;
            ViewData["LogLevels"] = Enum.GetValues(typeof(CustomLogLevel)).Cast<CustomLogLevel>().ToList();

            return View();
        }
    }
}
