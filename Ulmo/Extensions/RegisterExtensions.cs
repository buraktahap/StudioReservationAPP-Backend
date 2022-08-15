using Microsoft.EntityFrameworkCore;
using StudioReservationAPP.Core.EFContext;
using StudioReservationAPP.Core.Factory;
using StudioReservationAPP.Core.Repositories.Base;
using StudioReservationAPP.Core.UoW;
using StudioReservationAPP.Services;

namespace StudioReservationAPP.Extensions
{
    internal static class RegisterExtensions
    {
        internal static void AddDbContexts(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            var contextConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<DatabaseContext>(x => x.UseSqlServer(contextConnectionString, o =>
            {
                o.EnableRetryOnFailure(3);
            })
            .EnableSensitiveDataLogging(environment.IsDevelopment())
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        }

        internal static void AddInjections(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMemberRepository,MemberRepository>();

            //services.AddScoped<IDatabaseContext, DatabaseContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IMemberService), typeof(MemberService));
            services.AddTransient(typeof(IBranchService), typeof(BranchService));
            services.AddTransient(typeof(IClassService), typeof(ClassService));
            services.AddTransient(typeof(ILessonService), typeof(LessonService));
            services.AddTransient(typeof(ITrainerService), typeof(TrainerService));
            services.AddTransient(typeof(ITrainerWorkPlaceService), typeof(TrainerWorkPlaceService));
            services.AddTransient(typeof(IMemberLessonService), typeof(MemberLessonService));
            services.AddTransient<IContextFactory, ContextFactory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
