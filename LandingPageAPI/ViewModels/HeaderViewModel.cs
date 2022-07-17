using System.Text.Json.Serialization;

namespace LandingPageAPI.ViewModels
{
	public class HeaderViewModel
	{
		public int HeaderId { get; set; }
		public int? MenuGroupId { get; set; }
		public string? Logo { get; set; }

		public List<MenuViewModel>? Menus { get; set; }
	}
	public class MenuViewModel
	{
		public int MenuId { get; set; }
		public string? MenuTypeId { get; set; }
		public string? Title { get; set; }
		public string? SubTitle { get; set; }
		public string? Url { get; set; }
		public string? Target { get; set; }
		public string? Icon { get; set; }
		public string? ImageUrl { get; set; }
		public int Sort { get; set; }
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public List<MenuViewModel>? Childrens { get; set; }

	}
}
