using System;

namespace src.Modules.Entities
{
    public class FavoriteJob
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid JobId { get; set; }
        public Job Job { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}