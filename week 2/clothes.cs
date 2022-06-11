using System.ComponentModel.DataAnnotations;

namespace API1
{
    //created a class
    public class clothes
    {
        //class has five value
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }=String.Empty;
        public string Category { get; set; }=String.Empty;
        public string Material { get; set; }=String.Empty;
        public string CutType { get; set; }=String.Empty;
        public Stores? Stores { get; set; }
        
    }
}
