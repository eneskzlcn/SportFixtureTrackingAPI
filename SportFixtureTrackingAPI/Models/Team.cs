
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace SportFixtureTrackingAPI.Models
{
    public partial class Team
    {
        public Team()
        {
            FixtureAwayTeams = new HashSet<Fixture>();
            FixtureHomeTeams = new HashSet<Fixture>();
            FixtureResults = new HashSet<FixtureResult>();
        }

        public int TeamId { get; set; }
        public int ClubId { get; set; }
        public int SportId { get; set; }
        public string TeamName { get; set; }
        public int PlayerCount { get; set; }

      
        public virtual Club Club { get; set; }
        
        public virtual Sport Sport { get; set; }
        [JsonIgnore]
        public virtual ICollection<Fixture> FixtureAwayTeams { get; set; }
        [JsonIgnore]
        public virtual ICollection<Fixture> FixtureHomeTeams { get; set; }
        [JsonIgnore]
        public virtual ICollection<FixtureResult> FixtureResults { get; set; }
    }
}
