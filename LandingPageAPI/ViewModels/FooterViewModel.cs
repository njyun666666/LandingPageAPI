namespace LandingPageAPI.ViewModels
{
	public class FooterViewModel
	{
		public int FooterId { get; set; }
		public int SectionId { get; set; }
		public bool Enable { get; set; }

		public SectionSettingViewModel Section { get; set; } = null!;
	}
}
