using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace SampleInc.AwesomeApp
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();

            versionValueLabel.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            dateValueLabel.Text = BuildInfo.BuildDate.ToShortDateString();

            if (string.IsNullOrEmpty(BuildInfo.TagNames))
            {
                buildValueLabel.Text = string.Format("{0} ({1})",
                    BuildInfo.RevisionId, BuildInfo.BranchName);
            }
            else
            {
                buildValueLabel.Text = string.Format("{0} ({1}, {2})",
                    BuildInfo.RevisionId, BuildInfo.BranchName, BuildInfo.TagNames);
            }
        }
    }
}
