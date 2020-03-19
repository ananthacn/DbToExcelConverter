using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbToExcelConverter.Converter.Interface
{
    //Generic interface which can take T as argument and extracts into required file
    public interface IConverter<T>
    {
        public string Convert<T>(List<T> value);
    }
}
