using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClient_PI_21_01.Models
{
    [FilterableModel]
    public class AnimalCard
    {
        public int IdAnimalCard { set; get; }
        [Filterable("category")]
        public string Category { get; set; }
        [Filterable("sex")]
        public string Gender { get; set; }
        [Filterable("breed")]
        public string Breed { get; set; }
        [Filterable("sizee")]
        public int Size { get; set; }
        [Filterable("wool")]
        public string FurType { get; set; }
        [Filterable("signs")]
        public string Color { set; get; }
        [Filterable("ears")]
        public string Ears { set; get; }
        [Filterable("tail")]
        public string Tail { set; get; }
        [Filterable("signs")]
        public string SpicialSigns { get; set; }
        [Filterable("id_metka")]
        public string IdentificationLabel { get; set; }
        [Filterable("city_id")]
        public Location Locality { get; set; }
        [Filterable("act_id")]
        public Act ActCapture { get; set; }
        public Bitmap? Sad { get; set; }

    public AnimalCard(int idAnimalCard, string category, string gender,
        string breed, int size, string furType, string color, string ears, string tail,
        string spicialSigns, string identificationLabel, Location locality, Act actCapture, Bitmap? sad)
        {
            IdAnimalCard = idAnimalCard;
            Category = category;
            Gender = gender;
            Breed = breed;
            Size = size;
            FurType = furType;
            Color = color;
            Ears = ears;
            Tail = tail;
            SpicialSigns = spicialSigns;
            IdentificationLabel = identificationLabel;
            Locality = locality;
            ActCapture = actCapture;
            Sad = sad;
        }
    }
}
