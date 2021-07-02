using Application.DataAccess.DataContext;
using Application.DataAccess.Repositories.CommonModule;
using Application.DataAccess.Repositories.Interfaces.CommonModule;
using Application.DataAccess.Repositories.Interfaces.PreselectionModule;
using Application.DataAccess.Repositories.Interfaces.VendorModule;
using Application.DataAccess.Repositories.PreselectionModule;
using Application.DataAccess.Repositories.VendorModule;
using Application.Service.Services.CommonModule;
using Application.Service.Services.Interfaces.CommonModule;
using Application.Service.Services.Interfaces.PreselectionModule;
using Application.Service.Services.Interfaces.VendorModule;
using Application.Service.Services.PreselectionModule;
using Application.Service.Services.VendorModule;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.WebApp
{
    public static class ServiceInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<AppConfiguration>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            #region::Common Module
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IFunctionRepository, FunctionRepository>();
            services.AddScoped<IFunctionService, FunctionService>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IJobDescriptionRepository, JobDescriptionRepository>();
            services.AddScoped<IJobDescriptionService, JobDescriptionService>();
            services.AddScoped<IJobTypeRepository, JobTypeRepository>();
            services.AddScoped<IJobTypeService, JobTypeService>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IPrefixRepository, PrefixRepository>();
            services.AddScoped<IPrefixService, PrefixService>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IDomainRepository, DomainRepository>();
            services.AddScoped<IDomainService, DomainService>();
            services.AddScoped<IVerticalRepository, VerticalRepository>();
            services.AddScoped<IVerticalService, VerticalService>();
            services.AddScoped<IQualificationRepository, QualificationRepository>();
            services.AddScoped<IQualificationService, QualificationService>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IStreamRepository, StreamRepository>();
            services.AddScoped<IStreamService, StreamService>();
            services.AddScoped<ISalaryRepository, SalaryRepository>();
            services.AddScoped<ISalaryService, SalaryService>();
            services.AddScoped<ICommonRepository, CommonRepository>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<IIndustryRepository, IndustryRepository>();
            services.AddScoped<IIndustryService, IndustryService>();

            #endregion
            #region::Preselection Module
            services.AddScoped<IRequisitionRepository, RequisitionRepository>();
            services.AddScoped<IRequisitionService, RequisitionService>();
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<ICandidateService, CandidateService>();
            #endregion
            #region::Vendor Module
            services.AddScoped<IVendorRepository, VendorRepository>();
            services.AddScoped<IVendorService, VendorService>();
            services.AddScoped<IVendorJobRepository, VendorJobRepository>();
            services.AddScoped<IVendorJobService, VendorJobService>();
            #endregion
        }
    }
}
