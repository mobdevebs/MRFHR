using Application.DataAccess.Repositories.Interfaces.CommonModule;
using Application.Entity.Entities.CommonModule;
using Application.Service.Services.Interfaces.CommonModule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Services.CommonModule
{
    public  class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<List<Course>> GetAllCourse(SearchCourse search)
        {
            return await this.courseRepository.GetAllCourse(search);
        }

        public async Task<List<QualificationCourse>> GetAllQualificationCourse(SearchQualificationCourse search)
        {
            return await this.courseRepository.GetAllQualificationCourse(search);
        }
    }
}
