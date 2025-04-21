using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagement.Application.Interfaces;
using ZooManagement.Infrastructure;
using ZooManagement.Domain.Classes;

namespace ZooManagement.Application.Services
{
    public class FeedingOrganizationService
    {
        private readonly IFeedingSchedule _feedingScheduleRepository;

        public FeedingOrganizationService(IFeedingSchedule feedingScheduleRepository)
        {
            _feedingScheduleRepository = feedingScheduleRepository;
        }

        public void AddFeedingSchedule(FeedingSchedule schedule) => _feedingScheduleRepository.Add(schedule);

        public IEnumerable<FeedingSchedule> GetAllSchedules() => _feedingScheduleRepository.GetAll();
    }
}
