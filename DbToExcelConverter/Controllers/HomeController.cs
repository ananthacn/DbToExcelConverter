using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DbToExcelConverter.Repository;
using DbToExcelConverter.Models.ViewModel;
using DbToExcelConverter.Converter.Interface;
using Microsoft.AspNetCore.Diagnostics;
using DbToExcelConverter.Services;

namespace DbToExcelConverter.Controllers
{
    public class HomeController : Controller
    {        
        private readonly IIntervalDataRepository _intervalDataRepository;
        private readonly IConverter<IntervalDataViewModel> _converter;
        public HomeController(IIntervalDataRepository intervalDataRepository,
            IConverter<IntervalDataViewModel> converter)
        {
             _intervalDataRepository = intervalDataRepository;
            _converter = converter;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int? i)
        {
            var intervalData = _intervalDataRepository.Get().ToList();
            var intervalDataService = new IntervalDataService();            
            var result = _converter.Convert<IntervalDataViewModel>(intervalDataService.GetIntervalDataViewModel(intervalData));

            ViewBag.Message = "Sucessfully extracted the excel file to location " + result;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            var expectionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ExceptionPath = expectionDetails.Path;
            ViewBag.ExceptionMessage = expectionDetails.Error.Message;
            ViewBag.ExceptionStackTrace = expectionDetails.Error.StackTrace;
            return View();
        }

    }
}
