using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagement.Domain;
using ZooManagement.Application.Interfaces;
using ZooManagement.Infrastructure;

namespace ZooManagement.Application.Services
{
    public class ZooStatisticsService
    {
        private readonly IAnimal _animalRepository;
        private readonly IEnclosure _enclosureRepository;

        public ZooStatisticsService(IAnimal animalRepository, IEnclosure enclosureRepository)
        {
            _animalRepository = animalRepository;
            _enclosureRepository = enclosureRepository;
        }

        public (int TotalAnimals, int FreeEnclosures) GetStatistics()
        {
            var totalAnimals = _animalRepository.GetAll().Count();
            var freeEnclosures = _enclosureRepository.GetAll().Count(e => e.CurrentAnimalCount < e.MaxCapacity);

            return (totalAnimals, freeEnclosures);
        }
    }
}
