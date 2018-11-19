using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
   public class Engine
    {
        private Dictionary<string, List<IAnimal>> dic;
        private AnimalCentre centre;

        public Engine()
        {
            this.centre = new AnimalCentre();
            this.dic = new Dictionary<string, List<IAnimal>>();
        }
        public void Run()
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] type = input
                .Split();

                try
                {
                    switch (type[0])
                    {
                        case "RegisterAnimal":
                            this.centre.RegisterAnimal(type[1], type[2], int.Parse(type[3]), int.Parse(type[4]), int.Parse(type[5]));

                            break;
                        case "Chip":
                            this.centre.Chip(type[1], int.Parse(type[2]));
                            break;
                        case "Vaccinate":
                            this.centre.Vaccinate(type[1], int.Parse(type[2]));
                            break;
                        case "Fitness":
                            this.centre.Fitness(type[1], int.Parse(type[2]));
                            break;
                        case "Play":
                            this.centre.Play(type[1], int.Parse(type[2]));
                            break;
                        case "DentalCare":
                            this.centre.DentalCare(type[1], int.Parse(type[2]));
                            break;
                        case "NailTrim":
                            this.centre.NailTrim(type[1], int.Parse(type[2]));
                            break;
                        case "Adopt":
                            this.centre.Adopt(type[1], type[2]);

                            break;
                        case "History":
                            this.centre.History(type[1]);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine($"{e.GetType().Name}: {e.Message}");
                }
                input = Console.ReadLine();
            }
            foreach (var animal in this.centre.AdoptAnimal.OrderBy(a => a.Owner))
            {
                if (!this.dic.ContainsKey(animal.Owner))
                {
                    this.dic.Add(animal.Owner, new List<IAnimal>());
                }
                this.dic[animal.Owner].Add(animal);
                
            }
            foreach (var item in this.dic)
            {
                string name = item.Key;
                Console.WriteLine($"--Owner: {name}");

                List<string> names = new List<string>();
                foreach (var animal in item.Value)
                {
                    names.Add(animal.Name);
                }
                Console.WriteLine($"    - Adopted animals: {string.Join(" ", names)}");
            }
        }
    }
}
