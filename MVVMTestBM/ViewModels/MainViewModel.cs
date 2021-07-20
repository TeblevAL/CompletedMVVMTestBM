using MVVMTestBM.Core;
using MVVMTestBM.Models;
using MVVMTestBM.Models.Interfaces;
using MVVMTestBM.Repositories;
using MVVMTestBM.Services.Interfaces;
using System.Windows;
using System.Windows.Input;

namespace MVVMTestBM.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(BookRepository bookRepository, IBookService bookService)
        {
            BookRepository = bookRepository;

            _bookService = bookService;

            BookForEdit = new Book();
        }

        public BookRepository BookRepository { get; }

        private readonly IBookService _bookService;

        private IBook _selectedBook;

        public IBook SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                OnPropertyChanged();
            }
        }

        private IBook _bookForEdit;

        public IBook BookForEdit
        {
            get => _bookForEdit;
            set
            {
                _bookForEdit = value;
                OnPropertyChanged();
            }
        }

        private ICommand _addBookCommand;
        public ICommand AddBookCommand => _addBookCommand ??= new RelayCommand(AddBook);

        private void AddBook(object commandParameter)
        {
            if (string.IsNullOrWhiteSpace(BookForEdit.Name))
            {
                MessageBox.Show("У книги должно быть название");
                return;
            }
            _bookService.Add(BookForEdit);

            BookForEdit = new Book();
        }

        private ICommand _deleteBookCommand;
        public ICommand DeleteBookCommand => _deleteBookCommand ??= new RelayCommand(DeleteBook, o => SelectedBook is not null);

        private void DeleteBook(object commandParameter)
        {
            _bookService.Delete(SelectedBook);
        }
    }
}
