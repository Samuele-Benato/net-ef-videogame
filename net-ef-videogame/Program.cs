namespace net_ef_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Scegli un'opzione:");
            Console.WriteLine("1. Inserisci un videogioco");
            Console.WriteLine("2. Ricerca un videogioco per ID");
            Console.WriteLine("3. Ricerca un videogioco per parola");
            Console.WriteLine("4. Elimina un videogioco");
            Console.WriteLine("5. Inserisci una software house");
            Console.WriteLine("6. Esci");

            string choice = Console.ReadLine();

            switch (choice)
            {

                case "1":
                    InsertVideogame();
                    break;
                case "2":
                    GetVideogameById();
                    break;
                case "3":
                    GetVideogameByInput();
                    break;
                case "4":
                    DeleteVideogame();
                    break;
                case "5":
                    InsertSoftwareHouse();
                    break;
                case "6":
                    Console.WriteLine("Programma chiuso.");
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }

            static void InsertVideogame()
            {
                try
                {
                    Console.Write("1. inserisci il nome : ");
                    string name = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(name))
                    {
                        throw new ArgumentException("Il nome non può essere vuoto.");
                    }

                    Console.Write("2. inserisci la trama : ");
                    string overview = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(overview))
                    {
                        throw new ArgumentException("la descrizione non può essere vuota.");
                    }

                    Console.WriteLine($"3. inserisci la data di rilascio (formato YYYY-MM-DD) : ");
                    DateTime releaseDate;
                    while (!DateTime.TryParse(Console.ReadLine(), out releaseDate))
                    {
                        Console.WriteLine("Data non valida, riprova.");
                        Console.WriteLine("Scrivi una data (formato YYYY-MM-DD)");
                    }

                    DateTime createdAt = DateTime.Now;
                    DateTime updatedAt = DateTime.Now;

                    Console.WriteLine("Inserisci l'ID della softwarehouse:");
                    VideogameManagement.PrintAllSoftwareHouses();
                    if (!int.TryParse(Console.ReadLine(), out int id))
                    {
                        throw new FormatException("L'ID deve essere un numero intero.");
                    }

                    SoftwareHouse softwarehouse = VideogameManagement.GetSofwareHouseById(id);

                    Videogame videogame = new Videogame
                    {
                        Name = name,
                        Overview = overview,
                        ReleaseDate = releaseDate,
                        CreatedAt = createdAt,
                        UpdatedAt = updatedAt,
                        SoftwareHouseId = id, 
                        SoftwareHouse = softwarehouse
                    };

                    VideogameManagement.InsertVideogame(videogame);
                    Console.WriteLine("Aggiunta avvenuta con successo!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            static void GetVideogameById()
            {
                try
                {
                    Console.Write("Inserisci l'ID del videogioco:");
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out int id))
                    {
                        throw new FormatException("L'ID deve essere un numero intero.");
                    }

                    string result = VideogameManagement.GetVideogameById(id);
                    Console.WriteLine(result);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            static void GetVideogameByInput()
            {
                try
                {
                    Console.Write("Inserisci parola chiave:");
                    string input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        throw new ArgumentException("la descrizione non può essere vuota.");
                    }
                    string result = VideogameManagement.GetVideogameByInput(input);
                    Console.WriteLine(result);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            static void DeleteVideogame()
            {
                try
                {
                    Console.WriteLine("Inserisci il nome del videogioco per confermare l'eliminazione");
                    string name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        throw new ArgumentException("la descrizione non può essere vuota.");
                    }
                    VideogameManagement.DeleteVideogame(name);
                    Console.WriteLine("Eliminazione avvenuta con successo!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            static void InsertSoftwareHouse()
            {
                try
                {
                    Console.Write("1. Inserisci il nome della software house: ");
                    string name = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(name))
                    {
                        throw new ArgumentException("Il nome della software house non può essere vuoto.");
                    }

                    SoftwareHouse softwareHouse = new SoftwareHouse(name);

                    VideogameManagement.InsertSoftwareHouse(softwareHouse);
                    Console.WriteLine("Software house aggiunta con successo!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            
        }
    }
}
