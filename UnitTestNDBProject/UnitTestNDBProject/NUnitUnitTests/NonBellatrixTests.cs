﻿using NUnit.Framework;
namespace NUnitUnitTests
{
    // A class that contains NUnit unit tests. (Required)
    [TestFixture]
    public class NonBellatrixTests
    {
        [OneTimeSetUp]
        public void ClassInit()
        {
            // Executes once for the test class. (Optional)
        }
        [SetUp]
        public void TestInit()
        {
            // Runs before each test. (Optional)
        }
        [Test, Category("Smoke")]
        public void TestMethod()
        {
        }
        [TearDown]
        public void TestCleanup()
        {
            // Runs after each test. (Optional)
        }
        [OneTimeTearDown]
        public void ClassCleanup()
        {
            // Runs once after all tests in this class are executed. (Optional)
            // Not guaranteed that it executes instantly after all tests from the class.
        }
    }

}
// A SetUpFixture outside of any namespace provides SetUp and TearDown for the entire assembly.
[SetUpFixture]
public class MySetUpClass
{
    [OneTimeSetUp]
    public void RunBeforeAnyTests()
    {
        // Executes once before the test run. (Optional)
    }
    [OneTimeTearDown]
    public void RunAfterAnyTests()
    {
        // Executes once after the test run. (Optional)
    }
}
