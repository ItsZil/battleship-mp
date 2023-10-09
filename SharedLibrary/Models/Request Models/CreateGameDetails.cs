namespace SharedLibrary.Models.Request_Models
{
    public class CreateGameDetails
    {
        public string CreatorId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string LevelName { get; set; }

        public CreateGameDetails(string CreatorId, string Name, string Password, string LevelName)
        {
            this.CreatorId = CreatorId;
            this.Name = Name;
            this.Password = Password;
            this.LevelName = LevelName;
        }
    }
}
