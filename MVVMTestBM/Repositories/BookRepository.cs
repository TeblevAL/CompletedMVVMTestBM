using CompletedMVVMTestBM.Core;
using CompletedMVVMTestBM.Models.Interfaces;

using System.Collections.ObjectModel;

namespace CompletedMVVMTestBM.Repositories
{
    public class BookRepository : ObservableObject
    {
        public BookRepository()
        {
            Books = new ObservableCollection<IBook>();
        }

        private readonly ObservableCollection<IBook> _books;

        public ObservableCollection<IBook> Books
        {
            get => _books;
            init
            {
                _books = value;
                OnPropertyChanged();
            }
        }
    }
}
