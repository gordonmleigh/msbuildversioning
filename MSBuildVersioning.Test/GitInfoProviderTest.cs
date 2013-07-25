using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace MSBuildVersioning.Test
{
    [TestFixture]
    public class GitInfoProviderTest
    {
        private const string TestRepositoriesPath = @"..\..\..\TestRepositories";

        [TestFixtureSetUp]
        public void Init()
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "powershell.exe";
                process.StartInfo.Arguments = @"-ExecutionPolicy Bypass .\build-git.ps1";
                process.StartInfo.WorkingDirectory = TestRepositoriesPath;

                process.Start();
                process.WaitForExit();
            }
        }

        [TestFixtureTearDown]
        public void CleanUp()
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "powershell.exe";
                process.StartInfo.Arguments = @"-ExecutionPolicy Bypass .\clean-git.ps1";
                process.StartInfo.WorkingDirectory = TestRepositoriesPath;

                process.Start();
                process.WaitForExit();
            }
        }

        public GitInfoProvider Git1
        {
            get { return new GitInfoProvider() { Path = Path.Combine(TestRepositoriesPath, "Git1") }; }
        }

        public GitInfoProvider Git2
        {
            get { return new GitInfoProvider() { Path = Path.Combine(TestRepositoriesPath, "Git2") }; }
        }

        public GitInfoProvider Git3
        {
            get { return new GitInfoProvider() { Path = Path.Combine(TestRepositoriesPath, "Git3") }; }
        }

        [Test]
        public void GetRevisionNumberTest()
        {
            Assert.AreEqual(2, Git1.GetRevisionNumber());
            Assert.AreEqual(4, Git2.GetRevisionNumber());
            Assert.AreEqual(1, Git3.GetRevisionNumber());
        }

        [Test]
        public void GetRevisionIdTest()
        {
            Assert.AreEqual("781826a", Git1.GetRevisionId());
            Assert.AreEqual("1392da1", Git2.GetRevisionId());
            Assert.AreEqual("d47de83", Git3.GetRevisionId());
        }

        [Test]
        public void GetLongRevisionIdTest()
        {
            Assert.AreEqual("781826aeadce6c4f3a031f15b06353491b44e7eb", Git1.GetLongRevisionId());
            Assert.AreEqual("1392da16846f966d4876bfeb6f85732696176e8d", Git2.GetLongRevisionId());
            Assert.AreEqual("d47de83fc008db4cb526d27e78804ee46282a01f", Git3.GetLongRevisionId());
        }

        [Test]
        public void GetRevisionIds_ShortThenLong()
        {
            GitInfoProvider provider = Git1;
            Assert.AreEqual("781826a", provider.GetRevisionId());
            Assert.AreEqual("781826aeadce6c4f3a031f15b06353491b44e7eb", provider.GetLongRevisionId());
        }

        [Test]
        public void IsWorkingCopyDirtyTest()
        {
            Assert.IsFalse(Git1.IsWorkingCopyDirty());
            Assert.IsTrue(Git2.IsWorkingCopyDirty());
            Assert.IsTrue(Git3.IsWorkingCopyDirty());
        }

        [Test]
        public void GetBranchTest()
        {
            Assert.AreEqual("master", Git1.GetBranch());
            Assert.AreEqual("formal", Git2.GetBranch());
            Assert.AreEqual("", Git3.GetBranch());
        }

        [Test]
        public void GetTagsTest()
        {
            Assert.AreEqual("", Git1.GetTags());
            Assert.AreEqual("formal-1.0", Git2.GetTags());
            Assert.AreEqual("", Git3.GetTags());
        }
    }
}
