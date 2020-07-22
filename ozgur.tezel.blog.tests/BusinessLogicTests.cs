using Moq;
using ozgur.tezel.blog.businessLogic.Models;
using ozgur.tezel.blog.businessLogic.Services;
using ozgur.tezel.blog.dataAccess.Interfaces;
using ozgur.tezel.blog.dataAccess.Models;
using Xunit;

namespace ozgur.tezel.blog.tests
{
    public class BusinessLogicTests
    {
        #region Private Variables

        private readonly Mock<IPostRepository> mockPostRepository;
        private readonly AdminBusinessLayer adminBusinessLayer;
        private readonly PostBusinessLayer postBusinessLayer;

        #endregion

        #region Constructors

        public BusinessLogicTests()
        {
            mockPostRepository = new Mock<IPostRepository>();
            adminBusinessLayer = new AdminBusinessLayer(mockPostRepository.Object);
            postBusinessLayer = new PostBusinessLayer(mockPostRepository.Object);
        }
        #endregion

        #region Facts

        [Fact]
        public void AdminBusinessLayerAddPostShouldCallPostRepositoryAddPostMethodOnlyOnce()
        {
            // Arrange
            mockPostRepository.Setup(x => x.AddPost(new PostTable()));

            // Act
            adminBusinessLayer.AddPost(new AddPost());
            
            // Assert
            mockPostRepository.Verify(x => x.AddPost(It.IsAny<PostTable>()), Times.Once());
        }

        [Fact]
        public void AdminBusinessLayerSetPostStatusShouldCallPostRepositorySetPostStatusOnlyOnce()
        {
            // Arrange
            mockPostRepository.Setup(x => x.SetPostStatus(It.IsAny<bool>(), It.IsAny<int>()));

            // Act
            adminBusinessLayer.SetPostStatus(It.IsAny<bool>(), It.IsAny<int>());

            // Assert
            mockPostRepository.Verify(x => x.SetPostStatus(It.IsAny<bool>(), It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void AdminBusinessLayerTotalPostsShouldCallPostRepositoryTotalPosts()
        {
            // Arrange
            mockPostRepository.Setup(x => x.TotalPosts()).Returns(It.IsAny<int>());

            // Act
            adminBusinessLayer.TotalPosts();

            // Assert
            mockPostRepository.Verify(x => x.TotalPosts(), Times.Once);
        }

        [Fact]
        public void AdminBusinessLayerListShouldNotCallPostRepositoryGetAllActivePosts()
        {
            // Arrange
            mockPostRepository.Setup(x => x.GetAllPosts());

            // Act
            adminBusinessLayer.List();

            // Assert
            mockPostRepository.Verify(x => x.GetAllActivePosts(), Times.Never);
        }

        [Fact]
        public void PostBusinessLayerListShouldNotCallPostRepositoryGetAllPosts()
        {
            // Arrange
            mockPostRepository.Setup(x => x.GetAllActivePosts());

            // Act
            postBusinessLayer.List();

            // Assert
            mockPostRepository.Verify(x => x.GetAllPosts(), Times.Never);
        }

        [Fact]
        public void PostBusinessLayerGetPostByIdShouldCallPostRepositoryGetById()
        {
            // Arrange
            mockPostRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(new PostTable());

            // Act
            postBusinessLayer.GetPostById(It.IsAny<int>());

            // Assert
            mockPostRepository.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        #endregion
    }
}