using CompletedMVVMTestBM.Models.Interfaces;

namespace CompletedMVVMTestBM.Services.Interfaces
{
    public interface IBookService
    {
        public void Add(IBook book);

        public void Edit(IBook book, IBook editedBook);

        public void Delete(IBook book);
    }
}
