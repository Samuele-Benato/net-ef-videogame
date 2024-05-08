using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public static class VideogameManagement
    {
        const string CONNECT_DATABASE = "Server=localhost;Database=db-newvideogames;Trusted_Connection=True";
        public static void InsertVideogame( Videogame videogame)
        {
            using (var db = new VideogameContext())
            {
                db.Videogames.Add(videogame);
                db.SaveChanges();
            }
        }

        public static string GetVideogameById(int id)
        {
            using (var db = new VideogameContext())
            {
                var videogame = db.Videogames.FirstOrDefault(v => v.VideogameId == id);

                if (videogame != null)
                {
                    return $"ID: {videogame.VideogameId}, Name: {videogame.Name}, Overview: {videogame.Overview}";
                }
                else
                {
                    return "Videogame not found.";
                }
            }
        }

        public static string GetVideogameByInput(string input)
        {
            using (var db = new VideogameContext())
            {
                var videogame = db.Videogames.FirstOrDefault(v => v.Name.Contains(input) || v.Overview.Contains(input));

                if (videogame != null)
                {
                    return $"ID: {videogame.VideogameId}, Name: {videogame.Name}, Overview: {videogame.Overview}";
                }
                else
                {
                    return "Videogame not found";
                }
            }
        }
        public static void DeleteVideogame(string name)
        {
            using (var db = new VideogameContext())
            {
                var videogame = db.Videogames.FirstOrDefault(v => v.Name == name);

                if (videogame != null)
                {
                    db.Videogames.Remove(videogame);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Videogame not found");
                }
            }
        }

        public static void InsertSoftwareHouse(SoftwareHouse softwarehouse)
        {
            using (var db = new VideogameContext())
            {
                db.SoftwareHouses.Add(softwarehouse);
                db.SaveChanges();
            }
        }
    }
}
