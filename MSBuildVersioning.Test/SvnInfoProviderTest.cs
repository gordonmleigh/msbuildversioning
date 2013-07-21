using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace MSBuildVersioning.Test
{
    [TestFixture]
    public class SvnInfoProviderTest
    {
        private const string TestRepositoriesPath = @"..\..\..\TestRepositories";

        [TestFixtureSetUp]
        public void Init()
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "powershell.exe";
                process.StartInfo.Arguments = @"-ExecutionPolicy Bypass .\build-svn.ps1";
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
                process.StartInfo.Arguments = @"-ExecutionPolicy Bypass .\clean-svn.ps1";
                process.StartInfo.WorkingDirectory = TestRepositoriesPath;

                process.Start();
                process.WaitForExit();
            }
        }

        public SvnInfoProvider SvnWC1
        {
            get { return new SvnInfoProvider() { Path = Path.Combine(TestRepositoriesPath, "SvnWC1") }; }
        }

        public SvnInfoProvider SvnWC2
        {
            get { return new SvnInfoProvider() { Path = Path.Combine(TestRepositoriesPath, "SvnWC2") }; }
        }

        [Test]
        public void GetRevisionNumberTest()
        {
            Assert.AreEqual(6, SvnWC1.GetRevisionNumber());
            Assert.AreEqual(5, SvnWC2.GetRevisionNumber());
        }

        [Test]
        public void IsMixedRevisionsTest()
        {
            Assert.IsTrue(SvnWC1.IsMixedRevisions());
            Assert.IsFalse(SvnWC2.IsMixedRevisions());
        }

        [Test]
        public void IsWorkingCopyDirtyTest()
        {
            Assert.IsFalse(SvnWC1.IsWorkingCopyDirty());
            Assert.IsTrue(SvnWC2.IsWorkingCopyDirty());
        }

        [Test]
        public void GetRepositoryUrlTest()
        {
            string repoUrl = "file:///" + Path.GetFullPath(TestRepositoriesPath).Replace('\\', '/') + "/SvnRepo";

            Assert.AreEqual(repoUrl, SvnWC1.GetRepositoryUrl());
            Assert.AreEqual(repoUrl + "/branches/beef", SvnWC2.GetRepositoryUrl());
        }

        [Test]
        public void GetRepositoryRootTest()
        {
            string repoUrl = "file:///" + Path.GetFullPath(TestRepositoriesPath).Replace('\\', '/') + "/SvnRepo";

            Assert.AreEqual(repoUrl, SvnWC1.GetRepositoryRoot());
            Assert.AreEqual(repoUrl, SvnWC2.GetRepositoryRoot());
        }

        [Test]
        public void GetRepositoryPathTest()
        {
            Assert.AreEqual("/", SvnWC1.GetRepositoryPath());
            Assert.AreEqual("/branches/beef", SvnWC2.GetRepositoryPath());
        }

        [Test]
        public void GetBranchTest()
        {
            Assert.AreEqual("", SvnWC1.GetBranch());
            Assert.AreEqual("beef", SvnWC2.GetBranch());
        }

        [Test]
        public void GetTagTest()
        {
            Assert.AreEqual("", SvnWC1.GetTag());
            Assert.AreEqual("", SvnWC2.GetTag());
        }
    }
}
