namespace Common
{
    public interface IUnitOfWork
    {
        bool UseSerializableEntities { get; set; }
        void SubmitChanges();
    }
}
