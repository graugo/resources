using System;
using System.Configuration;
using System.IO;

namespace HiveApp.Infrastructure.Impl.Config
{
    public class RepositoryConfiguration : IRepositoryConfiguration
    {
        public string FilePath => _filePath;
        private string _filePath;

        public RepositoryConfiguration()
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../HiveApp.Infrastructure.Impl\Files\hive.json");
        }
    }
}
