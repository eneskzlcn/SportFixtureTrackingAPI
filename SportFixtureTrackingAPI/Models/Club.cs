using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public virtual ICollection<Team> Teams { get; set; }
    }
}
