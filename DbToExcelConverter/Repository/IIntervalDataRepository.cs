using DbToExcelConverter.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbToExcelConverter.Repository
{
    public interface IIntervalDataRepository
    {
        public IQueryable<IntervalData> Get();
    }
}
