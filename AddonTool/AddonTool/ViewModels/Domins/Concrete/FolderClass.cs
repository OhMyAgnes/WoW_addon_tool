using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddonTool.ViewModels.Domins.Concrete
{
    class FolderClass : UIPropertyChanged
    {        
        private string _folderPath;
        public string FolderPath
        {
            get { return _folderPath; }
            set
            {
                _folderPath = value;
                OnPropertyChanged("FolderPath");
            }
        }
    }
}
