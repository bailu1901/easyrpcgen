using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public static class Generator3
{
	
	public static bool Gen(string[] args)
	{
		string commandStr = "command:\nserverFuncDefFilePath clientFuncDefFilePath protoDir protoExe serverGenDir clientGenDir";
		if (args.Count()!=8)
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
		//proto 文件目录
		var protoDir = args[0];
		//proto 文件目录
		var protoExe = args[1];
		//客户端生成目录
		var clientGenDir = args[2];
		//服务器生成目录
		var serverGenDir = args[3];
		//interface
		var interfaceDir = args[4];
		//InterfaceReaction
		var InterfaceReactionDir = args[5];
		//公共
		var sharedDataDir = args[6];
		//grainCollection
		var grainCollectionDir = args[7];

		var protoTemp = protoDir + "/temp";

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
		Utility.ClearFolder(serverGenDir);

		if (!Directory.Exists(clientGenDir))
		{
			Console.WriteLine(clientGenDir + " do not exist.");
			var key = Console.ReadKey(true).Key;
			return false;
		}
		Console.WriteLine("clientGenDir=" + clientGenDir);
		Utility.ClearFolder(clientGenDir,"*.cs");

		if (!Directory.Exists(interfaceDir))
		{
			Console.WriteLine(interfaceDir + " do not exist.");
			var key = Console.ReadKey(true).Key;
			return false;
		}
		Console.WriteLine("interfaceDir=" + interfaceDir);
		Utility.ClearFolder(interfaceDir);

		if (!Directory.Exists(InterfaceReactionDir))
		{
			Console.WriteLine(InterfaceReactionDir + " do not exist.");
			var key = Console.ReadKey(true).Key;
			return false;
		}
		Console.WriteLine("InterfaceReactionDir=" + InterfaceReactionDir);
		Utility.ClearFolder(InterfaceReactionDir);

		if (!Directory.Exists(sharedDataDir))
		{
			Console.WriteLine(sharedDataDir + " do not exist.");
			var key = Console.ReadKey(true).Key;
			return false;
		}
		Console.WriteLine("sharedDataDir=" + sharedDataDir);
		Utility.ClearFolder(sharedDataDir);

		if (!Directory.Exists(grainCollectionDir))
		{
			Console.WriteLine(grainCollectionDir + " do not exist.");
			var key = Console.ReadKey(true).Key;
			return false;
		}
		Console.WriteLine("grainCollectionDir=" + grainCollectionDir);
		Utility.ClearFolder(grainCollectionDir);

		if (Directory.Exists(protoTemp))
		{
			Directory.Delete(protoTemp,true);
		}
		Directory.CreateDirectory(protoTemp);


		var STRING_S2C = "ServerService";
		var STRING_C2S = "ClientService";
		var CSHARP_POSTFIX = ".cs";

		UTF8Encoding encoding = new UTF8Encoding(false);

		var dirInfo = new DirectoryInfo(protoDir);
		var files = dirInfo.GetFiles("*.h", SearchOption.AllDirectories);

		var serverFuncs = new List<Function>();
		var clientFuncs = new List<Function>();
		var gate2ClientFuncs  = new List<Function>();
		foreach (var file in files)
		{
			var allFuncs = FunctionParser.Parse(file.FullName);
			serverFuncs.AddRange(allFuncs.Where(f => f.Direction == CallDirection.Client2GameServer));

			clientFuncs.AddRange(allFuncs.Where(f => f.Direction == CallDirection.GameServer2Client||
				f.Direction == CallDirection.Server2Client));
			gate2ClientFuncs.AddRange(allFuncs.Where(f => f.Direction == CallDirection.Server2Client).ToList());
		}



		{//Server
			var interfaceName = "IServer";
			var className = interfaceName;
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
			var className = interfaceName;
			using (TextWriter ClientInterfacetextWriter = new StreamWriter(Path.Combine(clientGenDir, className+CSHARP_POSTFIX), false, encoding))
			{
				CSharpCodeGenerator.ClientInterface(ClientInterfacetextWriter,className, STRING_C2S, clientFuncs);
			}

			className = "ClientInterfaceReaction";
			using (TextWriter ClientInterfaceReactiontextWriter = new StreamWriter(Path.Combine(clientGenDir, className+CSHARP_POSTFIX), false, encoding))
			{
				CSharpCodeGenerator.ClientInterfaceReaction(ClientInterfaceReactiontextWriter, className, interfaceName, STRING_C2S, clientFuncs);
			}


		}

		//ServerFunctions
		foreach (var file in files)
		{
			var fileName = file.Name.Substring(0, file.Name.LastIndexOf('.'));
			var allFuncs = FunctionParser.Parse(file.FullName);
			var ss = allFuncs.Where(f => f.Direction == CallDirection.Client2GameServer || f.Direction == CallDirection.Client2Server).ToList();

			if (ss.Count < 1)
			{
				continue;
			}
		
			var className = "ServerFunctions";
			var outFile = className + fileName + CSHARP_POSTFIX;
			using (TextWriter textWriter8 = new StreamWriter(Path.Combine(clientGenDir, outFile), false, encoding))
			{
				CSharpCodeGenerator.ServerFunctions(textWriter8, className, STRING_S2C, ss);
			}
		}

		//Server2Server
		{
			foreach (var file in files)
			{
				var fileName = file.Name.Substring(0, file.Name.LastIndexOf('.'));
				var allFuncs = FunctionParser.Parse(file.FullName);
				var ss = allFuncs.Where(f => f.Direction == CallDirection.Server2Server).ToList();

				if (ss.Count < 1)
				{
					continue;
				}

				var className = "I" + fileName;
				var outFile = className + "SS" + CSHARP_POSTFIX;
				using (TextWriter textWriter5 = new StreamWriter(Path.Combine(interfaceDir, outFile), false, encoding))
				{
					CSharpCodeGenerator.GrainInterface(textWriter5, className, STRING_S2C, ss,false);
				}
			}
		}

		//client2GateFuncs
		foreach (var file in files)
		{
			var fileName = file.Name.Substring(0, file.Name.LastIndexOf('.'));
			var allFuncs = FunctionParser.Parse(file.FullName);
			var client2GateFuncs = allFuncs.Where(f => f.Direction == CallDirection.Client2Server).ToList();

			if (client2GateFuncs.Count < 1)
			{
				continue;
			}

			var interfaceName = "I" + fileName;
			var className = interfaceName;
			using (TextWriter textWriter5 = new StreamWriter(Path.Combine(interfaceDir, className + CSHARP_POSTFIX), false, encoding))
			{
				CSharpCodeGenerator.GrainInterface(textWriter5, className, STRING_S2C, client2GateFuncs);
			}

			className = fileName + "GrainInterfaceReaction";
			using (TextWriter textWriter6 = new StreamWriter(Path.Combine(InterfaceReactionDir, className + CSHARP_POSTFIX), false, encoding))
			{
				CSharpCodeGenerator.GrainInterfaceReaction(textWriter6, "GrainInterfaceReaction", interfaceName, STRING_S2C, fileName, client2GateFuncs);
			}

			using (TextWriter textWriter = new StreamWriter(Path.Combine(protoTemp, "CG" + fileName + "Proto.proto"), false, encoding))
			{
				CreateProtoFile.GenerateProto(textWriter, STRING_S2C, client2GateFuncs);
			}
		}

		//Gate2clientFuncs
		if (gate2ClientFuncs.Count > 0)
		{
			var interfaceName = "IClientConnection";
			var className = interfaceName;
			using (TextWriter textWriter5 = new StreamWriter(Path.Combine(interfaceDir, className + CSHARP_POSTFIX), false, encoding))
			{
				CSharpCodeGenerator.ClientConnectionInterface(textWriter5, className, STRING_S2C, gate2ClientFuncs);
			}

			className = "ClientConnection";
			using (TextWriter textWriter6 = new StreamWriter(Path.Combine(grainCollectionDir, className + CSHARP_POSTFIX), false, encoding))
			{
				CSharpCodeGenerator.ClientConnectionImpl(textWriter6, "ClientConnection", STRING_S2C, gate2ClientFuncs);
			}

			className = "IClientConnectionObserver";
			using (TextWriter textWriter6 = new StreamWriter(Path.Combine(interfaceDir, className + CSHARP_POSTFIX), false, encoding))
			{
				CSharpCodeGenerator.ClientConnectionObserverInterface(textWriter6, "IClientConnectionObserver", STRING_S2C, gate2ClientFuncs);
			}

			className = "ClientConnectionObserver";
			using (TextWriter textWriter6 = new StreamWriter(Path.Combine(InterfaceReactionDir, className + CSHARP_POSTFIX), false, encoding))
			{
				CSharpCodeGenerator.ClientConnectionObserverImpl(textWriter6, "ClientConnectionObserver", STRING_S2C,"IClientConnectionObserver", gate2ClientFuncs);
			}

			using (TextWriter textWriter = new StreamWriter(Path.Combine(protoTemp, "Gate2clientFuncs" + "Proto.proto"), false, encoding))
 			{
				CreateProtoFile.GenerateProto(textWriter, STRING_S2C, gate2ClientFuncs);
 			}
		}

		using (TextWriter textWriter = new StreamWriter(Path.Combine(protoTemp , STRING_S2C + "Proto.proto"), false, encoding))
		{
			CreateProtoFile.GenerateProto(textWriter, STRING_S2C, serverFuncs);
		}
		using (TextWriter textWriter = new StreamWriter(Path.Combine(protoTemp, STRING_C2S + "Proto.proto"), false, encoding))
		{
			CreateProtoFile.GenerateProto(textWriter, STRING_C2S, clientFuncs);
		}

		

		CreateProtoFile.GenerateCSCode(protoExe,protoDir, clientGenDir);
		CreateProtoFile.GenerateCSCode(protoExe, protoDir, sharedDataDir);

		Utility.CopyFile(protoDir, "*.cs", clientGenDir);
		Utility.CopyFile(protoDir, "*.cs", sharedDataDir);

		return true;
	}


}

