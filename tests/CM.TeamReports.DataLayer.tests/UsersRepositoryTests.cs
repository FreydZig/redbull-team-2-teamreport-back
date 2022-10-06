using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Repositories;
using Xunit;

namespace CM.TeamReports.DataLayer.tests
{
    public class UsersRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToGetAllUsers()
        {
            UsersRepository user = new UsersRepository();

            var users = user.GetAll();

            Assert.Equal(3, users.Count);
        }

        [Fact]
        public void ShouldBeAbleToGetAllUsersByTeamId()
        {
            UsersRepository user = new UsersRepository();

            var users = user.GetAll(1);

            Assert.Equal(2, users.Count);
        }

        [Fact]
        public void ShouldBeAbleToReturnUser()
        {
            UsersRepository user = new UsersRepository();

            var user2 = user.Read(28);

            Assert.Equal(28, user2.UserId);
        }

        [Fact]
        public void ShouldBeAbleToReturnUserByEmail()
        {
            UsersRepository user = new UsersRepository();

            var user2 = user.Read("second@example.com");

            Assert.Equal(31, user2.UserId);
        }

        [Fact]
        public void ShouldNotBeAbleToReturnUserByEmail()
        {
            UsersRepository user = new UsersRepository();

            var user2 = user.Read("usr@example.com");

            Assert.Null(user2);
        }

        [Fact]
        public void ShouldBeAbleToCreateUser()
        {
            UsersRepository users = new UsersRepository();

            users.Create(new Users { 
                TeamId = 14, 
                FirstName = "Tom", 
                LastName = "Tom", 
                Title = "dawdwadw",
                Email = "bon@mail.com", 
                Password = "qwerty" 
            });

            Assert.Equal("Tom", users.Read(39).FirstName);
            Assert.Equal("dawdwadw", users.Read(39).Title);
        }

        [Fact]
        public void ShouldBeAbleToUpdateUser()
        {
            UsersRepository users = new UsersRepository();

            users.Update(new Users { 
                UserId= 39 ,
                TeamId = 14, 
                FirstName = "Tim", 
                LastName = "Tim", 
                Email = "dawd@mail.com", 
                Password = "12345566"
            });

            Assert.Equal("Tim", users.Read(39).FirstName);
        }

        [Fact]
        public void ShouldBeAbleToDeleteUser()
        {
            UsersRepository users = new UsersRepository();

            users.Delete(40);

            Assert.Null(users.Read(40));
        }
    }
}
