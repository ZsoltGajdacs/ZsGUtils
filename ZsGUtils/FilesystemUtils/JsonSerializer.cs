using Newtonsoft.Json;
using System;
using System.IO;
using ZsGUtils.Enums;

namespace ZsGUtils.FilesystemUtils
{
    /// <summary>
    /// Keeps all the JSON serializer methods
    /// </summary>
    public class JsonSerializer : Serializer
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

            try
            {
                string jsonString = JsonConvert.SerializeObject(serializable);
                File.WriteAllText(path, jsonString);
            }
            catch (Exception e)
            {
                throw new SerializationException("Error during serialization", e);
            }

            return true;
        }

        public static T Deserialize<T>(string path, MissingMemberHandling missingMemberHandling = MissingMemberHandling.Ignore)
        {
            if (!new FileInfo(path).Exists)
            {
                return default;
            }

            T obj;
            try
            {
                string serializedString = File.ReadAllText(path);
                JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
                {
                    MissingMemberHandling = missingMemberHandling
                };

                obj = JsonConvert.DeserializeObject<T>(serializedString, jsonSerializerSettings);
            }
            catch (Exception e)
            {
                throw new SerializationException("Error during deserialization", e);
            }

            return obj;
        }
    }
}
