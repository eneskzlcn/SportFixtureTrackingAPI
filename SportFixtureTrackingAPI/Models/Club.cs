using System;
using System.Collections.Generic;

#nullable disable

namespace SportFixtureTrackingAPI.Models
{
    public partial class Club
    {
        public Club()
        {
            Teams = new HashSet<Team>();
        }

        public int ClubId { get; set; }
        public string ClubName { get; set; }
        public string ClubDescription { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
