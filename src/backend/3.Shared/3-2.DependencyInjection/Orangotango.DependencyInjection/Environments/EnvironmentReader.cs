using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Orangotango.DependencyInjection.Environments
{
    public class EnvironmentReader
    {
        public static readonly string Folder = "Environments";
        public static readonly string FileName = "appsettings.json";

        #region GETTERS

        private static string _filePath;
        private static string FilePath
        {
            get
            {
                if (string.IsNullOrEmpty(_filePath))
                    _filePath = GetBaseDirectory();

                return _filePath;
            }
        }

        private static Dictionary<string, string> _environments;
        private static Dictionary<string, string> Environments
        {
            get
            {
                if (_environments == null)
                {
                    var content = File.ReadAllText(FilePath);
                    _environments = JsonSerializer.Deserialize<Dictionary<string, string>>(content);
                }

                return _environments;
            }
        }

        #endregion

        public static string GetEnvironmentVariable(string name)
        {
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable(name)))
                return Environment.GetEnvironmentVariable(name);

            return Environments[name];
        }

        private static string GetBaseDirectory()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(baseDirectory, Folder, FileName);
        }
    }
}
