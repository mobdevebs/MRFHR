using Application.DataAccess.Repositories.Interfaces.CommonModule;
using Application.Entity.Entities.CommonModule;
using Application.Service.Services.Interfaces.CommonModule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Services.CommonModule
{
   public class StreamService : IStreamService
    {
        private readonly IStreamRepository streamRepository;

        public StreamService(IStreamRepository streamRepository)
        {
            this.streamRepository = streamRepository;
        }

        public async Task<List<Stream>> GetAllStream(SearchStream search)
        {
            return await this.streamRepository.GetAllStream(search);
        }

        public async Task<List<QualificationCourseStream>> GetAllQualificationCourseStream(SearchQualificationCourseStream search)
        {
            return await this.streamRepository.GetAllQualificationCourseStream(search);
        }
    }
}