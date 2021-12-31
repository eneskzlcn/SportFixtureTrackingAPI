using System;
using System.Collections.Generic;

#nullable disable

namespace SportFixtureTrackingAPI.Models
{
    public partial class Fixture
    {
        public Fixture()
        {
            FixtureResults = new HashSet<FixtureResult>();
        }

        public int FixtureId { get; set; }
        public DateTime FixtureDate { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public string FixtureHome { get; set; }
        public string IsFinished { get; set; }

        public virtual Team AwayTeam { get; set; }
        public virtual Team HomeTeam { get; set; }
        public virtual ICollection<FixtureResult> FixtureResults { get; set; }
    }
}
