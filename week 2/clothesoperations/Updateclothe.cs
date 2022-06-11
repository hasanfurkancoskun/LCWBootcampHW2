using API1.Controllers;
namespace API1.clothesoperations
{
    public class Updateclothe
    {
        private readonly DataContext _dbContext;
        public int clotheId { get; set; }
        public UpdateClotheModel Model { get; set; }
        public Updateclothe(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var dbclothe = _dbContext.clothess.SingleOrDefault(x => x.Id == clotheId);
            if (dbclothe is null)
            {
                throw new InvalidOperationException("clothe is not found");
            }
            dbclothe.Name = Model.Name;
            dbclothe.Category = Model.Category;
            dbclothe.Material = Model.Material;
            dbclothe.CutType = Model.CutType;
            _dbContext.SaveChangesAsync();
        }
        public class UpdateClotheModel
        {
            public string Name { get; set; } = String.Empty;
            public string Category { get; set; } = String.Empty;
            public string Material { get; set; } = String.Empty;
            public string CutType { get; set; } = String.Empty;
        }
    }
}
