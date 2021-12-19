using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NextensTaxTool.BLL.Interfaces;
using NextensTaxTool.Models;
using System;
using System.Diagnostics;

namespace NextensTaxTool.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INextensFinancialDataService _nextensFinancialDataService;
        private readonly IReportService _reportService;
        public HomeController(ILogger<HomeController> logger, INextensFinancialDataService nextensFinancialDataService, IReportService reportService)
        {
            _logger = logger;
            _nextensFinancialDataService = nextensFinancialDataService;
            _reportService = reportService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Import()
        {
            var result = _nextensFinancialDataService.ImportData();
            ViewBag.Result = result;
            return View();
        }

        public IActionResult Report(int year)
        {
            int currentYear = DateTime.Now.Year - 1;
            int reportingYear = currentYear;
            if (year >= currentYear - 7 && year < currentYear)
            {
                reportingYear = year;
            }
            return View(_reportService.GetReportForUniqueClients(reportingYear));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
