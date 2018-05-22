using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static partial class Utility
{
	public static void CopyFile(string inDir,string fileFilter, string outDir)
	{
		DirectoryInfo protoDirInfo = new DirectoryInfo(inDir);

		var fileInfos = protoDirInfo.GetFileSystemInfos(fileFilter, SearchOption.AllDirectories);

		foreach (var info in fileInfos)
		{
			File.Copy(info.FullName,Path.Combine(outDir,info.Name));
		}
	}
}
