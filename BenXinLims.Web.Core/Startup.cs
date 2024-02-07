using BenXinLims.Core.EventBus;
using BenXinLims.Core.Job;
using Furion;
using Furion.Schedule;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BenXinLims.Web.Core
{
    public class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConsoleFormatter();
            services.AddJwt<JwtHandler>();

            //注册后台服务
            services.AddSchedule(options =>
            {

                options.AddJob<DingDingTokenJob>("钉钉Token获取作业", Triggers.Hourly());
               

            });

            // 事件总线服务
            services.AddEventBus(builder => { builder.AddSubscriber<LogEventSubscriber>(); });

            services.AddCorsAccessor();

            services.AddControllers()
                    .AddInjectWithUnifyResult();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCorsAccessor();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseScheduleUI();

            app.UseInject(string.Empty);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
