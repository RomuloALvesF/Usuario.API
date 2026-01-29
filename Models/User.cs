namespace Usuario.API.Models
{
    public class User
    {
        public Guid Id { get;set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; private set; }
        public DateTime Date {  get;set; }

        public User() { }

        public User(string name, string email, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
            Date = DateTime.Now;
        }
    }
}
