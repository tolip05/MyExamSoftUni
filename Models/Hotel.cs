using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models
{
   public class Hotel : IHotel
    {
        private const int HotelCapacity = 10;

        private int capacity;
        private Dictionary<string, IAnimal> animals;
        public Hotel()
        {
            this.Capacity = HotelCapacity;
            this.Animals = new Dictionary<string, IAnimal>();
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                capacity = value;
            }
        }
        

        public Dictionary<string, IAnimal> Animals
        
       {
            get => animals;
           set
           {
               animals = value;
           }
        }
        public void Accommodate(IAnimal animal)
        {
            if (this.Animals.Count >= this.Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }
            else if (this.Animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }
            this.Animals.Add(animal.Name, animal);
        }
        public void Adopt(string animalName, string owner)
        {
            if (!this.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
            else
            {
                IAnimal animal = this.Animals[animalName];
                animal.IsAdopt = true;
                animal.Owner = owner;
                this.Animals.Remove(animal.Name);
            }
        }

    }
}
