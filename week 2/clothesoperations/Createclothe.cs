using API1.Controllers;
using AutoMapper;

namespace API1.clothesoperations
{
    public class Createclothe
    {
        public CreateclotheModel Model { get; set; }
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;
        public Createclothe(DataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var clothe= _dbContext.clothess.SingleOrDefault(x => x.Name ==Model.Name);
            if (clothe is not null)
            {
                throw new InvalidDataException("clothe is already exist");
            }
            clothe = _mapper.Map<clothes>(Model);//new clothes();
            /*clothe.Name = Model.Name;
            clothe.Category=Model.Category;
            clothe.Material=Model.Material;
            clothe.CutType=Model.CutType;*/

            _dbContext.clothess.Add(clothe);
            _dbContext.SaveChanges();
        }
        public class CreateclotheModel
        {
            public string Name { get; set; } = String.Empty;
            public string Category { get; set; } = String.Empty;
            public string Material { get; set; } = String.Empty;
            public string CutType { get; set; } = String.Empty;
        }
    }
}
