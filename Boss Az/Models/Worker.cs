using Boss_Az.Services;

namespace Boss_Az.Models
{
    public class Worker : Service
    {
        private string? name;
        private string? surname;
        private string? email;
        private string? password;

        public string? Name { get => name; set { name = value; OnPropertyChanged(); } }
        public string? Surname { get => surname; set { surname = value; OnPropertyChanged(); } }
        public string? Email { get => email; set { email = value; OnPropertyChanged(); } }
        public string? Password { get => password; set { password = value; OnPropertyChanged(); } }

        public Worker()
        {

        }
        public Worker(string? name, string? surname, string? email, string? password)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
        }
    }
}
