using api.FriendsVersus.Auth;
using api.FriendsVersus.Data;
using api.FriendsVersus.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsVersusTests.AuthTests
{
    [TestClass]
    public class TokenTest
    {
        [TestMethod]
        public async Task TestCanTokenBeCreated()
        {
            Mock<IUserData> mockUserData = new Mock<IUserData>();
            mockUserData.Setup(userData => userData.GetUserIfExists(It.IsAny<string>())).Returns(Task.FromResult(new User
            {
                Username = "Superspecialnumber1user",
                Email = "SomeEmailAddress",
                DateJoined = "SomeRandomDate"
            }));
            Mock<IConfiguration> mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.Setup(config => config["Jwt:Issuer"]).Returns("anyText");
            mockConfiguration.Setup(config => config["Jwt:Key"]).Returns("anyText2ElectricBoogaloo");
            
            TokenManager manager = new TokenManager(mockConfiguration.Object, mockUserData.Object);

            string token = await manager.GrantToken("Text0");

            Assert.IsNotNull(token);

        }
    }
}
