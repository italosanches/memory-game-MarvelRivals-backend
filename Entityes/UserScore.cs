using System.Text.Json.Serialization;

namespace MemoryGame.Entityes
{
    public class UserScore
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int Score {get; set; }
        public int CardsQuantity{get; set; }
        public TimeSpan GameTime { get; set; }
        public DateOnly GameDate { get; set; }  

    }
}
