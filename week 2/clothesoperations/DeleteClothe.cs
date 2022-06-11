using API1.Controllers;
namespace API1.clothesoperations
{
    public class DeleteClotheCommand
    {
        private readonly DataContext _dbContext;
        public int ClotheId { get; set; }
        public DeleteClotheCommand(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var dbclothe = _dbContext.clothess.SingleOrDefault(x => x.Id == ClotheId);
            if (dbclothe is null)
            {
                throw new InvalidOperationException("clothe is not found");
            }
            _dbContext.clothess.Remove(dbclothe);
            _dbContext.SaveChanges();
        }
    }
}
