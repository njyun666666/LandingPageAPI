using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LandingPageAPI.Models;
using LandingPageAPI.ViewModels;

namespace LandingPageAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HeaderController : ControllerBase
	{
		private readonly LandingPageDBContext _context;
		private List<TbMenu> _menu;

		public HeaderController(LandingPageDBContext context)
		{
			_context = context;
			_menu = new List<TbMenu>();
		}

		// GET: api/Header
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult<HeaderViewModel>> GetTbHeaderSettings()
		{
			TbHeaderSetting? header = await _context.TbHeaderSettings.FirstOrDefaultAsync(x => x.Enable);
			if (header == null)
			{
				return NotFound();
			}

			HeaderViewModel result = new HeaderViewModel()
			{
				HeaderId = header.HeaderId,
				Logo = header.Logo
			};

			if (header.MenuGroupId != null)
			{
				_menu = await _context.TbMenus.Where(x => x.MenuGroupId == header.MenuGroupId && x.Enable).AsNoTracking().ToListAsync();
				result.MenuGroupId = header.MenuGroupId;
				result.Menus = SetMenu(null).ToList();
			}

			return Ok(result);
		}

		private List<MenuViewModel> SetMenu(int? menuParentID)
		{
			return _menu.Where(x => x.MenuParentId == menuParentID)
				.Select(x => new MenuViewModel()
				{
					MenuId = x.MenuId,
					MenuTypeId = x.MenuTypeId,
					Title = x.Title,
					SubTitle = x.SubTitle,
					Url = x.Url,
					Target = x.Target,
					Icon = x.Icon,
					ImageUrl = x.ImageUrl,
					Childrens = SetMenu(x.MenuId),
					Sort = x.Sort
				}).OrderBy(x => x.Sort).ToList();
		}

	}
}
