using AutoMapper;
using LandingPageAPI.Models;
using LandingPageAPI.ViewModels;

namespace LandingPageAPI.Mappings
{
	public class PageProfile : Profile
	{
		public PageProfile()
		{
			CreateMap<TbPage, PageViewModel>();
			CreateMap<TbPageSection, PageSectionViewModel>();
			CreateMap<TbSectionSetting, SectionSettingViewModel>();
			CreateMap<TbItemGroup, ItemGroupViewModel>();
			CreateMap<TbItem, ItemViewModel>();
			CreateMap<TbFooterSetting, FooterViewModel>();
		}
	}
}
