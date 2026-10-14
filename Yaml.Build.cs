// Tinfoil Engine build script

using Sharpmake;
using System.IO;
using TinfoilBuildTool;

using Configuration = Sharpmake.Project.Configuration;

[BuildModule(typeof(TinfoilProject))]
public class Yaml : TinfoilThirdPartyModuleDependency
{
	public Yaml(ReadOnlyModuleRules rules) : base(rules)
	{
	}

	public override void ConfigureBuild(Configuration config, ITarget target)
	{
		base.ConfigureBuild(config, target);

		if (config.Output == Configuration.OutputType.Lib)
		{
			config.Defines.Add("YAML_CPP_STATIC_DEFINE");
			config.ExportDefines.Add("YAML_CPP_STATIC_DEFINE");
		}

		config.IncludePaths.Add(@"[project.SharpmakeCsPath]/include");

		// C4702: Unreachable code
		// C4244, C4267: Possible data loss
		config.Options.Add(new Options.Vc.Compiler.DisableSpecificWarnings("4702", "4244", "4267"));

		config.SourceFilesBuildExclude.AddRange(Directory.EnumerateFiles(Path.Combine(RootDirectory, "test"), "*", SearchOption.AllDirectories));
		config.SourceFilesBuildExclude.AddRange(Directory.EnumerateFiles(Path.Combine(RootDirectory, "util"), "*", SearchOption.AllDirectories));
	}
}
