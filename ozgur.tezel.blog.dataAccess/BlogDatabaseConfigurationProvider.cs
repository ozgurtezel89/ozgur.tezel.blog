using ozgur.tezel.blog.dataAccess.Interfaces;
using System;

namespace ozgur.tezel.blog.dataAccess
{
    public class BlogDatabaseConfigurationProvider : IDatabaseConfigurationProvider
    {
        public string ConnectionString { get; }

        public BlogDatabaseConfigurationProvider(string connectionString)
            => this.ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }
}