using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public static class Generator
{
	
	public static bool Gen(string[] args)
	{
		string commandStr = "command:\nserverFuncDefFilePath clientFuncDefFilePath protoDir protoExe serverGenDir clientGenDir";
		if (6 != args.Count())
		{
			Console.WriteLine("Args Error");
			Console.WriteLine(commandStr);
			var key = Console.ReadKey(true).Key;

			return false;
		}

		for (int i=0; i<args.Count();i++)
		{
			var s = args[i];
			args[i] = s.Replace("\\", "/");
		}

		//服务器函数定义文件
		var serverFuncDefFilePath = args[0];
		//客户端函数定义文件
		var clientFuncDefFilePath = args[1];
		//proto 文件目录
		var protoExe = args[2];
		//proto 文件目录
		var protoDir = args[3];
		//服务器生成目录
		var serverGenDir = args[4];
		//客户端生成目录
		var clientGenDir = args[5];

		if (!File.Exists(serverFuncDefFilePath))
		{
			Console.WriteLine(serverFuncDefFilePath + " do not exist.");
			var key = Console.ReadKey(true).Key;
			return false;
		}
		Console.WriteLine("serverFuncDefFilePath=" + serverFuncDefFilePath);
		
		if (!File.Exists(clientFuncDefFilePath))
		{
			Console.WriteLine(clientFuncDefFilePath + " do not exist.");
			var key = Console.ReadKey(true).Key;
			return false;
		}
		Console.WriteLine("clientFuncDefFilePath=" + clientFuncDefFilePath);

		if (!Directory.Exists(protoDir))
		{
			Console.WriteLine(protoDir + " do not exist.");
			var key = Console.ReadKey(true).Key;
			return false;
		}
		Console.WriteLine("protoDir=" + protoDir);

		if (!File.Exists(protoExe))
		{
			Console.WriteLine(protoExe + " do not exist.");
			var key = Console.ReadKey(true).Key;
			return false;
		}
		Console.WriteLine("protoExe=" + protoExe);

		if (!Directory.Exists(serverGenDir))
		{
			Console.WriteLine(serverGenDir + " do not exist.");
			var key = Console.ReadKey(true).Key;
			return false;
		}
		Console.WriteLine("serverGenDir=" + serverGenDir);

		if (!Directory.Exists(clientGenDir))
		{
			Console.WriteLine(clientGenDir + " do not exist.");
			var key = Console.ReadKey(true).Key;
			return false;
		}
		Console.WriteLine("clientGenDir=" + clientGenDir);

		var STRING_S2C = "ServerService";
		var STRING_C2S = "ClientService";
		var CSHARP_POSTFIX = ".cs";

		UTF8Encoding encoding = new UTF8Encoding(false);
		var serverFuncs = FunctionParser.Parse(serverFuncDefFilePath);
		var clientFuncs = FunctionParser.Parse(clientFuncDefFilePath);

		var className = "";
		{//Server
			var interfaceName = "IServer";
			className = interfaceName;
			using (TextWriter textWriter5 = new StreamWriter(Path.Combine(serverGenDir, className+CSHARP_POSTFIX), false, encoding))
			{
				CSharpCodeGenerator.ServerInterface(textWriter5,className, STRING_S2C, serverFuncs);
			}

			className = "ServerInterfaceReaction";
			using (TextWriter textWriter6 = new StreamWriter(Path.Combine(serverGenDir, className+CSHARP_POSTFIX), false, encoding))
			{
				CSharpCodeGenerator.ServerInterfaceReaction(textWriter6, className, interfaceName,STRING_S2C, serverFuncs);
			}

			className = "ClientFunctions";
			using (TextWriter textWriter7 = new StreamWriter(Path.Combine(serverGenDir, className+CSHARP_POSTFIX), false, encoding))
			{
				CSharpCodeGenerator.ClientFunctions(textWriter7,className, STRING_C2S, clientFuncs);
			}

		}

		{//Client
			var interfaceName = "IClient";
			className = interfaceName;
			using (TextWriter ClientInterfacetextWriter = new StreamWriter(Path.Combine(clientGenDir, className+CSHARP_POSTFIX), false, encoding))
			{
				CSharpCodeGenerator.ClientInterface(ClientInterfacetextWriter,className, STRING_C2S, clientFuncs);
			}

			className = "ClientInterfaceReaction";
			using (TextWriter ClientInterfaceReactiontextWriter = new StreamWriter(Path.Combine(clientGenDir, className+CSHARP_POSTFIX), false, encoding))
			{
				CSharpCodeGenerator.ClientInterfaceReaction(ClientInterfaceReactiontextWriter, className, interfaceName, STRING_C2S, clientFuncs);
			}

			className = "ServerFunctions";
			using (TextWriter textWriter8 = new StreamWriter(Path.Combine(clientGenDir, className+CSHARP_POSTFIX), false, encoding))
			{
				CSharpCodeGenerator.ServerFunctions(textWriter8,className, STRING_S2C, serverFuncs);
			}
		}



		using (TextWriter textWriter = new StreamWriter(Path.Combine(protoDir , STRING_S2C + "Proto.proto"), false, encoding))
		{
			CreateProtoFile.GenerateProto(textWriter, STRING_S2C, serverFuncs);
		}
		using (TextWriter textWriter = new StreamWriter(Path.Combine(protoDir, STRING_C2S + "Proto.proto"), false, encoding))
		{
			CreateProtoFile.GenerateProto(textWriter, STRING_C2S, clientFuncs);
		}

		CreateProtoFile.GenerateCSCode(protoExe,protoDir, clientGenDir);
		CreateProtoFile.GenerateCSCode(protoExe,protoDir, serverGenDir);

		return true;
	}


}

