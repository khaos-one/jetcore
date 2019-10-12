namespace Khaos.Core.Extensions
{
    public interface IIdentifiable<TId>
    {
        TId Id { get; set; }
    }
}