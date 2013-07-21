﻿using System;
using System.IO;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace MSBuildVersioning
{
    /// <summary>
    /// MSBuild task that reads a template file, replaces tokens in the file content, and then
    /// writes the content to a destination file.
    /// </summary>
    public class VersionFile : Task
    {
        private VersionTokenReplacer tokenReplacer;

        public VersionFile()
        {
            this.tokenReplacer = new VersionTokenReplacer();
        }

        public VersionFile(VersionTokenReplacer processor)
        {
            this.tokenReplacer = processor;
        }

        [Required]
        public string TemplateFile { get; set; }

        [Required]
        public string DestinationFile { get; set; }

        public bool IgnoreToolNotFound { get; set; }

        public string ToolPath { get; set; }

        public override bool Execute()
        {
            try
            {
                // Read content of the template file
                string content = File.ReadAllText(TemplateFile);

                // Replace tokens in the template file content with version info
                if (tokenReplacer.SourceControlInfoProvider != null)
                {
                    tokenReplacer.SourceControlInfoProvider.IgnoreToolNotFound = IgnoreToolNotFound;
                    tokenReplacer.SourceControlInfoProvider.Path = ToolPath;
                }
                content = tokenReplacer.Replace(content);

                // Write the destination file, only if it needs to be updated
                if (!File.Exists(DestinationFile) || File.ReadAllText(DestinationFile) != content)
                {
                    File.WriteAllText(DestinationFile, content);
                }

                return true;
            }
            catch (BuildErrorException e)
            {
                Log.LogError(e.Message);
                return false;
            }
        }
    }
}
