using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Core
{
   public class AnimalFactory
    {
        public IAnimal CreateAnimal(string animalType,string name,int energy,int hapiness,int procedureTime)
        {
            IAnimal animal = null;
            switch (animalType)
            {
                case "Cat":
                    animal = new Cat(name,hapiness,energy,procedureTime);
                    break;
                case "Dog":
                    animal = new Dog(name, hapiness, energy, procedureTime);
                    break;
                case "Lion":
                    animal = new Lion(name, hapiness, energy, procedureTime);
                    break;
                    case "Pig":

                    animal = new Pig(name, hapiness, energy, procedureTime);
                    break;
                default:
                    throw new ArgumentException("Invalid animal");
            }
            return animal;
        }
    }
}
