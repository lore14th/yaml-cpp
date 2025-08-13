// YAML Tinfoil build script

using Sharpmake;
using System;
using System.IO;
using System.Collections.Generic;

[Sharpmake.Generate]
public class YAML : TinfoilProjectBase
{
	public YAML()
	{
		Name = "YAML";
		SourceRootPath = @"[project.SharpmakeCsPath]/src";
		AdditionalSourceRootPaths.Add(@"[project.SharpmakeCsPath]/include");

		SourceFiles.Add(@"../YAML.Build.cs");
	}

	public override void ConfigureProject(Project.Configuration config, TinfoilTarget target)
	{
		config.Output = Configuration.OutputType.Lib;

		config.Options.Add(Options.Vc.Compiler.CppLanguageStandard.CPP17);
		config.Options.Add(Options.Vc.Compiler.Exceptions.EnableWithSEH);
		config.Options.Add(Options.Vc.General.WindowsTargetPlatformVersion.Latest);
		config.Options.Add(Options.Vc.Librarian.TreatLibWarningAsErrors.Enable);

		// C4702: Unreachable code
		// C4244, C4267: Possible data loss
		config.Options.Add(new Options.Vc.Compiler.DisableSpecificWarnings("4702", "4244", "4267"));

		config.Defines.Add("YAML_CPP_STATIC_DEFINE");
		config.IncludePaths.Add(@"[project.SharpmakeCsPath]/include");
	}
}
