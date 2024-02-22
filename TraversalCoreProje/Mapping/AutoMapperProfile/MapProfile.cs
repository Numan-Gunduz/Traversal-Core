using AutoMapper;
using DocumentFormat.OpenXml.Bibliography;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.CityDTOs;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;

namespace TraversalCoreProje.Mapping.AutoMapperProfile
{
	public class MapProfile:Profile

	{
        public MapProfile()

        {

            CreateMap<AnnouncementAddDto, Announcement>().ReverseMap();
            //CreateMap<Announcement, AnnouncementAddDTOs>();

            CreateMap<AppUserRegisterDTOs, AppUser>().ReverseMap(); 
            //CreateMap<AppUser, AppUserRegisterDTOs>();

			CreateMap<AppUserLoginDTOs, AppUser>().ReverseMap();
			//CreateMap<AppUser, AppUserLoginDTOs>();

			CreateMap<AnnouncementListDto, Announcement	>().ReverseMap();

			CreateMap<AnnouncementUpdateDto, Announcement>().ReverseMap();

			CreateMap<SendMessageDTO, ContactUs>().ReverseMap();


		}
	}
}
