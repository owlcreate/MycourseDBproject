using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_matchacode.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace nscccoursemap_matchacode
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddDbContext<ApplicationDbContext>(options =>
            //     options.UseSqlite(
            //         Configuration.GetConnectionString("DefaultConnection")));

            // services.AddDbContext<ApplicationDbContext>(options =>
            //     options.UseSqlServer(
            //         Configuration.GetConnectionString("MSSQLConnectionDev")));
                    
            // // services.AddDbContext<NsccCourseMapDbContext>(options =>
            // //     options.UseSqlite(
            // //         Configuration.GetConnectionString("DefaultConnection")));

            
            // services.AddDbContext<NsccCourseMapDbContext>(options =>
            //     options.UseSqlServer(
            //         Configuration.GetConnectionString("MSSQLConnectionDev")));

      if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                            options.UseSqlServer(Configuration.GetConnectionString("MSSQLConnectionProd")));
            services.AddDbContext<NsccCourseMapDbContext>(options =>
                            options.UseSqlServer(Configuration.GetConnectionString("MSSQLConnectionProd")));
            
             // Automatically perform database migration
            services.BuildServiceProvider().GetService<ApplicationDbContext>().Database.Migrate();
            services.BuildServiceProvider().GetService<NsccCourseMapDbContext>().Database.Migrate();
        }
                
        else{
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MSSQLConnectionDev")));
            services.AddDbContext<NsccCourseMapDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MSSQLConnectionDev")));
        }
           
                    
            services.AddDefaultIdentity<IdentityUser>(options => 
                options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddRazorPages();

            services.AddRazorPages().AddRazorPagesOptions(options =>
            {
                options.Conventions.AuthorizeFolder("/AcademicYears");
                options.Conventions.AuthorizeFolder("/CourseOfferings");
                options.Conventions.AuthorizeFolder("/CoursePrerequisites");
                options.Conventions.AuthorizeFolder("/Courses");
                options.Conventions.AuthorizeFolder("/DiplomaPrograms");
                options.Conventions.AuthorizeFolder("/DiplomaProgramYears");
                options.Conventions.AuthorizeFolder("/DiplomaProgramYearSections");
                options.Conventions.AuthorizeFolder("/Instructors");
                options.Conventions.AuthorizeFolder("/Semesters");
                options.Conventions.AuthorizeFolder("/AdvisingAssignments");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
