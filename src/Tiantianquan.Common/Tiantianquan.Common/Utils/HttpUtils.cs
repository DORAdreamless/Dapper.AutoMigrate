﻿using System.Collections.Generic;
using System.Net;
using System.Text;
using Tiantianquan.Common.Extensions;

namespace Tiantianquan.Common.Utils {
	/// <summary>
	/// Http utility functions
	/// </summary>
	public static class HttpUtils {
		/// <summary>
		/// Url encode
		/// </summary>
		/// <param name="value">Original value</param>
		/// <returns></returns>
		public static string UrlEncode(object value) {
			return WebUtility.UrlEncode(value?.ToString() ?? "");
		}

		/// <summary>
		/// Url decode
		/// </summary>
		/// <param name="value">Original value</param>
		/// <returns></returns>
		public static string UrlDecode(string value) {
			return WebUtility.UrlDecode(value ?? "");
		}

		/// <summary>
		/// Html encode
		/// </summary>
		/// <param name="value">Original value</param>
		/// <returns></returns>
		public static string HtmlEncode(object value) {
			return WebUtility.HtmlEncode(value?.ToString() ?? "");
		}

		/// <summary>
		/// Html decode
		/// </summary>
		/// <param name="value">Original value</param>
		/// <returns></returns>
		public static string HtmlDecode(string value) {
			return WebUtility.HtmlDecode(value ?? "");
		}

		/// <summary>
		/// Split path and query string
		/// </summary>
		/// <param name="pathAndQuery">Path an query string</param>
		/// <param name="path">Path</param>
		/// <param name="queryString">Query string</param>
		public static void SplitPathAndQuery(
			string pathAndQuery, out string path, out string queryString) {
			var queryIndex = pathAndQuery.IndexOf('?');
			path = (queryIndex >= 0) ? pathAndQuery.Substring(0, queryIndex) : pathAndQuery;
			queryString = (queryIndex >= 0) ? pathAndQuery.Substring(queryIndex) : "";
		}

		/// <summary>
		/// Parse query string
		/// </summary>
		/// <param name="queryString">Query string</param>
		/// <returns></returns>
		public static IDictionary<string, IList<string>> ParseQueryString(string queryString) {
			var result = new Dictionary<string, IList<string>>();
			if (string.IsNullOrEmpty(queryString)) {
				return result;
			}
			// Trim beginning `?`
			var startIndex = (queryString[0] == '?') ? 1 : 0;
			// Find all keys and values
			while (startIndex < queryString.Length) {
				var equalIndex = queryString.IndexOf('=', startIndex);
				if (equalIndex < 0) {
					return result;
				}
				var andIndex = queryString.IndexOf('&', equalIndex);
				if (andIndex < 0) {
					andIndex = queryString.Length;
				}
				var key = UrlDecode(queryString.Substring(startIndex, equalIndex - startIndex));
				var value = UrlDecode(queryString.Substring(equalIndex + 1, andIndex - equalIndex - 1));
				startIndex = andIndex + 1;
				if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value)) {
					result.GetOrCreate(key, () => new List<string>()).Add(value);
				}
			}
			return result;
		}

		/// <summary>
		/// Build query string
		/// </summary>
		/// <param name="queryParams">Query arguments</param>
		/// <returns></returns>
		public static string BuildQueryString(IDictionary<string, IList<string>> queryParams) {
			var queryString = new StringBuilder();
			var isFirst = true;
			foreach (var pair in queryParams) {
				foreach (var value in pair.Value) {
					if (!isFirst) {
						queryString.Append('&');
					}
					isFirst = false;
					queryString.Append(UrlEncode(pair.Key));
					queryString.Append('=');
					queryString.Append(UrlEncode(value));
				}
			}
			return queryString.ToString();
		}
	}
}
