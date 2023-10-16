using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeStore
{
    public class ShoeStore
    {
        public ShoeStore(string name, int storeCapacity)
        {
            Name = name;
            StorageCapacity = storeCapacity;
            Shoes = new List<Shoe>();
        }

        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        public List<Shoe> Shoes { get; set; }

        public int Count => Shoes.Count;

        public string AddShoe(Shoe shoe)
        {
            if (this.StorageCapacity > this.Count)
            {
                Shoes.Add(shoe);
                return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
            }
            else
            {
                return "No more space in the storage room.";
            }
        }
        public int RemoveShoes(string material)
        {
            int removed = 0;
            for (int i = 0; i < Shoes.Count; i++)
            {
                if (Shoes[i].Material == material)
                {
                    removed++;
                    Shoes.Remove(Shoes[i]);
                    i--;
                }
            }
            return removed;
        }
        public List<Shoe> GetShoesByType(string type)
        {
            List<Shoe> shoes = new List<Shoe>();

            foreach (Shoe shoe in Shoes.Where(x => x.Type == type.ToLower()))
            {
                shoes.Add(shoe);
            }
            return shoes;
        }
        public Shoe GetShoeBySize(double size) => Shoes.FirstOrDefault(x => x.Size == size);


        public string StockList(double size, string type)
        {
            StringBuilder sb = new StringBuilder();
            if (Shoes.Any(x => x.Size == size && x.Type == type))
            {
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");
                foreach (var cloth in Shoes.Where(x => x.Size == size && x.Type == type))
                {
                    sb.AppendLine(cloth.ToString());
                }
            }
            else
            {
                sb.AppendLine("No matches found!");
            }
            
            return sb.ToString().TrimEnd();

        }

    }
}
