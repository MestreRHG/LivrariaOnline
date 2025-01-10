using LivrariaOnline.Models;

namespace LivrariaOnline.ViewModels
{
    public class IndexViewModel
    {
        public List<Book> Books { get; set; }
        public string Search { get; set; }
    }
}
