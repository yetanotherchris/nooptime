using System;

namespace Nooptime.Domain.Models
{
	public class UptimeCheckResult
	{
		public Guid UptimeCheckId { get; set; }
		public DateTime Date { get; set; }
		public bool Success { get; set; }
		public string Errors { get; set; }
	}
}