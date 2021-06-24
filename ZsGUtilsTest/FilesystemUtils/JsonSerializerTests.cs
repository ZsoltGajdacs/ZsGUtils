using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using ZsGUtilsTest.FilesystemUtils;

namespace ZsGUtils.FilesystemUtils.Tests
{
    [TestClass()]
    public class JsonSerializerTests
    {
        private static readonly string TESTFILENAME = "teszt.txt";
        private static readonly string TESTDIRNAME = "tesztDir";

        private string testString = "Something here";
        private readonly TestClass testClass = new();

        [TestInitialize]
        public void BeforeEach()
        {
            if (File.Exists(TESTFILENAME))
            {
                File.Delete(TESTFILENAME);
            }
            
            if (Directory.Exists(TESTDIRNAME))
            {
                Directory.Delete(TESTDIRNAME, true);
            }
        }

        [TestMethod()]
        public void NullDirBoolTest()
        {
            bool result = JsonSerializer.Serialize(null, TESTFILENAME, ref testString, Enums.DoBackup.No);

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void NullDirFileTest()
        {
            JsonSerializer.Serialize(null, TESTFILENAME, ref testString, Enums.DoBackup.No);

            string result = JsonSerializer.Deserialize<string>(TESTFILENAME);

            Assert.IsNull(result);
        }

        [TestMethod()]
        public void NullFileBoolTest()
        {
            bool result = JsonSerializer.Serialize("", null, ref testString, Enums.DoBackup.No);

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void NullFileFileTest()
        {
            JsonSerializer.Serialize("", null, ref testString, Enums.DoBackup.No);

            string result = JsonSerializer.Deserialize<string>(TESTFILENAME);

            Assert.IsNull(result);
        }

        [TestMethod()]
        public void EmptyDirBoolTest()
        {
            bool result = JsonSerializer.Serialize("", TESTFILENAME, ref testString, Enums.DoBackup.No);

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void EmptyDirFileTest()
        {
            JsonSerializer.Serialize("", TESTFILENAME, ref testString, Enums.DoBackup.No);

            string result = JsonSerializer.Deserialize<string>(TESTFILENAME);

            Assert.AreEqual(testString, result);
        }

        [TestMethod()]
        public void EmptyFileBoolTest()
        {
            bool result = JsonSerializer.Serialize("", "", ref testString, Enums.DoBackup.No);

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void EmptyFileFileTest()
        {
            JsonSerializer.Serialize("", "", ref testString, Enums.DoBackup.No);

            string result = JsonSerializer.Deserialize<string>(TESTFILENAME);

            Assert.IsNull(result);
        }

        [TestMethod()]
        public void SubdirSaveFileWrongDeserializePathTest()
        {
            JsonSerializer.Serialize(TESTDIRNAME, TESTFILENAME, ref testString, Enums.DoBackup.No);

            string result = JsonSerializer.Deserialize<string>(TESTFILENAME);

            Assert.IsNull(result);
        }

        [TestMethod()]
        public void SubdirSaveFileTest()
        {
            JsonSerializer.Serialize(TESTDIRNAME, TESTFILENAME, ref testString, Enums.DoBackup.No);

            string result = JsonSerializer.Deserialize<string>(Path.Combine(TESTDIRNAME,TESTFILENAME));

            Assert.AreEqual(testString, result);
        }
        // TODO: Custom object testing, backup testing
    }
}