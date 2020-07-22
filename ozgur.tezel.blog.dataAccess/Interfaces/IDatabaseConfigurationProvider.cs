namespace ozgur.tezel.blog.dataAccess.Interfaces
{
    public interface IDatabaseConfigurationProvider
    {
        string ConnectionString { get; }
    }
}