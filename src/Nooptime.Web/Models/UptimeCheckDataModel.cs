using System;
using System.Collections.Generic;

namespace Nooptime.Web.Models
{
	public class UptimeCheckDataModel
	{
		public Guid? Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public TimeSpan Interval { get; set; }
		//public Dictionary<string, string> Properties { get; set; }

	    public UptimeCheckDataModel()
	    {

        }
	}
}