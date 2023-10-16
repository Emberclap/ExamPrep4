using System;
using System.Collections.Generic;
using System.Text;

namespace Basketball
{
    public class Player
    {
        public Player(string name, string position, double rating, int games)
        {
            Name = name;
            Position = position;
            Rating = rating;
            Games = games;
            Retired = false;
        }

        public string Name { get; set; }    
        public string Position { get; set; }
        public double Rating { get; set; }
        public int Games { get; set; }
        public bool Retired { get; set; }

        public override string ToString()
        {
            //return $"-Player: {Name} \n--Position: {Position} \n--Rating: {Rating} \n--Games played: {Games}";
            var sb = new StringBuilder();
            sb.AppendLine($"-Player: { this.Name}");
            sb.AppendLine($"--Position: {this.Position}");
            sb.AppendLine($"--Rating: {this.Rating}");
            sb.AppendLine($"--Games played: {this.Games}");
            return sb.ToString().TrimEnd();

        }
    }
}
