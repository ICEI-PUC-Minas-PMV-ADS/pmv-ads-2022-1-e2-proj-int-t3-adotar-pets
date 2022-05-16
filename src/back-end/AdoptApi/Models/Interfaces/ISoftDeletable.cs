namespace AdoptApi.Models.Interfaces;

public interface ISoftDeletable
{
    public DateTime? DeletedOn { get; set; }
}