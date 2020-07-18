namespace DesafioBoltons.Domain.Entities
{
    public abstract class BaseEntity<T>
    {
        public virtual T ID { get; set; }
    }
}
