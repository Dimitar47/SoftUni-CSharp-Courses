using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly List<IPlayer> players;
        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models => players;

        public void AddModel(IPlayer model)
        {
            players.Add(model);
        }
        public bool RemoveModel(string name)
        {
            return players.Remove(GetModel(name));
        }
        public bool ExistsModel(string name)
        {
            IPlayer player = players.FirstOrDefault(x => x.Name == name);
            return players.Contains(player);
           
        }

        public IPlayer GetModel(string name)
        {
            return players.FirstOrDefault(x => x.Name == name);
        }

      
    }
}
