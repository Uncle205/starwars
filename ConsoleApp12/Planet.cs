using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp12
{
  public  class Planet
    {
               public int Id { get; set; }
            public string Name { get; set; }
            public string Rotation_period { get; set; }
            public string Orbital_period { get; set; }
            public string Diameter { get; set; }
            public string Climate { get; set; }
            public string Gravity { get; set; }
            public string Terrain { get; set; }
            public string Surface_water { get; set; }
            public string Population { get; set; }
            public IList<string> Residents { get; set; }
            public IList<string> Films { get; set; }
            public DateTime Created { get; set; }
            public DateTime Edited { get; set; }
            public string Url { get; set; }
        }

        public class Example
        {
            public int count { get; set; }
            public string next { get; set; }
            public object previous { get; set; }
            public IList<Planet> results { get; set; }
        }

    }

