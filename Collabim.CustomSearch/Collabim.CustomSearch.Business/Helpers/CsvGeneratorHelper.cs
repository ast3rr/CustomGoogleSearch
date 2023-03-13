﻿using System.Text;

namespace Collabim.CustomSearch.Business.Helpers
{
	public interface ICsvGeneratorHelper
	{
		string GenerateData<T>(IEnumerable<T> data) where T : class, new();
	}

	public class CsvGeneratorHelper : ICsvGeneratorHelper
	{
		private readonly string _separator;

		public CsvGeneratorHelper()
		{
			this._separator = ";";
		}

		public string GenerateData<T>(IEnumerable<T> data) where T : class, new()
		{
			var sb = new StringBuilder();

			var properties = typeof(T).GetProperties();

			sb.AppendLine(string.Join(_separator, properties.Select(p => p.Name).ToArray()));

			foreach (var item in data)
			{
				var items = (properties.Select(p => (p.GetValue(item, null) ?? string.Empty).ToString())).ToArray();

				for (int i = 0; i < items.Length; i++)
				{
					if (string.IsNullOrWhiteSpace(items[i]))
					{
						items[i] = string.Empty;
					}

					items[i] = System.Net.WebUtility.HtmlDecode(items[i]);

					if (items[i].Contains(_separator))
					{
						items[i] = items[i].Replace(_separator, ",");
					}
				}

				sb.AppendLine(string.Join(_separator, items));
			}

			return sb.ToString();
		}
	}
}