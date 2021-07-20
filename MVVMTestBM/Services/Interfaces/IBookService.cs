using MVVMTestBM.Models.Interfaces;

namespace MVVMTestBM.Services.Interfaces
{
    public interface IBookService
    {
        public void Add(IBook book);

        public void Edit(IBook book, IBook editedBook);

        public void Delete(IBook book);
    }
}
