using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;

public enum CallDirection
{
	Client2GameServer,
	GameServer2Client,
	Server2Server,
	Client2Server,
	Server2Client,
	Skip,
	
}

public class Argument
{
	public string Name;

	public string Type;
}

public class Function
{
	public List<Argument> Args = new List<Argument>();

	public CallDirection Direction;

	public string FunctionName;

	public int Id;

	public int LineNumber;

	public string RetType;

	public string Comment;

	public string ExceptionHandle;

	public string ArgString(string prefix=null)
	{
	
		string ret = "";

		if (null==prefix)
		{
			for (int i = 0; i < Args.Count; i++)
			{
				var arg = Args[i];
				ret += TypeDef.ConvertProtoType2CSType(arg.Type) + " " + arg.Name.ToLower();
				if (i != Args.Count - 1)
				{
					ret += ",";
				}
			}
		}
		else
		{
			for (int i = 0; i < Args.Count; i++)
			{
				var arg = Args[i];
				var temp = ("" == prefix) ? arg.Name.ToLower() : (prefix + "." + arg.Name.Pascalize());
				ret += temp;
				if (i != Args.Count - 1)
				{
					ret += ",";
				}
			}
		}

		return ret;
	}
}

