using Microsoft.VisualStudio.TestTools.UnitTesting;
using CinemaProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CinemaProgram.Tests
{
    [TestClass()]
    public class InterfaceTests
    {
        [TestMethod()]
        public void newCinemaTest()
        {
            Interface interfaceObject = new Interface();
            Hall hall = new Hall(2, new Seat[2][]);
            ArrayList halls = new ArrayList();
            halls.Add(hall);
            interfaceObject.newCinema("CinemaName", halls);

            Assert.IsNotNull(interfaceObject.getCinema("CinemaName"));
        }

        [TestMethod()]
        public void RegisterTest()
        {
            UserJsonHandler.SaveUser("TestUser", "TestPassword", "20");
            Assert.IsTrue( UserJsonHandler.FindUser("TestUser", "TestPassword"));
        }
    }
}