﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagement.Domain;
using ZooManagement.Application.Interfaces;
using ZooManagement.Infrastructure;
using ZooManagement.Domain.Events;

namespace ZooManagement.Application.Services
{
    public class AnimalTransferService
    {
        private readonly IAnimal _animalRepository;
        private readonly IEnclosure _enclosureRepository;

        public AnimalTransferService(IAnimal animalRepository, IEnclosure enclosureRepository)
        {
            _animalRepository = animalRepository;
            _enclosureRepository = enclosureRepository;
        }

        public void TransferAnimal(int animalId, int fromEnclosureId, int toEnclosureId)
        {
            var animal = _animalRepository.GetById(animalId);
            var fromEnclosure = _enclosureRepository.GetById(fromEnclosureId);
            var toEnclosure = _enclosureRepository.GetById(toEnclosureId);

            fromEnclosure.RemoveAnimal(animal);
            toEnclosure.AddAnimal(animal);

            var eventInstance = new AnimalMovedEvent(animal.Id, fromEnclosure.Id, toEnclosure.Id);
        }
    }
}
