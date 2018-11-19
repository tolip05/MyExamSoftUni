namespace AnimalCentre.Models.Contracts
{
    using System.Collections.Generic;

    public interface IHotel
    {
       //Implement me
       int Capacity { get; }
        Dictionary<string,IAnimal> Animals { get; }
    }
}
