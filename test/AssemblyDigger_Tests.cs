using System.Linq;
using System.Reflection;
using ExceptionReporting.Report;
using NUnit.Framework;

namespace Tests.ExceptionReporting
{
	public class AssemblyDigger_Tests
	{
		[Test]
		public void Can_Dig_Assembly_Refs_By_Name()
		{
			var digger = new AssemblyDigger(Assembly.Load("ProExceptionReporter"));
			var refs = digger.GetAssemblyRefs().ToList();

#if NET48
			Assert.That(refs.Select(r => r.Name), Is.SupersetOf(new [] {"System.Core", "System.IO.Compression", "SimpleMapi.NET"}));
#else
			Assert.That(refs.Select(r => r.Name), Is.SupersetOf(new [] {"SimpleMapi.NET"}));
#endif
		}

		[Test]
		public void Can_Memoize_List()
		{
			Assert.That(new AssemblyDigger(Assembly.GetExecutingAssembly()).GetAssemblyRefs(), 
				Is.SameAs(new AssemblyDigger(Assembly.GetExecutingAssembly()).GetAssemblyRefs()));
		}
		
		[Test]
		public void Can_Prevent_Memoize_When_Created_With_Different_Assembly()
		{
			Assert.That(new AssemblyDigger(Assembly.Load("ProExceptionReporter")).GetAssemblyRefs(),
				Is.Not.EqualTo(new AssemblyDigger(Assembly.GetExecutingAssembly()).GetAssemblyRefs()));
		}
	}
}