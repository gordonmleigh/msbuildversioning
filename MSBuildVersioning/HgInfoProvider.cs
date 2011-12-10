using System;

namespace MSBuildVersioning
{
    /// <summary>
    /// Provides Mercurial information for a particular file path, by executing and scraping
    /// information from the hg.exe command-line program.
    /// </summary>
    public class HgInfoProvider : SourceControlInfoProvider
    {
        private int? revisionNumber;
        private string revisionId;
        private string longRevisionId;
        private bool? isWorkingCopyDirty;
        private string branch;
        private string tags;

        public override string SourceControlName
        {
            get { return "Mercurial"; }
        }

        public virtual int GetRevisionNumber()
        {
            if (revisionNumber == null)
            {
                revisionNumber = int.Parse(ExecuteRevisionCommand("identify -n"));
            }
            return (int)revisionNumber;
        }

        public virtual string GetRevisionId()
        {
            if (revisionId == null)
            {
                revisionId = ExecuteRevisionCommand("identify -i");
            }
            return revisionId;
        }

        public virtual string GetLongRevisionId()
        {
            if (longRevisionId == null)
            {
                longRevisionId = ExecuteRevisionCommand("identify -i --debug");
            }
            return longRevisionId;
        }

        private string ExecuteRevisionCommand(string hgArguments)
        {
            string result = ExecuteCommand("hg.exe", hgArguments)[0];

            if (result.Contains("+"))
            {
                isWorkingCopyDirty = true;
                result = result.Substring(0, result.IndexOf("+"));
            }
            else
            {
                isWorkingCopyDirty = false;
            }

            return result;
        }

        public virtual bool IsWorkingCopyDirty()
        {
            if (isWorkingCopyDirty == null)
            {
                GetRevisionNumber();
            }
            return (bool)isWorkingCopyDirty;
        }

        public virtual string GetBranch()
        {
            if (branch == null)
            {
                branch = ExecuteCommand("hg.exe", "identify -b")[0];
            }
            return branch;
        }

        public virtual string GetTags()
        {
            if (tags == null)
            {
                tags = ExecuteCommand("hg.exe", "identify -t")[0];
            }
            return tags;
        }
    }
}
