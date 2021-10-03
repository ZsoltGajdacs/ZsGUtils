using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ZsGUtils.Randoms.Tests
{
    [TestClass()]
    public class RandIntMemTests
    {
        [TestMethod()]
        public void GetRandIntTest()
        {
            for (int i = 1; i <= 10; ++i)
            {
                RandIntMem randIntMem = new RandIntMem(i);
                TestRandInt(ref randIntMem, i);
            }
        }

        private void TestRandInt(ref RandIntMem randIntMem, int amountToRemember)
        {
            List<int> generatedNums = new List<int>();
            bool isThereNoRepeat = false;
            for (int i = 0; i < amountToRemember; ++i)
            {
                int num = randIntMem.GetRandInt(0, amountToRemember);

                if (generatedNums.Contains(num))
                {
                    isThereNoRepeat = false;
                    break;
                }
                else
                {
                    generatedNums.Add(num);
                    isThereNoRepeat = true;
                }
            }


            Assert.IsTrue(isThereNoRepeat);
        }
    }
}