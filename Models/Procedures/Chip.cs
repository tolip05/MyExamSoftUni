using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Chip : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
           else if (!animal.IsChipped)
            {
                animal.Happiness -= 5;
                animal.IsChipped = true;
                animal.ProcedureTime -= procedureTime;
            }
            else
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }
        }
    }
}
