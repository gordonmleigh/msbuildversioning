using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SampleInc.AwesomeApp
{
    public static class BuildInfo
    {
        public static DateTime BuildDate
        {
            get { return DateTime.Parse("$DATE$"); }
        }

        public static string RevisionId
        {
            get { return "$REVID$"; }
        }

        public static string BranchName
        {
            get { return "$BRANCH$"; }
        }

        public static string TagNames
        {
            get { return "$TAGS$"; }
        }
    }
}
