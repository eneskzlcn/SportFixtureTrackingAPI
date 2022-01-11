using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace SportFixtureTrackingAPI.Models
{
    public partial class Sport
    {
        public Sport()
        {
            Teams = new HashSet<Team>();
        }

        public int SportId { get; set; }
        public string SportName { get; set; }
        public string SportDescription { get; set; }
        public int RequiredTeamPlayerCount { get; set; }
        [JsonIgnore]
        public virtual ICollection<Team> Teams { get; set; }
    }
}
