using AutoFixture;
using LessonMonitor.Core;
using LessonMonitor.Core.Repositoryes;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.BusinessLogic.Test
{
    public class LessonServiceTests
    {
        private Fixture _fixture;
        private Mock<ILessonsRepository> _repository;
        private LessonService _service;

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture();
            _repository = new Mock<ILessonsRepository>();
            _service = new LessonService(_repository.Object);
        }

        [Test]
        public async Task Create_LessonIsValid_ShouldReturnLessonId()
        {
            // arrange
            var lesson = _fixture.Create<Lesson>();
            int expectedLessonId = _fixture.Create<int>();

            _repository.Setup(x => x.Add(lesson))
                .ReturnsAsync(expectedLessonId);

            _repository.Setup(x => x.Get(lesson.YouTubeBroadcastId))
                .ReturnsAsync(() => null);

            // act
            int lessonId = await _service.Create(lesson);

            // assert
            Assert.AreEqual(lessonId, expectedLessonId);
            _repository.Verify(x => x.Add(lesson), Times.Once);
        }
    }
}
