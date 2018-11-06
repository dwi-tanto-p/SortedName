using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorter;

namespace UnitTestName
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

        }
        [TestMethod]
        public void TestRightOrder()
        {
            var name1 = new Name("tanto a");
            var name2 = new Name("tanto b");
            var dt = name1.CompareTo(name2);
            Assert.AreEqual(-1, dt);
        }

        [TestMethod]
        public void TestSameOrder()
        {
            var name1 = new Name("tanto ab");
            var name2 = new Name("tanto Ab");
            var dt = name1.CompareTo(name2);
            Assert.AreEqual(0, dt);
        }

        [TestMethod]
        public void TestWrongOrder()
        {
            var name1 = new Name("tanto b");
            var name2 = new Name("tanto A");
            var dt = name1.CompareTo(name2);
            Assert.AreEqual(1, dt);
        }



        [TestMethod]
        public void TestLastName()
        {
            //test 1
            var name = new Name("Abc a");
            var lastName = name.GetLastName();
            Assert.AreEqual("a", lastName);

            //test 2
            name.FullName = "Ab";
            lastName = name.GetLastName();
            Assert.AreEqual("Ab", lastName);

            //test 3
            name.FullName = "a1 a2 a3";
            lastName = name.GetLastName();
            Assert.AreEqual("a3", lastName);


        }

        [TestMethod]
        public void TestFirstName()
        {
            //test 1
            var name = new Name("Abc a");
            var firstName = name.GetFirstName();
            Assert.AreEqual("Abc", firstName);

            //test 2
            name.FullName = "Ab";
            firstName = name.GetFirstName();
            Assert.AreEqual("", firstName);

            //test 3
            name.FullName = "a1 a2 a3";
            firstName = name.GetFirstName();
            Assert.AreEqual("a1 a2", firstName);


        }

        [TestMethod]
        public void TestOrder()
        {
            var colName = new[] { new Name("Tanto b"), new Name("Tanto c"), new Name("Tanto a") };
            Array.Sort(colName);

            Assert.AreEqual("Tanto a", colName[0].ToString());
            Assert.AreEqual("Tanto b", colName[1].ToString());
            Assert.AreEqual("Tanto c", colName[2].ToString());

            

        }

        [TestMethod]
        public void TestOrder2()
        {
            var colName = new[] { new Name("a1 a"), new Name("a3 a"), new Name("a2 a") };
            Array.Sort(colName);

            Assert.AreEqual("a1 a", colName[0].ToString());
            Assert.AreEqual("a2 a", colName[1].ToString());
            Assert.AreEqual("a3 a", colName[2].ToString());
        }

        [TestMethod]
        public void TestOrder3()
        {
            var colName = new[] { new Name("a"), new Name("a3  a"), new Name("a2 a ") };
            Array.Sort(colName);

            Assert.AreEqual("a", colName[0].ToString()); //name without first name
            Assert.AreEqual("a2 a", colName[1].ToString());//space in last word
            Assert.AreEqual("a3 a", colName[2].ToString()); //double space in midle



        }
    }
}
