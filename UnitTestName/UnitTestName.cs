using System;
using System.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorter;

namespace UnitTestName
{
    [TestClass]
    public class UnitTestName
    {
        [TestMethod]
        public void TestMethod1()
        {

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
        public void TestLastNameAndFirstNameWithUnuseSpace()
        {

            //test 1
            var name = new Name(" Abc a "); //unused space in head & tail
            var firstName = name.GetFirstName();
            var lastName = name.GetLastName();
            var fullName = name.FullName;
            Assert.AreEqual("Abc", firstName);
            Assert.AreEqual("a", lastName);
            Assert.AreEqual("Abc a", fullName);

            //test 2
            name.FullName = " xx yy  zz"; //unused space in middle
            firstName = name.GetFirstName();
            lastName = name.GetLastName();
            fullName = name.FullName;
            Assert.AreEqual("xx yy", firstName);
            Assert.AreEqual("zz", lastName);
            Assert.AreEqual("xx yy zz", fullName);




        }
    }
}
