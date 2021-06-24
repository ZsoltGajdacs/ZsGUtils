using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using ZsGUtilsTest.EnumUtils;

namespace ZsGUtils.EnumUtils.Tests
{
    [TestClass()]
    public class EnumUtilTests
    {
        [TestMethod()]
        public void GetValuesCountTest()
        {
            List<TestEnum> valuesList = EnumUtil.GetValues<TestEnum>().ToList();

            Assert.IsTrue(valuesList.Count() == 5);
        }

        [TestMethod()]
        public void GetValuesOrderBeginningTest()
        {
            List<TestEnum> valuesList = EnumUtil.GetValues<TestEnum>().ToList();

            Assert.IsTrue(valuesList[0] == TestEnum.SOMETHING);
        }

        [TestMethod()]
        public void GetValuesOrderEndTest()
        {
            List<TestEnum> valuesList = EnumUtil.GetValues<TestEnum>().ToList();

            Assert.IsTrue(valuesList[4] == TestEnum.ANYTHING);
        }

        [TestMethod()]
        public void GetStringValuesDisplayNameWhenBothPresentTest()
        {
            List<string> valuesList = EnumUtil.GetStringValues<TestEnum>().ToList();

            Assert.IsTrue(valuesList[0] == TestEnum.SOMETHING.GetDisplayName());
        }

        [TestMethod()]
        public void GetStringValuesDisplayNameWhenDisplaynameOnlyTest()
        {
            List<string> valuesList = EnumUtil.GetStringValues<TestEnum>().ToList();

            Assert.IsTrue(valuesList[1] == TestEnum.WHATEVER.GetDisplayName());
        }

        [TestMethod()]
        public void GetStringValuesDescriptionWhenDescriptionOnlyTest()
        {
            List<string> valuesList = EnumUtil.GetStringValues<TestEnum>().ToList();

            Assert.IsTrue(valuesList[2] == TestEnum.DUNNO.GetDescription());
        }

        [TestMethod()]
        public void GetStringValuesBothEmptyTest()
        {
            List<string> valuesList = EnumUtil.GetStringValues<TestEnum>().ToList();

            Assert.IsTrue(valuesList[3] == "EMPTY");
        }

        [TestMethod()]
        public void GetStringValuesNoAttributeTest()
        {
            List<string> valuesList = EnumUtil.GetStringValues<TestEnum>().ToList();

            Assert.IsTrue(valuesList[4] == "ANYTHING");
        }

        [TestMethod()]
        public void GetEnumForStringNullTest()
        {
           Assert.IsNull(EnumUtil.GetEnumForString<TestEnum>(null));
        }

        [TestMethod()]
        public void GetEnumForStringEmptyTest()
        {
            Assert.IsNull(EnumUtil.GetEnumForString<TestEnum>(""));
        }

        [TestMethod()]
        public void GetEnumForStringGibberishTest()
        {
            Assert.IsNull(EnumUtil.GetEnumForString<TestEnum>("asfadgsdzjkuklzlk"));
        }

        [TestMethod()]
        public void GetEnumForStringDisplayNameTest()
        {
            Assert.IsTrue(EnumUtil.GetEnumForString<TestEnum>("Something").FoundEnum == TestEnum.SOMETHING);
        }

        [TestMethod()]
        public void GetEnumForStringDescriptionOnlyTest()
        {
            Assert.IsTrue(EnumUtil.GetEnumForString<TestEnum>("Dunno what is this").FoundEnum == TestEnum.DUNNO);
        }

        [TestMethod()]
        public void GetEnumForStringDescriptionWithNameTest()
        {
            Assert.IsTrue(EnumUtil.GetEnumForString<TestEnum>("Something boring").FoundEnum == TestEnum.SOMETHING);
        }

        [TestMethod()]
        public void GetEnumForStringToStringCapsTest()
        {
            Assert.IsTrue(EnumUtil.GetEnumForString<TestEnum>("ANYTHING").FoundEnum == TestEnum.ANYTHING);
        }

        [TestMethod()]
        public void GetEnumForStringToStringSmallTest()
        {
            Assert.IsNull(EnumUtil.GetEnumForString<TestEnum>("anything"));
        }
    }
}