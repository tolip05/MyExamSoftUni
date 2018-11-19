using AnimalCentre.Models.Animals;
using System.Collections.Generic;

namespace AnimalCentre.Models.Contracts
{
    public interface IProcedure
    {
       //Implement me
       List<Animal> ProcedureHistory { get; }
        string History();

        void DoService(IAnimal animal, int procedureTime);
    }
}
