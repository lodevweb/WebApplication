using DojoClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tp6.Models
{
    public class SamouraiViewModel
    {
        public Samourai Samourai {get; set; }
        public List<Arme> Armes { get; set; }
        public int ? ArmeId { get; set; }
   //     public List<ArtMartial> ArtMartials { get; set; }
    }
}