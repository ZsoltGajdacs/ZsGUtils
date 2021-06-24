using Newtonsoft.Json;
using System.IO;
using ZsGUtils.Enums;

namespace ZsGUtils.FilesystemUtils
{
    /// <summary>
    /// Keeps all the JSON serializer methods
    /// </summary>
    public static class JsonSerializer
    {
        public static bool Serialize<T>(string saveDir, string fileName, ref T serializable, DoBackup doBackup)
        {
            if (saveDir == null || string.IsNullOrWhiteSpace(fileName))
            {
                return false;
            }

            string path = CreateSavePath(saveDir, fileName);
            CreateDirIfDoesntExist(saveDir);
            CreateBackupIfNeeded(path, doBackup);

            TextWriter writer = null;
            try
            {
                string output = JsonConvert.SerializeObject(serializable);
                writer = new StreamWriter(path, false);
                writer.Write(output);
            }
            finally
            {
                if (writer != null) writer.Close();
            }

            return true;
        }

        public static T Deserialize<T>(string path, MissingMemberHandling missingMemberHandling = MissingMemberHandling.Ignore)
        {
            if (!new FileInfo(path).Exists)
            {
                return default;
            }

            TextReader reader = null;
            try
            {
                reader = new StreamReader(path);
                string fileContents = reader.ReadToEnd();

                JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
                {
                    MissingMemberHandling = missingMemberHandling
                };

                return JsonConvert.DeserializeObject<T>(fileContents, jsonSerializerSettings);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        private static string CreateSavePath(string dirName, string fileName)
        {
            return Path.Combine(dirName, fileName);
        }

        private static void CreateDirIfDoesntExist(string dirName)
        {
            if (string.IsNullOrWhiteSpace(dirName))
            {
                return;
            }

            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
        }

        private static void CreateBackupIfNeeded(string path, DoBackup doBackup)
        {
            if (DoBackup.Yes == doBackup && File.Exists(path))
            {
                string backupPath = path + ".bak";
                if (File.Exists(backupPath))
                {
                    File.Delete(backupPath);
                }

                File.Copy(path, backupPath);
            }
        }
    }
}
