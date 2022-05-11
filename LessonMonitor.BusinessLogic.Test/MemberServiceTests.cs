using AutoFixture;
using LessonMonitor.Core;
using LessonMonitor.Core.Repositoryes;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.BusinessLogic.Test
{
    public class MemberServiceTests
    {
        private Mock<IMembersRepository> _repositoryMock;
        private Fixture _fixture;
        private MembersService _service;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IMembersRepository>();
            _fixture = new Fixture();
            _service = new MembersService(_repositoryMock.Object);
        }

        [Test]
        public async Task Create_ValidMember_ShouldReturnCreateMemberId()
        {
            // arrange

            var expectedMemberId = _fixture.Create<int>();

            var member = _fixture.Build<Member>()
                .Without(x => x.Id)
                .Create();

            _repositoryMock.Setup(x => x.Add(member))
                .ReturnsAsync(expectedMemberId);

            // act

            var memberId = await _service.Create(member);

            // assert
            Assert.AreEqual(expectedMemberId, memberId);
            _repositoryMock.Verify(x => x.Add(member), Times.Once);
        }
        [Test]
        public void Create_MemberAlreadyExists_ShouldThrowInvalidOperationException()
        {
            // arrange
            var member = _fixture.Build<Member>()
                .Without(x => x.Id)
                .Create();

            _repositoryMock.Setup(x => x.Get(member.YouTubeUserId))
                .ReturnsAsync(member);

            // act
            Assert.ThrowsAsync<InvalidOperationException>(() => _service.Create(member));

            // assert
            _repositoryMock.Verify(x => x.Add(It.IsAny<Member>()), Times.Never);
            _repositoryMock.Verify(x => x.Get(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Create_MemberIsNull_ShouldThrowArgumentNullException()
        {
            // arrange

            // act
            Assert.ThrowsAsync<ArgumentNullException>(() => _service.Create(null));

            // assert
            _repositoryMock.Verify(x => x.Add(It.IsAny<Member>()), Times.Never);
        }

        [Test]
        [TestCase(-123, "test", "test")]
        [TestCase(123, "test", "test")]
        [TestCase(0, "", "test")]
        [TestCase(0, "test", "")]
        [TestCase(0, null, "test")]
        [TestCase(0, "test", null)]
        public void Create_MemberIsInvalid_ShouldThrowInvalidOperationException(int id, string name, string yutubeUserId)
        {
            // arrange
            var member = new Member()
            {
                Id = id,
                Name = name,
                YouTubeUserId = yutubeUserId
            };

            // act
            Assert.ThrowsAsync<InvalidOperationException>(() => _service.Create(member));

            // assert
            _repositoryMock.Verify(x => x.Add(It.IsAny<Member>()), Times.Never);
        }
        [Test]
        public async Task Get_ShouldReturnMembers()
        {
            // arrange
            var membersFixture = _fixture.CreateMany<Member>(25).ToArray();

            _repositoryMock.Setup(x => x.Get())
                .ReturnsAsync(membersFixture);

            // act
            var members = await _service.Get();

            // assert
            Assert.IsNotEmpty(members);
            Assert.NotNull(members);
            Assert.AreEqual(members.Length, membersFixture.Length);

            _repositoryMock.Verify(x => x.Get(), Times.Once);
        }
    }
}
