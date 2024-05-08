using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
                try
                {
                    db.Videogames.Add(videogame);
                    db.SaveChanges();
                    Console.WriteLine("Videogioco aggiunto con successo!");
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine("Errore durante il salvataggio delle modifiche dell'entità:");
                    Console.WriteLine(ex.InnerException?.Message);
                }
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

        public static void PrintAllSoftwareHouses()
        {
            using (var db = new VideogameContext())
            {
                var softwareHouses = db.SoftwareHouses.ToList();

                if (softwareHouses.Any())
                {
                    Console.WriteLine("Elenco delle Software Houses:");
                    foreach (var softwareHouse in softwareHouses)
                    {
                        Console.WriteLine($"ID: {softwareHouse.SoftwareHouseId} {softwareHouse.Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Nessuna Software House trovata.");
                }
            }
        }

        public static SoftwareHouse GetSofwareHouseById(int id)
        {
            using (var db = new VideogameContext())
            {
                var softwareHouse = db.SoftwareHouses.FirstOrDefault(v => v.SoftwareHouseId == id);

                if (softwareHouse == null)
                {
                    Console.WriteLine("Software House not found");
                }

                return softwareHouse;
            }
        }
    }
}
