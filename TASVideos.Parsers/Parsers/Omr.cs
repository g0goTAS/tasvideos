﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

using SharpCompress.Readers;

using TASVideos.MovieParsers.Result;

namespace TASVideos.MovieParsers.Parsers
{
	internal class Omr : ParserBase, IParser
	{
		public override string FileExtension => "omr";

		public IParseResult Parse(Stream file)
		{
			var result = new ParseResult
			{
				Region = RegionType.Pal,
				FileExtension = FileExtension,
				SystemCode = SystemCodes.Msx
			};

			using (var reader = ReaderFactory.Open(file))
			{
				reader.MoveToNextEntry();
				using (var entry = reader.OpenEntryStream())
				using (var textReader = new StreamReader(entry))
				{
					var serial = XElement.Parse(textReader.ReadToEnd());
					var replay = serial.Descendants().First(x => x.Name == "replay");
					result.RerecordCount = int.Parse(replay.Descendants().First(x => x.Name == "reRecordCount").Value);
				}
			}

			return result;
		}
	}
}
