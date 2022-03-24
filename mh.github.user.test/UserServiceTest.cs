using System;
using System.Collections.Generic;
using System.Linq;
using mh.github.user.entity;
using mh.github.user.interfaces.Data;
using mh.github.user.service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace mh.github.user.test;

[TestClass]
public class UserServiceTest
{

    private readonly UserService userService;
    private readonly Mock<IUserRepository> userRepository;

    private readonly List<User> mockUsers;
    private Guid user1 = Guid.Parse("44d7b083-bf7a-4de2-98f7-5e3566a1f56e");
    private Guid user2 = Guid.Parse("169c7f56-0f9b-4f0e-bebe-fcc18c65d8aa");

    public UserServiceTest()
    {
        this.userRepository = new Mock<IUserRepository>();
        this.userService = new UserService(this.userRepository.Object);

        this.mockUsers = new List<User>
        {
            new User { Id = user1, FirstName = "Test", LastName = "User", EmailAddress = "ts1@test.com"},
            new User { Id = user2, FirstName = "Test2", LastName = "User", EmailAddress = "ts2@test.com"}

        };
    }

    [TestMethod]
    public async void GetUsers()
    {
        var users =
        this.userRepository.Setup(u => u.GetUsersAsync())
            .ReturnsAsync(mockUsers);

        var result = await userService.GetUsersAsync();

        Assert.IsNotNull(result);
        Assert.AreEqual(mockUsers.Count, result.Count());
    }
}
