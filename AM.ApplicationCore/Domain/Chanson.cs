using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain
{
    public enum StyleMusical
    {
        Classique,Pop,Rap,Rock
    }
    public class Chanson
    {
        public int ChansonId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateSortie { get; set; }
        public int Duree { get; set; }
        public int MyProperty { get; set; }
        public StyleMusical StyleMusical { get; set; }
        [MaxLength(12)]
        [MinLength(3)]
        public string Titre { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "VuesYoutube doit être un entier positif.")]
        public int VuesYoutube { get; set; }
        public Artiste Artiste { get; set; }
        [ForeignKey("Artiste")]
        public int ArtisteFk { get; set; }
    }
}

