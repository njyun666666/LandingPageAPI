namespace LandingPageAPI.ViewModels
{
	public class PageViewModel
	{
		public int PageId { get; set; }
		/// <summary>
		/// 路徑
		/// </summary>
		public string Path { get; set; } = null!;
		/// <summary>
		/// 網頁標題
		/// </summary>
		public string Title { get; set; } = null!;
		/// <summary>
		/// 網頁描述
		/// </summary>
		public string? Description { get; set; }
		public string? HeaderColorMode { get; set; }
		public bool BodyNavFixed { get; set; }
		public ICollection<PageSectionViewModel>? TbPageSections { get; set; }

	}

	public class PageSectionViewModel
	{
		public int Id { get; set; }
		public int PageId { get; set; }
		public int SectionId { get; set; }
		public int Sort { get; set; }
		public SectionSettingViewModel Section { get; set; } = null!;
	}

	public class SectionSettingViewModel
	{

		public int SectionId { get; set; }
		public string SectionTypeId { get; set; } = null!;
		public string? BackgroundImage { get; set; }
		public string? BackgroundColor { get; set; }
		public string? Title { get; set; }
		public string? SubTitle { get; set; }
		public string? Content { get; set; }
		public string? ParticleIcon { get; set; }
		public int? Item1 { get; set; }
		public virtual ItemGroupViewModel? Item1Navigation { get; set; }
	}

	public class ItemGroupViewModel
	{
		public int ItemGroupId { get; set; }
		public string? Description { get; set; }
		public virtual ICollection<ItemViewModel>? TbItems { get; set; }
	}

	public class ItemViewModel
	{
		public int ItemId { get; set; }
		public int ItemGroupId { get; set; }
		public string? Title { get; set; }
		public string? SubTitle { get; set; }
		public string? Content { get; set; }
		public string? Icon { get; set; }
		public string? ImageUrl { get; set; }
		public string? Url { get; set; }
		public string? Target { get; set; }
		public float? Number { get; set; }
		public int Sort { get; set; }
	}
}
