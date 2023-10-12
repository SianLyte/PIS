using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01.Models
{
    public class AnimalCard
    {
        public int IdAnimalCard { set; get; }
        public string Category { get; set; }
        public string Gender { get; set; }
        public string Breed { get; set; }
        public int Size { get; set; }
        public string FurType { get; set; }
        public string Color { set; get; }
        public string Ears { set; get; }
        public string Tail { set; get; }
        public string SpicialSigns { get; set; }
        public string IdentificationLabel { get; set; }
        public Location Locality { get; set; }
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
