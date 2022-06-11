using API1.clothesoperations;
using AutoMapper;
using static API1.clothesoperations.Createclothe;
using static API1.clothesoperations.GetClothesDetail;

namespace API1.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateclotheModel, clothes>();
            CreateMap<clothes, ClothessViewModel>();
            CreateMap<clothes, ClotheDetailViewModel>();
        }
    }
}
