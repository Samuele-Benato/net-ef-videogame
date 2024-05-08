using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    [Table("videogame")]
    public class Videogame
    {
        [Key] 
        public int VideogameId { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int SoftwareHouseId { get; set; }
        public SoftwareHouse SoftwareHouse { get; set; }

        public Videogame() { }
        public Videogame(string name, string overview, DateTime relesedate, DateTime createdat, DateTime updateat, int softwarehouseid, SoftwareHouse softwarehouse)
        {
            Name = name;
            Overview = overview;
            ReleaseDate = relesedate;
            CreatedAt = createdat;
            UpdatedAt = updateat;
            SoftwareHouseId = softwarehouseid;
            SoftwareHouse = softwarehouse;
        }
    }
}
