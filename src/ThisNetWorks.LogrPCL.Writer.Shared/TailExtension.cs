using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ThisNetWorks.LogrPCL.Writer.Shared
{
	public static class TailExtension
	{
		public static string Tail(this StreamReader reader, int lineCount)
		{
			var buffer = new List<string>(lineCount);
			string line;
			for (int i = 0; i < lineCount; i++) {
				line = reader.ReadLine();
				if (line == null) return GetStringFromList(buffer);
				buffer.Add(line);
			}

			int lastLine = lineCount - 1;           //The index of the last line read from the buffer.  Everything > this index was read earlier than everything <= this indes

			while (null != (line = reader.ReadLine())) {
				lastLine++;
				if (lastLine == lineCount) lastLine = 0;
				buffer[lastLine] = line;
			}

			//if (lastLine == lineCount - 1) return GetStringFromList(buffer);
			//var retVal = new string[lineCount];
			//buffer.CopyTo(lastLine + 1, retVal, 0, lineCount - lastLine - 1);
			//buffer.CopyTo(0, retVal, lineCount - lastLine - 1, lastLine + 1);




			return GetStringFromList(buffer);
		}

		private static string GetStringFromList(List<string> buffer)
		{
			var builder = new StringBuilder();
			foreach (var s in buffer) {
				builder.AppendLine(s);
			}
			return builder.ToString();
		}
	}
}

