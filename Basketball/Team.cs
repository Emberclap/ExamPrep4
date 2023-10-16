using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            Players = new List<Player>();
        }

        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public List<Player> Players { get; set; }
        public int Count => Players.Count;

        public string AddPlayer(Player player)
        {
            if (OpenPositions > 0)
            {
                if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
                {
                   return "Invalid player's information.";
                }
                else
                {
                    if (player.Rating < 80)
                    {
                        return "Invalid player's rating.";
                    }
                    else
                    {
                        Players.Add(player);
                        OpenPositions--;
                        return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
                    }
                }
            }
            else
            {
                return "There are no more open positions.";
            }
        }

        public bool RemovePlayer(string name)
        {
            if(Players.Remove(Players.FirstOrDefault(p => p.Name == name)))
            {
                OpenPositions++;
                return true;
            }
            return false;

        }
        public int RemovePlayerByPosition(string position)
        {
            int removed = 0;
            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].Position == position)
                {
                    removed++;
                    Players.Remove(Players[i]);
                    i--;
                    OpenPositions++;
                }
            }
            return removed;

        }
        public Player RetirePlayer(string name)
        {
            Player player = Players.FirstOrDefault(p => p.Name == name);
            if (player == null)
            {
                return player;
            }
                player.Retired = true;
                return player;
        }
        public List<Player> AwardPlayers (int games)
        {
            List<Player> list = new List<Player>();
            foreach (var player in Players)
            {
                if(player.Games >= games)
                {
                    list.Add(player);
                }
            }
            return list;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
           
                sb.AppendLine($"Active players competing for Team {this.Name} from Group {Group}:");
                foreach (var player in Players.Where(x => x.Retired != true))
                {
                    sb.AppendLine(player.ToString());
                }

            return sb.ToString().TrimEnd();
        }

    }
}
