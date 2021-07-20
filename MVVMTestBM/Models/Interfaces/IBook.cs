namespace MVVMTestBM.Models.Interfaces
{
    public interface IBook
    {
        public string Id { get; }

        public string Name { get; set; }

        public string Author { get; set; }
    }
}
