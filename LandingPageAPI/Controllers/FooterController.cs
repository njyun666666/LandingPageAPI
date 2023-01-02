using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LandingPageAPI.ViewModels;
using AutoMapper;
using LandingPageDB.Models;

namespace LandingPageAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FooterController : ControllerBase
	{
		private readonly LandingPageDBContext _context;
		private readonly IMapper _mapper;

		public FooterController(LandingPageDBContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		// GET: api/Footer
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult<FooterViewModel>> GetTbFooterSetting()
		{
			var tbFooterSetting = await _context.TbFooterSettings
				.Include(footer => footer.Section)
				.ThenInclude(s => s.Item1Navigation)
				.ThenInclude(i => i.TbItems.Where(i => i.Enable).OrderBy(i => i.Sort))
				.Include(footer => footer.Section)
				.ThenInclude(s => s.Item2Navigation)
				.ThenInclude(i => i.TbItems.Where(i => i.Enable).OrderBy(i => i.Sort))
				.FirstOrDefaultAsync(x => x.Enable);

			if (tbFooterSetting == null)
			{
				return NotFound();
			}

			return _mapper.Map<FooterViewModel>(tbFooterSetting);
		}

	}
}
