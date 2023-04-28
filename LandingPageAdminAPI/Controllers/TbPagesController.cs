using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LandingPageDB.Models;
using Microsoft.AspNetCore.Authorization;

namespace LandingPageAdminAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class TbPagesController : ControllerBase
	{
		private readonly LandingPageDBContext _context;

		public TbPagesController(LandingPageDBContext context)
		{
			_context = context;
		}

		// GET: api/TbPages
		[HttpGet]
		[Authorize(Roles = "admin")]
		public async Task<ActionResult<IEnumerable<TbPage>>> GetTbPages()
		{
			return await _context.TbPages.ToListAsync();
		}

		// GET: api/TbPages/5
		[HttpGet("{id}")]
		public async Task<ActionResult<TbPage>> GetTbPage(int id)
		{
			var tbPage = await _context.TbPages.FindAsync(id);

			if (tbPage == null)
			{
				return NotFound();
			}

			return tbPage;
		}

		// PUT: api/TbPages/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutTbPage(int id, TbPage tbPage)
		{
			if (id != tbPage.PageId)
			{
				return BadRequest();
			}

			_context.Entry(tbPage).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!TbPageExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/TbPages
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<TbPage>> PostTbPage(TbPage tbPage)
		{
			_context.TbPages.Add(tbPage);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetTbPage", new { id = tbPage.PageId }, tbPage);
		}

		// DELETE: api/TbPages/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteTbPage(int id)
		{
			var tbPage = await _context.TbPages.FindAsync(id);
			if (tbPage == null)
			{
				return NotFound();
			}

			_context.TbPages.Remove(tbPage);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool TbPageExists(int id)
		{
			return _context.TbPages.Any(e => e.PageId == id);
		}
	}
}
