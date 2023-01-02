using LandingPageCore;
using LandingPageCore.Configuration;
using LandingPageDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandingPageDB
{
	public class LandingPageDBContextFactory : IDesignTimeDbContextFactory<LandingPageDBContext>
	{
		public LandingPageDBContext CreateDbContext(string[] args)
		{
			var builder = new DbContextOptionsBuilder<LandingPageDBContext>();
			var configuration = AppConfigurations.BuildConfiguration();
			builder.UseMySql(configuration.GetConnectionString(AppConsts.LandingPageDBConnection), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));

			return new LandingPageDBContext(builder.Options);
		}
	}
}
