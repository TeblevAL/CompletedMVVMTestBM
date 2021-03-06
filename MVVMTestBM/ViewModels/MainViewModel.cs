using CompletedMVVMTestBM.Services;
using CompletedMVVMTestBM.Services.Interfaces;
using CompletedMVVMTestBM.Core;
using CompletedMVVMTestBM.Models;
using CompletedMVVMTestBM.Models.Interfaces;
using CompletedMVVMTestBM.Repositories;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace CompletedMVVMTestBM.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(BookRepository bookRepository, IBookService bookService)
        {
            _bookRepository = bookRepository;

            _bookService = bookService;

            _filtrationService = new FiltrationService(_bookRepository);

            _randomService = new RandomService(_bookService,_bookRepository);

            Books = _bookRepository.Books;

            BookForEdit = new Book();
        }

        private BookRepository _bookRepository;

        private readonly IBookService _bookService;

        private IFiltrationService _filtrationService;

        private RandomService _randomService;

        private ObservableCollection<IBook> _books;

        public ObservableCollection<IBook> Books
        {
            get => _books;
            set
            {
                _books = value;
                OnPropertyChanged();
            }
        }

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

        private string _searchText;

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
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

        private ICommand _editBookCommand;
        public ICommand EditBookCommand => _editBookCommand ??= new RelayCommand(EditBook, o => SelectedBook is not null);

        public void EditBook(object commandParameter)
        {
            if (string.IsNullOrWhiteSpace(BookForEdit.Name))
            {
                MessageBox.Show("У книги должно быть название");
                return;
            }

            _bookService.Edit(SelectedBook,BookForEdit);
        }

        private ICommand _deleteBookCommand;
        public ICommand DeleteBookCommand => _deleteBookCommand ??= new RelayCommand(DeleteBook, o => SelectedBook is not null);

        private void DeleteBook(object commandParameter)
        {
            _bookService.Delete(SelectedBook);
        }

        private ICommand _searchBooksCommand;
        public ICommand SearchBooksCommand => _searchBooksCommand ??= new RelayCommand(SearchBooks, o => _bookRepository.Books.Count > 0);

        private void SearchBooks(object commandParameter)
        {
            Books = new ObservableCollection<IBook>(_filtrationService.GetBooksByName(SearchText));
        }

        private ICommand _resetSearchCommand;
        public ICommand ResetSearchCommand => _resetSearchCommand ??= new RelayCommand(ResetSearch);

        private void ResetSearch(object commandParameter)
        {
            Books = _bookRepository.Books;
            SearchText = string.Empty;
        }

        private ICommand _randomTurnOnCommand;
        public ICommand RandomTurnOnCommand => _randomTurnOnCommand ??= new RelayCommand(RandomTurnOn, o => _bookRepository.Books.Count > 0 && 
                                                                                                            !RandomService.isRunning);

        private void RandomTurnOn(object commandParameter)
        {
            _randomService.Start();
        }

        private ICommand _randomTurnOffCommand;
        public ICommand RandomTurnOffCommand => _randomTurnOffCommand ??= new RelayCommand(RandomTurnOff, o => RandomService.isRunning);

        private void RandomTurnOff(object commandParameter)
        {
            _randomService.Break();
        }
    }
}
