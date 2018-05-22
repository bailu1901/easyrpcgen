using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;



public static class FunctionParser
{
	public static List<Function> Parse(string protoFile)
	{
		List<Function> Functions = new List<Function>();
		int num = 0;
		int num2 = 1;
		StringBuilder stringBuilder = new StringBuilder();
		using (TextReader textReader = new StreamReader(protoFile, Encoding.UTF8))
		{
			string text7;
			while ((text7 = textReader.ReadLine()) != null)
			{
				num++;
				text7 = text7.Trim();
				if (text7.Length != 0)
				{
					if (text7.StartsWith("//"))
					{
						stringBuilder.AppendLine(text7.Trim());
					}
					else
					{
						bool flag = text7.IndexOf('=') != -1;
						char[] separator = new char[]
									{
										',',
										'(',
										')',
										'\t',
										' ',
										'=',
										';'
									};
						string[] array = text7.Split(separator);
						List<string> list = new List<string>();
						string[] array2 = array;
						for (int i = 0; i < array2.Length; i++)
						{
							string text8 = array2[i];
							if (text8.Length != 0)
							{
								list.Add(text8);
							}
						}
						Function function = new Function();
						function.Comment = stringBuilder.ToString();
						stringBuilder.Clear();

						if (string.Compare(list[0], "CG", true) == 0)
						{
							function.Direction = CallDirection.Client2GameServer;
						}
						else if (string.Compare(list[0], "GC", true) == 0)
						{
							function.Direction = CallDirection.GameServer2Client;
						}
						else if (string.Compare(list[0], "SS", true) == 0)
						{
							function.Direction = CallDirection.Server2Server;
						}
						else if (string.Compare(list[0], "CS", true) == 0)
						{
							function.Direction = CallDirection.Client2Server;
						}
						else if (string.Compare(list[0], "SC", true) == 0)
						{
							function.Direction = CallDirection.Server2Client;
						}
						else
						{
							function.Direction = CallDirection.Skip;
						}
						

						function.RetType = list[1];
						function.FunctionName = list[2];
						int j;
						for (j = 3; j < list.Count - 1; j += 2)
						{
							Argument item = new Argument
							{
								Type = list[j],
								Name = list[j + 1]
							};
							function.Args.Add(item);
						}
						if (flag)
						{
							if (!int.TryParse(list[j], out function.Id))
							{
								Console.WriteLine("Error at " + num.ToString() + " line.");
								continue;
							}
							num2 = function.Id;
						}
						else
						{
							num2 = (function.Id = num2 + 1);
						}
						function.LineNumber = num;
						Functions.Add(function);
					}
				}
			}
		}

		return Functions;
	}

}

