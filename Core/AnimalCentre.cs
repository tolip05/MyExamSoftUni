using AnimalCentre.Models;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
   public class AnimalCentre
    {
        
        private Hotel hotel;
        private AnimalFactory animalFactory;
        private IProcedure procedureChip;
        private IProcedure procedureVaccinate;
        private IProcedure procedureFitness;
        private IProcedure procedurePlay;
        private IProcedure procedureDentalCare;
        private IProcedure procedureNailTrim;
        private List<IAnimal> adoptAnimal;

        public List<IAnimal> AdoptAnimal { get => adoptAnimal; set => adoptAnimal = value; }

        public AnimalCentre()
        {
            
            this.hotel = new Hotel();
            this.animalFactory = new AnimalFactory();
            this.procedureChip = new Chip();
            this.procedureVaccinate = new Vaccinate();
            this.procedureFitness = new Fitness();
            this.procedurePlay = new Play();
            this.procedureDentalCare = new DentalCare();
            this.procedureNailTrim = new NailTrim();
            this.adoptAnimal = new List<IAnimal>();


        }
        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal animal = this.animalFactory.CreateAnimal(type, name, happiness, energy, procedureTime);
            this.hotel.Accommodate(animal);
            string result = $"Animal {animal.Name} registered successfully";
            Console.WriteLine(result.ToString());
            return result;
        }
        public string Chip(string name, int procedureTime)
        {
            IAnimal animal = this.hotel.Animals[name];
            if (animal == null)
            {
                throw new ArgumentException($"Animal {name} does not exist");

            }
            this.procedureChip.DoService(animal, procedureTime);

            string result = $"{animal.Name} had chip procedure";
            Console.WriteLine(result.ToString());
            return result;
        }

        public string Vaccinate(string name, int procedureTime)
        {
            IAnimal animal = this.hotel.Animals[name];
            if (animal == null)
            {
                throw new ArgumentException($"Animal {name} does not exist");

            }
            this.procedureVaccinate.DoService(animal,procedureTime);
            string result = $"{animal.Name} had vaccination procedure";
            Console.WriteLine(result.ToString());
            return result;
        }

        public string Fitness(string name, int procedureTime)
        {
            IAnimal animal = this.hotel.Animals[name];
            if (animal == null)
            {
                throw new ArgumentException($"Animal {name} does not exist");

            }
            this.procedureFitness.DoService(animal,procedureTime);
            string result = $"{animal.Name} had fitness procedure";
            Console.WriteLine(result.ToString());
            return result;

        }

        public string Play(string name, int procedureTime)
        {
            IAnimal animal = this.hotel.Animals[name];
            if (animal == null)
            {
                throw new ArgumentException($"Animal {name} does not exist");

            }
            this.procedurePlay.DoService(animal,procedureTime);

            string result = $"{animal.Name} was playing for {procedureTime} hours";
            Console.WriteLine(result.ToString());
            return result;
        }

        public string DentalCare(string name, int procedureTime)
        {
            IAnimal animal = this.hotel.Animals[name];
            if (animal == null)
            {
                throw new ArgumentException($"Animal {name} does not exist");

            }
            this.procedureDentalCare.DoService(animal,procedureTime);
            string result = $"{animal.Name} had dental care procedure";
            Console.WriteLine(result.ToString());
            return result;
        }

        public string NailTrim(string name, int procedureTime)
        {
            IAnimal animal = this.hotel.Animals[name];
            if (animal == null)
            {
                throw new ArgumentException($"Animal {name} does not exist");

            }
            this.procedureNailTrim.DoService(animal,procedureTime);

            string result = $"{animal.Name} had nail trim procedure";
            Console.WriteLine(result.ToString());
            return result;
        }

        public string Adopt(string animalName, string owner)
        {
            IAnimal animal = this.hotel.Animals[animalName];
            if (animal == null)
            {
                throw new ArgumentException($"Animal {animalName} does not exist");

            }
            this.hotel.Adopt(animal.Name,owner);
            this.adoptAnimal.Add(animal);
            string result = "";
            if (animal.IsChipped)
            {
                result = $"{owner} adopted animal with chip";
            }
            else
            {
                result = $"{owner} adopted animal without chip";
            }
            Console.WriteLine(result.ToString());
            return result;
        }

        public string History(string type)
        {
            List<IAnimal> list = new List<IAnimal>();
            string check = "";
            string typeProced = "";
            if (type == "Adopt")
            {
                check = "Adopt";
                typeProced = "Adopt";
                foreach (var animal in this.hotel.Animals)
                {
                    if (animal.Value.IsAdopt)
                    {
                        list.Add(animal.Value);
                    }
                }
            }
            else if (type == "Chip")
            {
                check = "Chip";
                typeProced = "Chip";
                foreach (var animal in this.hotel.Animals)
                {
                    if (animal.Value.IsChipped)
                    {
                        list.Add(animal.Value);
                    }
                }
            }
            else if (type == "Vaccinate")
            {
                check = "Vaccinate";
                typeProced = "Vaccinate";
                foreach (var animal in this.hotel.Animals)
                {
                    if (animal.Value.IsVaccinated)
                    {
                        list.Add(animal.Value);
                    }
                }
            }
            StringBuilder sb = new StringBuilder();
            

            foreach (var animal in list)
            {

                sb.AppendLine($"    Animal type: {animal.GetType().Name} - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
               
            }
            string result = typeProced + Environment.NewLine +
                sb.ToString();
           
            Console.WriteLine(result.ToString());
            return result;
        }
    }
}
