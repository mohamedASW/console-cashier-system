namespace SalesSystem.Model
{
    abstract public class User
    {
       
       
        private string id;
       
        public string User_Id { get => id; private set => id = value; }
        public string Name { get; set; } = string.Empty;
        public User (string userid,string name)
        {
            User_Id = userid;
            Name = name;
        }

    }
}
