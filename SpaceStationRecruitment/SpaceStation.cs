using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {

        private List<Astronaut> Astronauts;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => Astronauts.Count;

        public SpaceStation(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Astronauts = new List<Astronaut>();
        }

        public void Add(Astronaut astronaut)
        {
            Astronauts.Add(astronaut);
        }

        public bool Remove(string name)
        {
            Astronaut astronaut = Astronauts.Find(x => x.Name == name);
            if (astronaut != null)
            {
                Astronauts.Remove(astronaut);
                return true;
            }
            return false;
        }

        public Astronaut GetOldestAstronaut()
        {
            Astronauts.Sort();
            return Astronauts[0];
           /* int maxAge = 0;
            Astronaut oldest = null;
            foreach (var astronaut in Astronauts)
            {
                if (astronaut.Age > maxAge)
                {
                    maxAge = astronaut.Age;
                    oldest = astronaut;
                }
            }

            return oldest; */
        }

        public Astronaut GetAstronaut(string name)
        {
            Astronaut astronaut = Astronauts.Find(x => x.Name == name);
            return astronaut;
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder($"Astronauts working at Space Station {this.Name}:\n");
            foreach (var astronaut in Astronauts)
            {
                result.Append(astronaut);
                result.Append("\n");
            }
            return result.ToString();
        }
    }
}
