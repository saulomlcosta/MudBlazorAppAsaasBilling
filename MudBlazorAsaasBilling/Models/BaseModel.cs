namespace MudBlazorAsaasBilling.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
