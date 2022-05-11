using AutoFixture;
using LessonMonitor.Core;
using LessonMonitor.Core.Exceptions;
using LessonMonitor.Core.Repositoryes;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace LessonMonitor.BusinessLogic.Test
{
    public class HomeworkServiceTests
    {
        private Mock<IHomeWorkRepository> _homeworkRepositoryMock;
        private HomeworkService _service;

        [SetUp]
        public void Setup()
        {
            _homeworkRepositoryMock = new Mock<IHomeWorkRepository>();
            _service = new HomeworkService(_homeworkRepositoryMock.Object);
        }

        [Test]
        public async Task Create_ShouldCreateNewHomework()
        {
            // arrange

            var fixture = new Fixture();
            var homework = fixture.Create<HomeWork>();

            // act

            var result = await _service.Create(homework);

            // assert

            Assert.IsTrue(homework.Id == result);
            _homeworkRepositoryMock.Verify(x => x.Add(homework), Times.Once);
        }

        [Test]
        public void Create_HomeWorkIsNull_ShouldThrowArgumentNullException()
        {
            // ARRANGE

            //var homeworkRepositoryMock = new HomeWorkRepositoryMock();            
            HomeWork homework = null;

            // ACT
            Assert.ThrowsAsync<ArgumentNullException>(() => _service.Create(homework));

            // ASSERT
            _homeworkRepositoryMock.Verify(x => x.Add(It.IsAny<HomeWork>()), Times.Never);
        }

        [Test]
        [TestCase(null, "test")]
        [TestCase("test", "")]
        [TestCase(null, null)]
        public void Create_HomeWorkIsInValid_ShouldThrowBusinesException(Uri link, string title)
        {
            // ARRANGE
            HomeWork homework = new()
            {
                Link = link,
                Title = title
            };

            // ACT
            Assert.ThrowsAsync<BusinessException>(() => _service.Create(homework));

            // ASSERT
            _homeworkRepositoryMock.Verify(x => x.Add(homework), Times.Never);
        }

        [Test]
        public async Task Delete_ShouldDeleteHomeWork()
        {
            // ARRANGE
            var homeworkId = 1;

            // ACT
            var result = await _service.Delete(homeworkId);

            // ASSERT
            Assert.IsTrue(result);
            _homeworkRepositoryMock.Verify(x => x.Delete(homeworkId), Times.Once);
        }
    }
}