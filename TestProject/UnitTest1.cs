using NUnit.Framework;
using QuanLySinhVien;
/// <summary>
/// Module for Testing 
/// </summary>
namespace TestProject
{
    public class Tests
    {
        private QuanLy _pro;
        [SetUp]
        public void Setup()
        {
            _pro = new QuanLy();
        }

        [Test]
        public void Test1()
        {
            //Assert.Pass();
            Assert.Fail("You're a failure!");
        }
        [Test]
        public void Test2()
        {
            //Assert.Fail("You look so suck!");
            Assert.Pass("Nice =))");
        }
    }
}