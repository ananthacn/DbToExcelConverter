using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbToExcelConverter.Models.ViewModel
{
    //View model which consists of required properties from IntervalData table
    public class IntervalDataViewModel
    {
        public Int64 DeliveryPoint { get; set; }
        public DateTime Date { get; set; }
        public int TimeSlot { get; set; }
        public decimal SlotVal { get; set; }
    }
}
