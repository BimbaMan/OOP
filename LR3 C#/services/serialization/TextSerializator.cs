using System;
using laba3.models;
using System.Collections.Generic;
using System.Reflection;

namespace laba3.services.serialization
{
    public class TextSerializator : ISerialization
    {
        public string Serialize(List<Animal> listOfAnimals)
        {
            string str = string.Empty;
            foreach (var item in listOfAnimals)
            {
                str += "{";
                Type type = item.GetType();
                str += $"'Type': {type},";

                foreach (var field in type.GetFields())
                {
                    if (field.GetType() == typeof(int))
                        str += $" '{field.Name}': {field.GetValue(item)},";
                    else
                        str += $" '{field.Name}': \"{field.GetValue(item)}\",";
                }
                foreach (var property in type.GetProperties())
                {
                    if (property.GetType() == typeof(string))
                        str += $" '{property.Name}': \"{property.GetValue(item)}\",";
                    else
                        str += $" '{property.Name}': {property.GetValue(item)},";
                }
                str = str.Remove(str.Length - 1);
                str += "}\r\n";
            }

            return str;
        }

        public List<Animal> Deserialize(string str)
        {
            TextDictionary textDictionary;
            List<Animal> listOfPets = new List<Animal>();
            string[] strArray = str.Split('\n');
            foreach (var item in strArray)
            {
                if (item == "")
                    break;
                textDictionary = new TextDictionary(item);
                textDictionary.MakeDictionary();
                string tempString;
                textDictionary.dictionary.TryGetValue("Type", out tempString);
                Type type = Type.GetType(tempString);
                Animal pet = (Animal)Activator.CreateInstance(type);
                foreach (var field in type.GetFields())
                {
                    if (field.FieldType == typeof(string))
                    {
                        string fieldValue = textDictionary.dictionary[field.Name];
                        field.SetValue(pet, fieldValue);
                    }
                    else
                    {
                        int fieldValue = Convert.ToInt16(textDictionary.dictionary[field.Name]);
                        field.SetValue(pet, fieldValue);
                    }
                }

                foreach (var property in type.GetProperties())
                {
                    if (property.PropertyType == typeof(string))
                    {
                        string propertyValue = textDictionary.dictionary[property.Name];
                        property.SetValue(pet, propertyValue);
                    }
                    else
                    {
                        int propertyValue = Convert.ToInt16(textDictionary.dictionary[property.Name]);
                        property.SetValue(pet, propertyValue);
                    }
                }
                listOfPets.Add(pet);
            }

            return listOfPets;
        }
    }
}