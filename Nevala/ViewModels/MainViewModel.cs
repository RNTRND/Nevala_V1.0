
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nevala.ViewModels
{
   public class MainViewModel
    {
        //Document that is saved, loaded and holds editor text
        private Document _document;
        public FileViewModel File { get; set; }
        public ViewModel View { get; set; }
        public EditViewModel Edit { get; set; }
        public MainViewModel()
        {
            _document = new Document();         
            File = new FileViewModel(_document);
            View = new ViewModel(_document);
            Edit = new EditViewModel(_document);
        }
    }
}
