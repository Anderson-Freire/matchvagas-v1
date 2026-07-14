using System;

namespace src.Modules.Entities
{
    public class SearchHistory : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string SearchTerm { get; set; }
        public string Filters { get; set; }
    }
}