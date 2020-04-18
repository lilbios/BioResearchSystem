using System.Collections.Generic;

namespace bioResearchSystem.DTO.Entities
{
    public class Topic : Entity
    {
        public string TopicName { get; set; }
        public ICollection<Research> Researches { get; set; }
        public byte[] TopicPicture { get; set; }

    }
}
