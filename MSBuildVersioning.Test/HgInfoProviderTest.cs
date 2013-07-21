using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace MSBuildVersioning.Test
{
    [TestFixture]
    public class HgInfoProviderTest
    {
        private const string TestRepositoriesPath = @"..\..\..\TestRepositories";

        [TestFixtureSetUp]
        public void Init()
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "build-hg.cmd";
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
                process.StartInfo.FileName = "clean-hg.cmd";
                process.StartInfo.WorkingDirectory = TestRepositoriesPath;

                process.Start();
                process.WaitForExit();
            }
        }

        public HgInfoProvider Hg1
        {
            get { return new HgInfoProvider() { Path = Path.Combine(TestRepositoriesPath, "Hg1") }; }
        }

        public HgInfoProvider Hg2
        {
            get { return new HgInfoProvider() { Path = Path.Combine(TestRepositoriesPath, "Hg2") }; }
        }

        public HgInfoProvider Hg3
        {
            get { return new HgInfoProvider() { Path = Path.Combine(TestRepositoriesPath, "Hg3") }; }
        }

        [Test]
        public void GetRevisionNumberTest()
        {
            Assert.AreEqual(2, Hg1.GetRevisionNumber());
            Assert.AreEqual(4, Hg2.GetRevisionNumber());
            Assert.AreEqual(2, Hg3.GetRevisionNumber());
        }

        [Test]
        public void GetRevisionIdTest()
        {
            Assert.AreEqual("69f3210533ce", Hg1.GetRevisionId());
            Assert.AreEqual("d391553df0c3", Hg2.GetRevisionId());
            Assert.AreEqual("0e144a435697", Hg3.GetRevisionId());
        }

        [Test]
        public void GetLongRevisionIdTest()
        {
            Assert.AreEqual("69f3210533ceb435d065012a90e4fbb591df83bd", Hg1.GetLongRevisionId());
            Assert.AreEqual("d391553df0c385ff61e4df733d57ff44b8203380", Hg2.GetLongRevisionId());
            Assert.AreEqual("0e144a435697975e632dc78b9e1f4c7678619cdb", Hg3.GetLongRevisionId());
        }

        [Test]
        public void GetRevisionIds_ShortThenLong()
        {
            HgInfoProvider provider = Hg1;
            Assert.AreEqual("69f3210533ce", provider.GetRevisionId());
            Assert.AreEqual("69f3210533ceb435d065012a90e4fbb591df83bd", provider.GetLongRevisionId());
        }

        [Test]
        public void IsWorkingCopyDirtyTest()
        {
            Assert.IsFalse(Hg1.IsWorkingCopyDirty());
            Assert.IsTrue(Hg2.IsWorkingCopyDirty());
            Assert.IsTrue(Hg3.IsWorkingCopyDirty());
        }

        [Test]
        public void GetBranchTest()
        {
            Assert.AreEqual("default", Hg1.GetBranch());
            Assert.AreEqual("formal", Hg2.GetBranch());
            Assert.AreEqual("default", Hg3.GetBranch());
        }

        [Test]
        public void GetTagsTest()
        {
            Assert.AreEqual("", Hg1.GetTags());
            Assert.AreEqual("formal-1.0", Hg2.GetTags());
            Assert.AreEqual("tip", Hg3.GetTags());
        }
    }
}
