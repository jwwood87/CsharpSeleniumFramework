

using NUnit.Framework;

namespace UdemyFramework.Common
{
    [SetUpFixture]
    public static class NamespaceSetup
    {
        public static void ExecuteForCreatingReportsNamespce(TestContext testContxt)
        {
            Reporter.StartReporter();
        }
    }
}
