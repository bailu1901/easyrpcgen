using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;


public static partial class Utility
{
	public static string GetArgType(string ClassName, Function func)
	{
		string text = string.Concat(new string[]
			{
				"__RPC_",
				ClassName,
				"_",
				func.FunctionName,
				"_ARG_"
			});
		foreach (Argument current in func.Args)
		{
			string text2 = text;
			text = string.Concat(new string[]
				{
					text2,
					current.Type,
					"_",
					current.Name,
					"_"
				});
		}
		return text + "_";
	}

	public static string GetRetType(string ClassName,Function func)
	{
		return string.Concat(new string[]
			{
				"__RPC_",
				ClassName,
				"_",
				func.FunctionName,
				"_RET_",
				func.RetType,
				"__"
			});
	}

	public static string GetAsCSArgument(Function func)
	{
		string text = "";
		for (int i = 0; i < func.Args.Count - 1; i++)
		{
			string text2 = text;
			text = string.Concat(new string[]
				{
					text2,
					TypeDef.ConvertProtoType2CSType(func.Args[i].Type),
					" ",
					func.Args[i].Name,
					", "
				});
		}
		return text + TypeDef.ConvertProtoType2CSType(func.Args[func.Args.Count - 1].Type) + " " + func.Args[func.Args.Count - 1].Name;
	}

	public static string GetAsCSInitArg(Function func, string arg, string att)
	{
		string text = "";
		for (int i = 0; i < func.Args.Count; i++)
		{
			string text2 = text;
			text = string.Concat(new string[]
				{
					text2,
					att,
					arg,
					".",
					func.Args[i].Name.Pascalize(),
					"=",
					func.Args[i].Name,
					";",
					Environment.NewLine
				});
		}
		return text;
	}

	public static string CheckArgsCS(Function func, string arg, string att)
	{
		string text = "";
		for (int i = 0; i < func.Args.Count; i++)
		{
			string text2 = text;
			if (!TypeDef.ValueType_.Contains(func.Args[i].Type))
			{
				text = string.Concat(new string[]
					{
						text2,
						att,
						"if (",
						arg,
						".",
						func.Args[i].Name.Pascalize(),
						" == null) throw new ArgumentNullException(\"",
						func.Args[i].Name.Pascalize(),
						" is null.\");",
						Environment.NewLine
					});
			}
		}
		return text;
	}

	public static string GetAsCSRealArg(Function func, string arg)
	{
		string text = "";
		for (int i = 0; i < func.Args.Count - 1; i++)
		{
			string text2 = text;
			text = string.Concat(new string[]
				{
					text2,
					arg,
					".",
					func.Args[i].Name.Pascalize(),
					", "
				});
		}
		return text + arg + "." + func.Args[func.Args.Count - 1].Name.Pascalize();
	}

	public static string GetAsCSRealArg(Function func)
	{
		string text = "";
		for (int i = 0; i < func.Args.Count - 1; i++)
		{
			string str = text;
			text = str + func.Args[i].Name + ", ";
		}
		return text + func.Args[func.Args.Count - 1].Name;
	}

	public static string FuncCallString(CallDirection direction)
	{
		string result;
		switch (direction)
		{
			case CallDirection.Client2GameServer:
				result = "CG";
				break;
			case CallDirection.GameServer2Client:
				result = "GC";
				break;
			case CallDirection.Server2Server:
				result = "SS";
				break;
			case CallDirection.Client2Server:
				result = "CS";
				break;
			case CallDirection.Server2Client:
				result = "SC";
				break;
			case CallDirection.Skip:
				result = "SKIP";
				break;
			default:
				throw new ArgumentOutOfRangeException("direction");
		}
		return result;
	}

	public static void GenerateList(TextWriter writer, List<Function> Functions)
	{
		foreach (Function current in Functions)
		{
			writer.WriteLine("{3} {0} {1} //{2}", new object[]
				{
					current.Id,
					current.FunctionName,
					current.Comment.Replace(Environment.NewLine, ""),
					current.Direction
				});
		}
	}

	public static void ClearFolder(string dir,string filter=null)
	{
		if (null != filter)
		{
			DirectoryInfo dirInfo = new DirectoryInfo(dir);
			var files = dirInfo.GetFileSystemInfos(filter, SearchOption.AllDirectories);
			foreach (var file in files)
			{
				File.Delete(file.FullName);
			}
			return;
		}
		foreach (string d in Directory.GetFileSystemEntries(dir))
		{
			if (File.Exists(d))
			{
				FileInfo fi = new FileInfo(d);
				if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
					fi.Attributes = FileAttributes.Normal;
				File.Delete(d);//直接删除其中的文件  
			}
			else
			{
				DirectoryInfo d1 = new DirectoryInfo(d);
				if (d1.GetFiles().Length != 0)
				{
					ClearFolder(d1.FullName);////递归删除子文件夹
				}
				Directory.Delete(d);
			}
		}
	}  
}

