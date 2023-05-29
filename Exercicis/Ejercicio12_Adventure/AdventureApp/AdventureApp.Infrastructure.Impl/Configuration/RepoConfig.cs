using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureApp.Infrastructure.Impl.Configuration
{
    public class RepoConfig : IRepoConfig
    {
        public string FilePath => _filePath;
        private string _filePath;

        public RepoConfig()
        {
            SetFilePath();
        }

        private void SetFilePath()
        {
            //_filePath = ConfigurationManager.AppSettings["FilePath"];
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\character.json");
        }
    }
}
