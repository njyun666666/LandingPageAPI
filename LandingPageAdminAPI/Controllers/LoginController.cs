using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LandingPageDB.Models;
using LandingPageAdminAPI.Models.Login;
using LandingPageCore.Helpers;
using LandingPageCore;
using LandingPageAdminAPI.Jwt;
using System.Security.Claims;
using System.Data;
using LandingPageAdminAPI.Models.OrgUser;

namespace LandingPageAdminAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : BaseController
	{
		private AppConfig _config;
		private JwtHelper _jwtHelper;
		private readonly LandingPageDBContext _context;

		public LoginController(AppConfig config, JwtHelper jwtHelper, LandingPageDBContext context)
		{
			_config = config;
			_jwtHelper = jwtHelper;
			_context = context;
		}

		// POST: api/Login
		[HttpPost]
		public async Task<ActionResult<TokenViewModel>> Index(LoginModel login)
		{
			login.Email = "admin@example.com";
			login.Password = "Demo123456";

			string encodingPW = EncodingHepler.ComputeHMACSHA256(login.Password, _config.AdminAPIKey());
			var user = await _context.TbOrgUsers.FirstOrDefaultAsync(x => x.Email == login.Email && x.Enable && x.Passwrod == encodingPW);

			if (user == null)
			{
				return Unauthorized();
			}

			var token = await CreateToken(user);

			await _context.SaveChangesAsync();
			return Ok(token);
		}

		// POST: api/Login/RefreshToken
		[HttpPost("RefreshToken")]
		public async Task<ActionResult> RefreshToken(RefreshTokenModel refreshToken)
		{
			var tbRefresh = await _context.TbRefreshTokens.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken.refresh_token);

			if (tbRefresh == null)
			{
				return Unauthorized();
			}

			_context.TbRefreshTokens.Remove(tbRefresh);

			if (tbRefresh.ExpireTime < DateTime.Now)
			{
				await _context.SaveChangesAsync();
				return Unauthorized();
			}

			var user = await _context.TbOrgUsers.FirstOrDefaultAsync(x => x.Uid == tbRefresh.Uid && x.Enable);

			if (user == null)
			{
				await _context.SaveChangesAsync();
				return Unauthorized();
			}


			var token = await CreateToken(user);

			await _context.SaveChangesAsync();
			return Ok(token);
		}

		private async Task<TokenViewModel> CreateToken(TbOrgUser user)
		{
			var claims = new List<Claim>
			{
				new Claim("uid", user.Uid)
			};

			var roles = await _context.TbOrgRoles.Where(x => x.Enable && x.Uids.Any(u => u.Uid == user.Uid)).Select(x => x.Rid).ToArrayAsync();

			foreach (var role in roles)
			{
				claims.Add(new Claim("roles", role));
			}

			string refresh_token = Guid.NewGuid().ToString();
			_context.TbRefreshTokens.Add(new TbRefreshToken()
			{
				RefreshToken = refresh_token,
				ExpireTime = DateTime.Now.AddDays(7),
				Uid = user.Uid,
			});

			return new TokenViewModel()
			{
				Access_token = _jwtHelper.GenerateToken(user.Name, claims),
				Refresh_token = refresh_token
			};
		}

	}
}
