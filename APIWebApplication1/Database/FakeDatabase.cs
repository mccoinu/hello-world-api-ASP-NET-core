using Microsoft.OpenApi.Any;

namespace APIWebApplication1.Database
{
    public class FakeDatabase
    {
        private static int GlobalId = 0;
        public List<User> Users { get; set; }

        public FakeDatabase() { 
            Users = new List<User>();
            AddUserInternal(new User
            {
                UserName = "UserName1",
                Name = "Name1",
                Surname = "Surname1",
                Password = "Password1"
            });            
            AddUserInternal(new User
            {
                UserName = "UserName2",
                Name = "Name2",
                Surname = "Surname2",
                Password = "Password2"
            });            
            AddUserInternal(new User
            {
                UserName = "UserName3",
                Name = "Name3",
                Surname = "Surname3",
                Password = "Password3"
            });            
            AddUserInternal(new User
            {
                UserName = "UserName4",
                Name = "Name4",
                Surname = "Surname4",
                Password = "Password4"
            });           
        
        }

        public void AddUser (User user)
        {
            AddUserInternal(user);
        }

        private void AddUserInternal(User user)
        {
            GlobalId++;
            user.IdUser=GlobalId;
            Users.Add (user);   
        }


    }

    public class User
    {
        public int IdUser { get; set; }
        public string? UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }

    }
}
