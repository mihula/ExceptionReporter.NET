using System;
using System.Diagnostics;
using System.Reflection;
using ExceptionReporting;
using NUnit.Framework;

namespace Tests.ExceptionReporting
{
	public class ReportGenerator_AppVersion_Tests
	{
		private static Assembly TestAssembly => Assembly.GetExecutingAssembly();

		private static ExceptionReportInfo InfoWith(AssemblyVersionType type)
		{
			return new ExceptionReportInfo
			{
				MainException = new Exception(),
				AppAssembly = TestAssembly,
				AppVersionType = type
			};
		}

		[Test]
		public void Default_returns_assembly_version()
		{
			var info = new ExceptionReportInfo
			{
				MainException = new Exception(),
				AppAssembly = TestAssembly
				// AppVersionType defaults to AssemblyVersion
			};
			new ReportGenerator(info);

			Assert.That(info.AppVersion, Is.EqualTo(TestAssembly.GetName().Version.ToString()));
		}

		[Test]
		public void FileVersion_returns_file_version()
		{
			var info = InfoWith(AssemblyVersionType.FileVersion);
			new ReportGenerator(info);

			var expected = FileVersionInfo.GetVersionInfo(TestAssembly.Location).FileVersion ?? string.Empty;
			Assert.That(info.AppVersion, Is.EqualTo(expected));
		}

		[Test]
		public void InformationalVersion_returns_informational_version()
		{
			var info = InfoWith(AssemblyVersionType.InformationalVersion);
			new ReportGenerator(info);

			var expected = TestAssembly
				.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
				?.InformationalVersion ?? string.Empty;
			Assert.That(info.AppVersion, Is.EqualTo(expected));
		}

		[Test]
		public void Pre_set_AppVersion_is_not_overwritten()
		{
			var info = new ExceptionReportInfo
			{
				MainException = new Exception(),
				AppAssembly = TestAssembly,
				AppVersion = "custom-1.2.3",
				AppVersionType = AssemblyVersionType.FileVersion
			};
			new ReportGenerator(info);

			Assert.That(info.AppVersion, Is.EqualTo("custom-1.2.3"));
		}
	}
}
