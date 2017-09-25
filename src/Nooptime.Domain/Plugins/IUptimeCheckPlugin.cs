using Nooptime.Domain.Models;

namespace Nooptime.Domain.Plugins
{
	public interface IUptimeCheckPlugin
	{
		UptimeCheckResult RunCheck(UptimeCheckData uptimeCheckData);
	}
}