using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace ExceptionReporting.Zip
{
	internal interface IZipper
	{
		void Zip(string zipFile, IEnumerable<string> files);
	}

	internal class Zipper : IZipper
	{
		public void Zip(string zipFile, IEnumerable<string> files)
		{
			using (var zip = ZipFile.Open(zipFile, ZipArchiveMode.Create))
			{
				foreach (var file in files)
					zip.CreateEntryFromFile(file, Path.GetFileName(file));
			}
		}
	}
}
