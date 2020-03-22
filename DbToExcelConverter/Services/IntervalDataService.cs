using System.Collections.Generic;
using System.Linq;
using DbToExcelConverter.Models.DBModel;
using DbToExcelConverter.Models.ViewModel;


namespace DbToExcelConverter.Services
{
    public class IntervalDataService
    {
        public List<IntervalDataViewModel> GetIntervalDataViewModel(List<IntervalData> intervalData)
        {
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

            return intervalDataViewModels;
        }
    }
}
