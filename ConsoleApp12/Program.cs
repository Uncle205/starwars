using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net;
using Newtonsoft.Json;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace ConsoleApp12
{
    class Program
    {
        public List<Person> People
        {
            get { return people; }
            set { people = value; }

        }
        private List<Planet> planets = new List<Planet>();
        private List<Person> people = new List<Person>();
        public List<Planet> Planets
        {
            get { return planets; }
            set { planets = value; }
        }

        private List<StarShips> starships = new List<StarShips>();
        public List<StarShips> Starships
        {
            get { return starships; }
            set { starships = value; }
        }
        static List<KeyValuePair<int, int>> PeopleToStarships { get; set; }
        static List<KeyValuePair<int, int>> PeopleToPlanets { get; set; }
        static List<KeyValuePair<int, int>> PlanetsToStarships { get; set; }
      
        static void Main(string[] args)
        {
            using (var client = new WebClient())
            {
                string result = client.DownloadString("https://swapi.co/api/people/1");
                string result2 = client.DownloadString("https://swapi.co/api/planets");
                string result3 = client.DownloadString("https://swapi.co/api/starships");
                

            }  PeopleToStarships = new List<KeyValuePair<int, int>>();
                PeopleToPlanets = new List<KeyValuePair<int, int>>();
                PlanetsToStarships = new List<KeyValuePair<int, int>>();

        }


       
        public void AddId()
        {
            for (int i = 0; i < People.Count; i++)
            {
                People[i].Id = i;
            }
            for (int i = 0; i < Starships.Count; i++)
            {
                Starships[i].Id = i;
            }
            for (int i = 0; i < Planets.Count; i++)
            {
                Planets[i].Id = i;
            }
        }
        public void AddConnections()
        {
            foreach (var item in Starships)
            {
                var pilots = item.pilots;
                for (int i = 0; i < pilots.Count; i++)
                {
                    PeopleToStarships.Add(new KeyValuePair<int, int>(People.Where(a => a.Url == pilots[i]).First().Id, item.Id));
                } //PeopleToStarships
            }

            foreach (var item in starships)
            {
                var pilots = item.pilots;
                for (int i = 0; i < pilots.Count; i++)
                {
                    PeopleToStarships.Add(new KeyValuePair<int, int>(People.Where(a => a.Url == pilots[i]).First().Id, item.Id));
                } //PeopleToStarships
            }
        }
        public static bool ExecuteInTransaction(DbConnection connection, params DbCommand[] commands)
        {
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    foreach (var command in commands)
                    {
                        command.Transaction = transaction;
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    return true;
                }
                catch (SqlException exception)
                {
                    Console.WriteLine(exception.Message);
                    transaction.Rollback();
                    return false;
                }
                catch (DbException exception)
                {
                    Console.WriteLine(exception.Message);
                    transaction.Rollback();
                    return false;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    transaction.Rollback();
                    return false;
                }

            }
        }
    }
}


    
