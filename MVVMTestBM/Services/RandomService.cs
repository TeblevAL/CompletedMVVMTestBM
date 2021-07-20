using CompletedMVVMTestBM;
using CompletedMVVMTestBM.Models;
using CompletedMVVMTestBM.Models.Interfaces;
using CompletedMVVMTestBM.Repositories;
using CompletedMVVMTestBM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompletedMVVMTestBM.Services
{
    public class RandomService
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public static bool isRunning = false;

        IBookService _bookService;

        BookRepository _bookRepository;


        public RandomService(IBookService bookService, BookRepository bookRepository)
        {
            _bookService = bookService;
            _bookRepository = bookRepository;
        }

        public void Start()
        {
            if (isRunning)
                return;

            isRunning = true;

            Task task = new Task(Algorithm);

            task.Start();
        }

        public void Break()
        {
            isRunning = false;
        }

        private void Algorithm()
        {
            while (_bookRepository.Books.Count > 0)
            {
                if (!isRunning)
                {
                    return;
                }

                Random random = new Random();

                int idMethod = random.Next(0, 2);
                IBook randomBook = _bookRepository.Books.ElementAt(random.Next(0, _bookRepository.Books.Count));

                if (idMethod == 0)
                {
                    IBook book = new Book();
                    book.Name = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
                    book.Author = randomBook.Author;

                    _bookService.Edit(randomBook, book);
                }
                else
                {
                    App.Current.Dispatcher.Invoke(delegate { _bookService.Delete(randomBook); });
                    if (_bookRepository.Books.Count == 0)
                    {

                        isRunning = false;

                        return;
                    }
                }

                Thread.Sleep(3000);

            }
        }

    }
}
