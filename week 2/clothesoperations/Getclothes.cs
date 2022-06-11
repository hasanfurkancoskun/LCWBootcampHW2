using API1.Controllers;
using AutoMapper;

namespace API1.clothesoperations
{
    public class Getclothes
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;
        public Getclothes(DataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<ClothessViewModel> Handle()
        {
            var clotheslist= _dbContext.clothess.OrderBy(x => x.Id).ToList<clothes>();
            List< ClothessViewModel > vm = _mapper.Map<List<ClothessViewModel>>(clotheslist);
            /*List<ClothessViewModel> vm = new List<ClothessViewModel>();
            foreach (var clothe in clotheslist)
            {
                vm.Add(new ClothessViewModel()
                {
                    Name = clothe.Name,
                    Category = clothe.Category,
                    Material = clothe.Material,
                    CutType = clothe.CutType,
                });
            }*/
            return vm;
        }
    };

    public class ClothessViewModel
    {
        public string Name { get; set; } = String.Empty;
        public string Category { get; set; } = String.Empty;
        public string Material { get; set; } = String.Empty;
        public string CutType { get; set; } = String.Empty;
    }
}
