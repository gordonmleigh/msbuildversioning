﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MSBuildVersioning
{
    /// <summary>
    /// Replaces tokens in a string with information from a <c>SvnInfoProvider</c>.
    /// </summary>
    public class SvnVersionTokenReplacer : AbstractVersionTokenReplacer
    {
        public SvnVersionTokenReplacer(SvnInfoProvider infoProvider)
        {
            AddToken("REVNUM", () => infoProvider.GetRevisionNumber().ToString());
            AddToken("REVNUM_MOD", x => (infoProvider.GetRevisionNumber() % x).ToString());
            AddToken("REVNUM_DIV", x => (infoProvider.GetRevisionNumber() / x).ToString());
            AddToken("MIXED", () => infoProvider.IsMixedRevisions() ? "1" : "0");
            AddToken("DIRTY", () => infoProvider.IsWorkingCopyDirty() ? "1" : "0");
            AddToken("SUBDIR", x => infoProvider.GetRepositorySubDirectory(x));
            AddToken("BRANCH", () => infoProvider.GetBranch());
            AddToken("TAG", () => infoProvider.GetTag());
        }
    }
}
