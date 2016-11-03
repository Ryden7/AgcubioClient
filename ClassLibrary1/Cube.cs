using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Sockets;

namespace AgCubio
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Cube
    {
        [JsonProperty]
        public double loc_x { get; set; }
        [JsonProperty]
        public double loc_y { get; set; }
        [JsonProperty]
        public int argb_color { get; set; }
        [JsonProperty]
        public long uid { get; set; }
        [JsonProperty]
        public bool food { get; set; }
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public double Mass { get; set; }
        public double teamID { get; set; }


        [JsonConstructor]
        public Cube(double loc_x, double loc_y, int color, long uid, bool food, string name, double mass)
        {
            this.loc_x = loc_x;
            this.loc_y = loc_y;
            this.argb_color = color;
            this.uid = uid;
            this.food = food;
            this.Name = name;
            this.Mass = mass;

        }

        public float getWidth()
        {
            return (float)Math.Pow(Mass, 0.63);
        }
    }
}