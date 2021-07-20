using MVVMTestBM.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletedMVVMTestBM.Services.Interfaces
{
    public interface IFiltrationService
    {
        public IEnumerable<IBook> GetBooksByName(string name);
    }
}
