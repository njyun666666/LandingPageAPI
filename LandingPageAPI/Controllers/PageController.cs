using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using LandingPageAPI.ViewModels;
using LandingPageDB.Models;

namespace LandingPageAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PageController : ControllerBase
	{
		private readonly LandingPageDBContext _context;
		private readonly IMapper _mapper;

		public PageController(LandingPageDBContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		// GET: api/Page/index
		[HttpGet("{path}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult<PageViewModel>> GetTbPage(string path)
		{
			var tbPage = await _context.TbPages.Where(page => page.Path == path)
				.Include(page => page.TbPageSections.OrderBy(ps => ps.Sort))
				.ThenInclude(ps => ps.Section)
				.ThenInclude(s => s.Item1Navigation)
				.ThenInclude(i => i.TbItems.Where(i => i.Enable).OrderBy(i => i.Sort))
				.FirstOrDefaultAsync();

			if (tbPage == null)
			{
				return NotFound();
			}

			return _mapper.Map<PageViewModel>(tbPage);
		}
	}
}
