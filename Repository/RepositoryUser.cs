using System.IO;
using System.Text.Json;
using Entity;
namespace Repository
{
    public class RepositoryUser : IRepositoryUser
    {
        private readonly string _path = Path.Combine(Directory.GetCurrentDirectory(), "file.txt");
        public User? GetUserById(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(_path))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User? user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user?.Id == id)
                        return user;
                }
                return null;
            }

        }

        public User? Login(ExistingUser existingUser)
        {
            using (StreamReader reader = System.IO.File.OpenText(_path))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User? user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user?.Email == existingUser.Email && user.Password == existingUser.Password)
                        return user;
                }
                return null;
            }

        }
        public User? Register(User newUser)
        {
            //int loggedInId = sessionStorage.getItem('currentUserId');
            int numberOfUsers = System.IO.File.ReadLines(_path).Count();
            newUser.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(newUser);
            System.IO.File.AppendAllText(_path, userJson + Environment.NewLine);
            return newUser;
        }
        public void Update(int id, User updateUser)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(_path))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User? user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user?.Id == id)
                        textToReplace = currentUserInFile;
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(_path);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(updateUser));
                System.IO.File.WriteAllText(_path, text);;
            }
        }
    }


}
