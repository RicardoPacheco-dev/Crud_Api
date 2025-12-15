using AutoMapper;
using CRUD_API.Models;

namespace CRUD_API.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateMedicamentRequest, Medicament>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UpdateMedicamentRequest, Medicament>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Barcode, opt => opt.Ignore());
            ;

        }
    }
}