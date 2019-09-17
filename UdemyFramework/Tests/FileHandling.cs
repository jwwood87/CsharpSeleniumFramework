using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace UdemyFramework.Tests
{
    [TestFixture]
    internal class FileHandling : BaseTest
    {
        string FileName = "JohnBoy04030732.txt";
        string Source = @"C:\temp\Johnny";
        string Destination = @"C:\temp\Lori";

        [Test]
        [Author("JohnWood")]
        [Category("Fill-out forms")]
        [Description("This is a test description")]
        public void DeleteFile()
        {
            string DeleteFileName = Path.Combine(Destination, FileName);
            if (File.Exists(DeleteFileName))
            {
                try
                {
                    File.Delete(DeleteFileName);
                }
                catch (IOException e)
                {
                    System.Console.WriteLine("The file may be open by another process" + "\n" + e.Message);
                    return;
                }
            }
        }

        [Test]
        [Author("JohnWood")]
        [Category("File handling")]
        [Description("Can C# copy a file from one folder to another?")]
        public void CopyFile()
        {
            string sourceFile =  Path.Combine(Source, FileName);
            string destinationFile = Path.Combine(Destination, FileName);
            File.Copy(sourceFile, destinationFile, false);
        }

        [Test]
        [Author("JohnWood")]
        [Category("File handling")]
        [Description("Can C# create a directory?")]
        public void DirectoryFile()
        {
            string name = string.Format("{0:MMHHmmss}", System.DateTime.Now);
            string sourceFile = Path.Combine(Source, FileName);
            string destinationFile = Path.Combine(Destination, FileName);
            Directory.CreateDirectory(@"C:\temp\NewFolder" + name);
            IEnumerable<string> salmons = new List<string>();
            var jojo = Directory.EnumerateDirectories(@"C:\Users\jwWoo");
            salmons = jojo;
        }
    }
}
