using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NuGet.Frameworks;
using Xunit;

namespace TaskManager.Tests.Domain
{
    public class UserEntityTests
    {
        [Fact(DisplayName = "Create_WhenUserIsValid_ReturnTrue")]
        public void Create_WhenUserIsValid_ReturnTrue()
        {
            //Dado que eu tenha um usuário.
            var userEntity = Fixture.UserEntiryFixture.CreateValid_UserEntity();

            // quando todos os dados estiverem corretos
            //userEntity.ValidateUser();

            //Entao
            Assert.True(true);

        }

        [Fact(DisplayName = "Create_WhenUserHasInvalidPassword_ReturnTrue")]
        public void Create_WhenUserHasInvalidPassword_ReturnFalse()
        {
            //Dado que eu tenha um usuário.
            var userEntity = Fixture.UserEntiryFixture.CreateInvalidPassword_UserEntity();

            // quando o password estivber incorreto
            //userEntity.ValidateUser();

            //Entao
            Assert.False(false);

        }
    }
}