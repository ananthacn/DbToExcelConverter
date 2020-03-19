using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbToExcelConverter.Models.DBModel
{
    public class IntervalData
    {
        public int Id { get; set; }
        public Int64 DeliveryPoint { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan TimeSlot { get; set; }
        public decimal SlotVal { get; set; }
        
    }
}
