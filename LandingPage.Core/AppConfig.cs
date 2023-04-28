using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandingPageCore
{
	public class AppConfig
	{
		private IConfiguration _config;
		public AppConfig(IConfiguration config)
		{
			_config = config;
		}

		public string AdminAPIKey()
		{
			return _config["Key:LandingPageAdminAPI"].ToString();
		}


	}
}
