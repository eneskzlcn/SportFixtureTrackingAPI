using System;
using System.Collections.Generic;

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
        public virtual ICollection<Fixture> FixtureAwayTeams { get; set; }
        public virtual ICollection<Fixture> FixtureHomeTeams { get; set; }
        public virtual ICollection<FixtureResult> FixtureResults { get; set; }
    }
}
