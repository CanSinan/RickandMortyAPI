namespace RickAndMorty.Data.Entities
{
    public class Episode: BaseEntity
    {
        public string Name { get; set; }
        public string AirDate { get; set; }
        public string EpisodeCode { get; set; }
        public ICollection<Character> Characters { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }
    }
}
