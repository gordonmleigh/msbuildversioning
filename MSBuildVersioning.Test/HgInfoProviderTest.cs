using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace MSBuildVersioning.Test
{
    [TestFixture]
    public class HgInfoProviderTest
    {
        public HgInfoProvider Hg1
        {
            get { return new HgInfoProvider() { Path = @"C:\Temp\TestRepositories\Hg1" }; }
        }

        public HgInfoProvider Hg2
        {
            get { return new HgInfoProvider() { Path = @"C:\Temp\TestRepositories\Hg2" }; }
        }

        public HgInfoProvider Hg3
        {
            get { return new HgInfoProvider() { Path = @"C:\Temp\TestRepositories\Hg3" }; }
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
            Assert.AreEqual("1024d08c6b37", Hg1.GetRevisionId());
            Assert.AreEqual("bf82f571c792", Hg2.GetRevisionId());
            Assert.AreEqual("80de7a096ed2", Hg3.GetRevisionId());
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
