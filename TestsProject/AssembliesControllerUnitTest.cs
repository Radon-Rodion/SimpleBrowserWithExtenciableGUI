using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPP_7;

namespace TestsProject
{
    [TestClass]
    public class AssembliesControllerUnitTest
    {
        AssembliesController controller;
        [TestMethod]
        public void TestConstructor()
        {
            controller = new AssembliesController("\\");
            Assert.IsTrue(controller.UserControlsQueue.Count==0, "Control elements queue is not ready!");
        }

        private void CreateControllerIfNecessary()
        {
            if(controller == null) controller = new AssembliesController("\\");
        }

        [TestMethod]
        public void TestFileExtencionsChecking()
        {
            CreateControllerIfNecessary();
            Assert.IsTrue(controller.CheckFileExtension("someFile.txt", ".txt"), "Invalid checking .txt extension!");
            Assert.IsFalse(controller.CheckFileExtension("someFile", ".txt"), "Invalid checking .txt extension where it is abcent!");
            Assert.IsTrue(controller.CheckFileExtension("someFile.dll", ".dll"), "Invalid checking .dll extension!");
        }

        [TestMethod]
        public void TestAssembliesChecking()
        {
            CreateControllerIfNecessary();
            controller.CheckAssemblies();
            Assert.IsTrue(controller.UserControlsQueue.Count == 2, "Assemblies are not loaded!");
        }

        [TestMethod]
        public void TestNoAssembliesChecking()
        {
            controller = new AssembliesController("D:\\");
            controller.CheckAssemblies();
            Assert.IsTrue(controller.UserControlsQueue.Count == 0, "Unexpected assemblies loaded!");
        }
    }
}
