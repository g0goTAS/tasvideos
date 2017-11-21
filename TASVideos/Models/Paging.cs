﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace TASVideos.Models
{
	public class PageOf<T> : IEnumerable<T>
	{
		private readonly IEnumerable<T> _items;

		public PageOf(IEnumerable<T> items)
		{
			_items = items;
		}

		// TODO: sorting
		public int PageSize { get; set; }
		public int CurrentPage { get; set; }
		public int RowCount { get; set; }
		public int NumberOfPages => (int)Math.Ceiling(RowCount / (double)PageSize);

		public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();
	}

	/// <summary>
	/// Represents all of the data necessary to create a paged query
	/// </summary>
	public class PagedModel
	{
		public int PageSize { get; set; }
		public int CurrentPage { get; set; }
	}
}
