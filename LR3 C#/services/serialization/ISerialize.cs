using laba3.models;
using System.Collections.Generic;

namespace laba3.services.serialization
{
    public interface ISerialization
    {
        string Serialize(List<Animal> listOfPets);
        List<Animal> Deserialize(string str);
    }
}