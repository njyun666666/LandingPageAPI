using AutoMapper;
using LandingPageAPI.ViewModels;
using LandingPageDB.Models;

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
