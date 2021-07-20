using MVVMTestBM.Models.Interfaces;
using MVVMTestBM.Repositories;
using MVVMTestBM.Services.Interfaces;

using System.Linq;

namespace MVVMTestBM.Services
{
    public class BookService : IBookService
    {
        public BookService(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        private readonly BookRepository _bookRepository;

        public void Add(IBook book)
        {
            if (book is null)
            {
                return;
            }

            _bookRepository.Books.Add(book);
        }

        public void Edit(IBook book, IBook editedBook)
        {
            IBook bookToEdit = _bookRepository.Books.FirstOrDefault(b => b.Id == book.Id);

            if (bookToEdit is null || editedBook is null)
            {
                return;
            }

            bookToEdit.Name = editedBook.Name;
            bookToEdit.Author = editedBook.Author;
        }

        public void Delete(IBook book)
        {
            IBook bookToRemove = _bookRepository.Books.FirstOrDefault(b => b.Id == book.Id);

            if (bookToRemove is null)
            {
                return;
            }

            _bookRepository.Books.Remove(bookToRemove);
        }

    }
}
