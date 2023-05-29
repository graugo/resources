using AdventureApp.Infrastructure.Contracts.Contracts;
using AdventureApp.Library.Models;
using AdventureApp.ServiceLibrary.Impl.Implementations;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureApp.ServiceLibrary.Impl.UnitTest
{
    public class CharacterServiceTest
    {
        private readonly Mock<ICharacterRepository> _characterRepositoryMock;

        public CharacterServiceTest()
        {
            _characterRepositoryMock = new Mock<ICharacterRepository>();
        }

        [Fact]
        public void GetCharacter_OK()
        {
            _characterRepositoryMock.Setup(x => x.GetCharacter(It.IsAny<string>())).Returns(
                new CharacterEntity
                {
                    Id = new Guid("4a4f9e55-0f38-47d1-9f61-af781970ac33"),
                    Name = "ewq",
                    CharacterClass = "ewq",
                    Weapons = new List<WeaponEntity>
                    {
                        new WeaponEntity ()
                    }
                }
            );

            var sut = new CharacterService(_characterRepositoryMock.Object);
            var result = sut.GetCharacter("4a4f9e55-0f38-47d2-9f61-af781970ac33");

            Assert.NotNull( result );
            Assert.Equal(new Guid("4a4f9e55-0f38-47d1-9f61-af781970ac33"), result.Id);
            Assert.Equal("ewq", result.Name);
        }
    }
}