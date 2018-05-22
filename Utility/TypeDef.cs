using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGenerator;


public static class TypeDef
{
	public static Dictionary<string, string> EnumType = new Dictionary<string, string>();

	public static HashSet<string> ValueType_ = new HashSet<string>();
	public static Dictionary<string, string> ProtoType2CppType = new Dictionary<string, string>();

	public static Dictionary<string, string> ProtoType2CSType = new Dictionary<string, string>();

	static TypeDef()
	{
		ProtoType2CppType.Add("string", "std::string");
		ProtoType2CppType.Add("sint32", "int32");
		ProtoType2CppType.Add("sint64", "int64");
		ProtoType2CppType.Add("fixed32", "uint32");
		ProtoType2CppType.Add("fixed64", "uint64");
		ProtoType2CppType.Add("sfixed32", "int32");
		ProtoType2CppType.Add("sfixed64", "int64");
		ProtoType2CSType.Add("int32", "int");
		ProtoType2CSType.Add("int64", "long");
		ProtoType2CSType.Add("uint32", "uint");
		ProtoType2CSType.Add("uint64", "ulong");
		ProtoType2CSType.Add("sint32", "int");
		ProtoType2CSType.Add("sint64", "long");
		ProtoType2CSType.Add("fixed32", "int");
		ProtoType2CSType.Add("fixed64", "long");
		ProtoType2CSType.Add("sfixed32", "int");
		ProtoType2CSType.Add("sfixed64", "long");
		ProtoType2CSType.Add("bytes", "byte[]");
		ValueType_.Add("double");
		ValueType_.Add("float");
		ValueType_.Add("int32");
		ValueType_.Add("int64");
		ValueType_.Add("uint32");
		ValueType_.Add("uint64");
		ValueType_.Add("sint32");
		ValueType_.Add("sint64");
		ValueType_.Add("fixed32");
		ValueType_.Add("fixed64");
		ValueType_.Add("sfixed32");
		ValueType_.Add("sfixed64");
		ValueType_.Add("bool");
		ValueType_.Add("string");
	}

	public static void ParseProto2GetEnum(string fileName)
	{
		using (TextReader textReader = new StreamReader(fileName))
		{
			string text = textReader.ReadToEnd();
			int num2;
			for (int num = text.IndexOf("enum"); num != -1; num = text.IndexOf("enum", num2))
			{
				num2 = text.IndexOf("{", num);
				string text2 = text.Substring(num + 5, num2 - num - 6);
				ValueType_.Add(text2.Trim());
				int num3 = text.IndexOf("=", num2);
				string value = text.Substring(num2 + 1, num3 - num2 - 2).Trim();
				EnumType.Add(text2.Trim(), value);
			}
		}
	}

	public static string ConvertProtoType2CSType(string str)
	{
		string result;
		if (ProtoType2CSType.ContainsKey(str))
		{
			result = ProtoType2CSType[str];
		}
		else
		{
			result = str;
		}
		return result;
	}
}

