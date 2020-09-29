using System;
using System.Collections.Generic;
using System.Text;
using DataIO.General.Concrete;

namespace DataIO.General
{
    public class GeneralFactory
    {
        public IFileSystem CreateFileSystem()
        {
            return new FileSystem();
        }
    }
}
