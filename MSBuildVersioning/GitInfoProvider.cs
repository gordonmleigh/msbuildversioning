using System;

namespace MSBuildVersioning
{
    /// <summary>
    /// Provides Mercurial information for a particular file path, by executing and scraping
    /// information from the hg.exe command-line program.
    /// </summary>
    public class GitInfoProvider : SourceControlInfoProvider
    {
        private int? revisionNumber;
        private string revisionId;
        private bool? isWorkingCopyDirty;
        private string branch;
        private string tags;

        public override string SourceControlName
        {
            get { return "Git"; }
        }

        public virtual int GetRevisionNumber()
        {
            if (revisionNumber == null)
            {
                InitRevision();
            }
            return (int)revisionNumber;
        }

        public virtual string GetRevisionId()
        {
            if (revisionId == null)
            {
                InitRevision();
            }
            return revisionId;
        }

        private void InitRevision()
        {
            ExecuteCommand("git.exe", "rev-list", output =>
            {
                if (revisionId == null)
                {
                    revisionId = output;
                    revisionNumber = 1;
                }
                else
                {
                    revisionNumber += 1;
                }
            },
            null);
        }

        public virtual bool IsWorkingCopyDirty()
        {
            if (isWorkingCopyDirty == null)
            {
                ExecuteCommand("git.exe", "diff-index --quiet HEAD", (exitCode, error) =>
                {
                    if (exitCode == 0)
                    {
                        isWorkingCopyDirty = false;
                        return false;
                    }
                    else if (exitCode == 1)
                    {
                        isWorkingCopyDirty = true;
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                });
            }
            return (bool)isWorkingCopyDirty;
        }

        public virtual string GetBranch()
        {
            if (branch == null)
            {
                branch = ExecuteCommand("git.exe", "describe --all")[0];
            }
            return branch;
        }

        public virtual string GetTags()
        {
            if (tags == null)
            {
                tags = ExecuteCommand("git.exe", "describe")[0];
            }
            return tags;
        }
    }
}
