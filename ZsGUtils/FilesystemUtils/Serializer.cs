using System;
using System.IO;
using ZsGUtils.Enums;

namespace ZsGUtils.FilesystemUtils
{
    public abstract class Serializer
    {
        public static string GetPathForSaveToLocalAppData(string fileName)
        {
            return CreateSavePath(GetPathToLocalAppDataDir(), fileName);
        }

        public static string GetPathToLocalAppDataDir()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        }

        protected static string CreateSavePath(string dirName, string fileName)
        {
            return Path.Combine(dirName, fileName);
        }

        protected static void CreateDirIfDoesntExist(string dirName)
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

        protected static void CreateBackupIfNeeded(string path, DoBackup doBackup)
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
