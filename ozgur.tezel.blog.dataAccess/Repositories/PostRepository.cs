using Dapper;
using ozgur.tezel.blog.dataAccess.Interfaces;
using ozgur.tezel.blog.dataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ozgur.tezel.blog.dataAccess.Repositories
{
    public class PostRepository : IPostRepository
    {
        #region Private Variables

        private readonly IDbConnection BlogDatabase;
        private bool disposedValue;

        #endregion

        #region Constructors

        public PostRepository(IDatabaseConfigurationProvider databaseConfigurationProvider)
        {
            if (databaseConfigurationProvider is null)
            {
                throw new ArgumentNullException(nameof(databaseConfigurationProvider));
            }

            BlogDatabase = new SqlConnection(databaseConfigurationProvider.ConnectionString);
        }

        #endregion

        #region Main Calls

        public IEnumerable<PostTable> GetAllPosts()
        {
            return BlogDatabase
                .Query<PostTable>
                ("SELECT * FROM POSTS");
        }

        public IEnumerable<PostTable> GetAllActivePosts()
        {
            return BlogDatabase
                .Query<PostTable>
                ("SELECT * FROM POSTS WHERE Active = 1");
        }

        public PostTable GetById(int id)
        {
            return BlogDatabase
                .QuerySingleOrDefault<PostTable>
                ("SELECT * FROM POSTS WHERE Id = @id AND Active = 1",
                new { id });
        }

        public int TotalPosts()
        {
            return BlogDatabase
                .QuerySingleOrDefault<int>("SELECT COUNT(ID) FROM POSTS");
        }

        public void SetPostStatus(bool isActive, int id)
        {
            int active = 0;

            if (isActive) 
            {
                active = 1;
            }

            BlogDatabase.Execute
                ("UPDATE POSTS SET Active = @active WHERE Id = @id",
                new { active , id });
        }

        public void AddPost(PostTable post)
        {
            int active = 0;
            if (post.Active)
            {
                active = 1;
            }

            BlogDatabase.Execute
                ("INSERT INTO POSTS (Author, Title, Content, Active) " +
                "VALUES (@author, @title, @content, @active)",
                new
                {
                    @author = post.Author,
                    @title = post.Title,
                    @content = post.Content,
                    active
                });
        }

        #endregion

        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    BlogDatabase.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}