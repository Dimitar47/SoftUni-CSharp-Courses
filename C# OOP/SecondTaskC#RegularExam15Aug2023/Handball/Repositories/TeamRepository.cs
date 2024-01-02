using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private readonly List<ITeam> teams;
        public TeamRepository()
        {
            teams = new List<ITeam>();
        }
        public IReadOnlyCollection<ITeam> Models => teams;

        public void AddModel(ITeam model)
        {
            teams.Add(model);
        }

        public bool RemoveModel(string name)
        {
            return teams.Remove(GetModel(name));
        }
        public bool ExistsModel(string name)
        {
            ITeam team = teams.FirstOrDefault(x => x.Name == name);
            return teams.Contains(team);

        }

        public ITeam GetModel(string name)
        {
            return teams.FirstOrDefault(x => x.Name == name);
        }

    }
}
