using DbToExcelConverter.Models.DBModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbToExcelConverter.Repository
{
    public class IntervalDataRepository : IIntervalDataRepository
    {

        private readonly IntervalDataDbContext _coreDbContext;

        public IntervalDataRepository(IntervalDataDbContext coreDbContext)
        {
            _coreDbContext = coreDbContext;            
        }

        public IQueryable<IntervalData> Get()
        {
           return _coreDbContext.IntervalData.AsNoTracking();           
        }
    }
}
