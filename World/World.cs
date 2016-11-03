using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgCubio
{
    public class World
    {
        public Dictionary<long, Cube> players;

        public Dictionary<long, Cube> foods;

        public Dictionary<long, LinkedList<Cube>> splits;

        private Random random;

        public World()
        {
            players = new Dictionary<long, Cube>();
            foods = new Dictionary<long, Cube>();

            random = new Random();
            splits = new Dictionary<long, LinkedList<Cube>>();
        }

        public void addCube(Cube cube)
        {
            if (cube.food)
            {
                if (cube.Mass == 0.0)
                    foods.Remove(cube.uid);
                else
                    foods[cube.uid] = cube;
            }
            else if (cube.Mass == 0.0)
                players.Remove(cube.uid);
            else
                players[cube.uid] = cube;

        }
    }
}
