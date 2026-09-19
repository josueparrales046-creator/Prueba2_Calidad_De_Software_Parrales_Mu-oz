using System.Collections.Generic;
using Newtonsoft.Json;

namespace EjemploMVC.Models
{

    public class DogBreedListResponse
    {
        public List<DogBreedResource> Data { get; set; }
        public DogApiLinks Links { get; set; }
    }

    public class DogBreedDetailResponse
    {
        public DogBreedResource Data { get; set; }
    }

    public class DogBreedResource
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public DogBreedAttributes Attributes { get; set; }
    }

    public class DogBreedAttributes
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public LifeRange Life { get; set; }

        [JsonProperty("male_weight")]
        public WeightRange MaleWeight { get; set; }

        [JsonProperty("female_weight")]
        public WeightRange FemaleWeight { get; set; }

        public bool Hypoallergenic { get; set; }

        [JsonProperty("male_height")]
        public HeightRange MaleHeight { get; set; }

        [JsonProperty("female_height")]
        public HeightRange FemaleHeight { get; set; }

        public Origin Origin { get; set; }
        public Coat Coat { get; set; }
        public Traits Traits { get; set; }
        public List<DogImage> Images { get; set; }
    }

    public class LifeRange
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }

    public class WeightRange
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }

    public class HeightRange
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }

    public class Origin
    {
        public string Country { get; set; }
    }

    public class Coat
    {
        public string Type { get; set; }
    }

    public class Traits
    {
        public int Barking { get; set; }
        public int Trainability { get; set; }

        [JsonProperty("good_with_children")]
        public int GoodWithChildren { get; set; }
    }

    public class DogImage
    {
        public string Thumb { get; set; }
        public string Medium { get; set; }
    }

    public class DogApiLinks
    {
        public string Self { get; set; }
        public string Current { get; set; }
        public string Next { get; set; }
        public string Last { get; set; }
    }

    public class DogBreedListViewModel
    {
        public List<DogBreedResource> Razas { get; set; }
        public int PaginaActual { get; set; }
        public bool HasPrevious => PaginaActual > 1;
        public bool HasNext { get; set; }
    }
}
