using System.Collections.Generic;

namespace DojoClassLibrary
{
    public class Samourai : IdEntity
    {
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }
        public virtual List<ArtMartial> ArtMartiaux { get; set; } = new List<ArtMartial>();
    }
}
