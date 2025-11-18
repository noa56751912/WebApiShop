using System.IO;
using System.Text.Json;
using Entity;
namespace Repository
{
    public class RepositoryUser : IRepositoryUser
    {
        string path = "file.txt";
        public User? GetUserById(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(path))
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
            using (StreamReader reader = System.IO.File.OpenText(path))
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
            int numberOfUsers = System.IO.File.ReadLines(path).Count();
            newUser.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(newUser);
            System.IO.File.AppendAllText(path, userJson + Environment.NewLine);
            return newUser;
        }
        public void Update(int id, User updateUser)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(path))
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
                string text = System.IO.File.ReadAllText(path);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(updateUser));
                System.IO.File.WriteAllText(path, text);
            }
        }

        public void Delete(int id)
        {
        }

    }


}
