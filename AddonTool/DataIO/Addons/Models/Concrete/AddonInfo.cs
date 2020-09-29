using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataIO.Addons.Models;

namespace DataIO.Addons.Models.Concrete
{
    public class AddonInfo : UIPropertyChanged
    {
        public string DefaultState { get; set; }
        public string[] RequiredDependencies { get; set; }
        public string[] SavedVariables { get; set; }
   
        private string _author;
        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                OnPropertyChanged("Author");
            }
        }

        private string _category;
        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
                OnPropertyChanged("Category");
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        private Version _interface;
        public Version Interface
        {
            get { return _interface; }
            set
            {
                _interface = value;
                OnPropertyChanged("Interface");
            }
        }


        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        private string _version;
        public string Version
        {
            get { return _version; }
            set
            {
                _version = value;
                OnPropertyChanged("Version");
            }
        }

        private Uri _website;
        public Uri Website
        {
            get { return _website; }
            set
            {
                _website = value;
                OnPropertyChanged("Website");
            }
        }

        private string _directoryPath;
        public string DirectoryPath
        {
            get { return _directoryPath; }
            set
            {
                _directoryPath = value;
                OnPropertyChanged("DirectoryPath");
            }
        }
    }
}
