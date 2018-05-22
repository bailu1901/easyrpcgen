using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static partial class Utility
{
	public static string CreateCSharpComment(string space, string comment)
	{
		string[] array = comment.Split(new string[]
		{
			Environment.NewLine
		}, StringSplitOptions.None);
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(space + "/// <summary>");
		string[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			string text = array2[i];
			if (!string.IsNullOrEmpty(text.Trim()))
			{
				stringBuilder.AppendLine(space + "/// " + text.TrimStart(new char[]
				{
					'/'
				}));
			}
		}
		stringBuilder.AppendLine(space + "/// </summary>");
		return stringBuilder.ToString();
	}
}

