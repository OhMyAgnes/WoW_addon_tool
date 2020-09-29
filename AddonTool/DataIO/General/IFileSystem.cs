﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataIO.General
{
    public interface IFileSystem
    {
        bool DirectoryIsValid(string path);
        bool DirectoryExists(string path);
        void DeleteDirectory(string directoryPath);

        T GetObjectFromFile<T>(string path);
        void SaveObjectToFile<T>(string path, T obj);
        Task ExtractZipToPath(string zipPath, string outputPath);
        void MoveDirectory(string source, string target);
        void CopyDirectory(string source, string target);
    }
}
