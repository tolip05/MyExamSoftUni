using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
   public abstract class Procedure : IProcedure
    {
        private List<Animal> procedureHistory;

        protected Procedure()
        {
            this.ProcedureHistory = new List<Animal>();
        }

        public List<Animal> ProcedureHistory
        {
            get { return procedureHistory; }
           protected set { procedureHistory = value; }
        }

        public abstract void DoService(IAnimal animal, int procedureTime);
        

        public string History()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.ProcedureHistory)
            {
                sb.AppendLine( $"{this.GetType().Name}" + Environment.NewLine +
                $"    - {item.Name} - Happiness:{item.Happiness} - Energy: {item.Energy}");
            }
            return sb.ToString().Trim();
        }
    }
}
