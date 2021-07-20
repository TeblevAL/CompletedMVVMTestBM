using CompletedMVVMTestBM.Services.Interfaces;
using MVVMTestBM.Models.Interfaces;
using MVVMTestBM.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompletedMVVMTestBM.Services
{
    public class FiltrationService : IFiltrationService
    {
        private BookRepository _bookRepository;

        public FiltrationService(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<IBook> GetBooksByName(string name)
        {
            if (name == "" || string.IsNullOrWhiteSpace(name))
            {
                return _bookRepository.Books;
            }

            return _bookRepository.Books.Where(b => b.Name.ToUpper().StartsWith(name.ToUpper()));
        }
    }
}
