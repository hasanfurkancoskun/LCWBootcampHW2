using API1.Controllers;
using AutoMapper;

namespace API1.clothesoperations
{
    public class GetClothesDetail
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;
        public int ClotheId { get; set; }
        public GetClothesDetail(DataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public ClotheDetailViewModel Handle()
        {
            var clothe = _dbContext.clothess.Where(clothe=> clothe.Id == ClotheId).SingleOrDefault();
            if (clothe is null)
                throw new InvalidOperationException("clothe is not found");
            ClotheDetailViewModel vm = _mapper.Map<ClotheDetailViewModel>(clothe);
            return vm;
        }
        public class ClotheDetailViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; } = String.Empty;
            public string Category { get; set; } = String.Empty;
            public string Material { get; set; } = String.Empty;
            public string CutType { get; set; } = String.Empty;
            //public Stores? Stores { get; set; }
        }
    }
}
