using System;
using Tiantianquan.Common.Utils;


namespace Tiantianquan.Common.Extensions {
	/// <summary>
	/// Date time extension methods
	/// </summary>
	public static class DateTimeExtensions {


	


		/// <summary>
		/// Truncate datetime, only keep seconds
		/// </summary>
		/// <param name="time">The time</param>
		/// <returns></returns>
		public static DateTime Truncate(this DateTime time) {
			return time.AddTicks(-(time.Ticks % TimeSpan.TicksPerSecond));
		}

		/// <summary>
		/// Return unix style timestamp
		/// Return a minus value if the time early than 1970-1-1
		/// The given time will be converted to UTC time first
		/// </summary>
		/// <param name="time">The time</param>
		/// <returns></returns>
		public static TimeSpan ToTimestamp(this DateTime time) {
			return time.ToUniversalTime() - new DateTime(1970, 1, 1);
		}
	}
}
