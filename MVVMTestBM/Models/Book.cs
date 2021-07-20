using System;
using MVVMTestBM.Core;
using MVVMTestBM.Models.Interfaces;

namespace MVVMTestBM.Models
{
    public class Book : ObservableObject, IBook
    {
        public Book()
        {
            Id = Guid.NewGuid().ToString();
        }

        private readonly string _id;

        public string Id
        {
            get => _id;
            init
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _author;

        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                OnPropertyChanged();
            }
        }
    }
}
