﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TASVideos.MovieParsers.Extensions;

namespace TASVideos.MovieParsers.Tests
{
	[TestClass]
	public class ExtensionTests
	{
		[TestMethod]
		[DataRow(null, null)]
		[DataRow("", null)]
		[DataRow(" ", null)]
		[DataRow("1", 1)]
		[DataRow("0", 0)]
		[DataRow("-1", null)]
		[DataRow("1.1", null)]
		[DataRow("99999999999", null)]
		[DataRow("NotANumber", null)]
		public void ToPositiveInt(string val, int? expected)
		{
			var actual = val.ToPositiveInt();
			Assert.AreEqual(expected, actual);
		}
	}
}