using System;
using System.IO;

namespace nativesample
{
	class Program
	{
		private void SendMessage(string data)
		{
			Stream stdout = Console.OpenStandardOutput();

			byte[] buffer = System.Text.Encoding.UTF8.GetBytes(data);
			byte[] len = {
				(byte)((buffer.Length >> 0) & 0xFF),
				(byte)((buffer.Length >> 8) & 0xFF),
				(byte)((buffer.Length >> 16) & 0xFF),
				(byte)((buffer.Length >> 24) & 0xFF)
			};

			//send buffer size
			stdout.Write(len, 0, len.Length);
			//send buffer data
			stdout.Write(buffer, 0, buffer.Length);
			stdout.Flush();

		}

		private string Read()
		{
			Stream stdin = Console.OpenStandardInput();

			//read message length
			byte[] len = new byte[4];
			stdin.Read(len, 0, 4);

			char[] buffer = new char[BitConverter.ToInt32(len, 0)];
			//read message
			using (StreamReader reader = new StreamReader(stdin))
			{
				if (reader.Peek() >= 0) reader.Read(buffer, 0, buffer.Length);
			}

			return new string(buffer);

		}

		private void Listen()
		{
			string data;

			while ((data = Read()) != null)
			{
				SendMessage("{\"message\":\"PONG\"}");
			}
		}
		static void Main(string[] args)
		{
			new Program().Listen();
		}
	}
}
