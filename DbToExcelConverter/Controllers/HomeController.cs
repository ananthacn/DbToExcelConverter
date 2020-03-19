using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DbToExcelConverter.Repository;
using DbToExcelConverter.Models.ViewModel;
using DbToExcelConverter.Converter.Interface;
using DbToExcelConverter.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;

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
            
            var intervalDataViewModels = new List<IntervalDataViewModel>();
            foreach (var item in intervalData.Select((value, index) => new { Value = value, Index = index }))
            {
                var intervalDataViewModel = new IntervalDataViewModel();
                if (item.Index % 2 != 0)
                {
                    intervalDataViewModel.DeliveryPoint = item.Value.DeliveryPoint;
                    intervalDataViewModel.Date = item.Value.Date;
                    intervalDataViewModel.TimeSlot = item.Value.TimeSlot.Hours;
                    intervalDataViewModel.SlotVal = item.Value.SlotVal + intervalData[item.Index - 1].SlotVal;
                    intervalDataViewModels.Add(intervalDataViewModel);
                }               
            }
            var result = _converter.Convert<IntervalDataViewModel>(intervalDataViewModels);

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
