using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    [Table("software_house")]
    public class SoftwareHouse
    {
        [Key] public int SoftwareHouseId { get; set; }
        public string Name { get; set; }
        public List<Videogame> Videogames { get; set; }


        public SoftwareHouse(int id, string name)
        {
            SoftwareHouseId = id;
            Name = name;
        }
    }
}
