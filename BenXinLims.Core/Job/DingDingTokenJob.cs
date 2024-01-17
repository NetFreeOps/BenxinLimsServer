using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BenXinLims.Core.Cache;
using Furion.Schedule;
using Furion.TimeCrontab;
using Microsoft.Extensions.Logging;
using Tea;

namespace BenXinLims.Core.Job
{
    [JobDetail("dingdingToken", Description = "获取钉钉token", GroupName = "default", Concurrent = false)]
    [Daily(TriggerId = "dingdingToken", Description = "获取钉钉token")]
    [Cron(" * /300 * * * * *")]
    public class DingDingTokenJob : IJob
    {

        private readonly IServiceProvider _serviceProvider;

        private readonly RedisCache _redisCache;

        private readonly ILogger<DingDingTokenJob> _logger;

        public DingDingTokenJob(IServiceProvider serviceProvider, RedisCache redisCache, ILogger<DingDingTokenJob> logger)
        {
            _serviceProvider = serviceProvider;
            _redisCache = redisCache;
            _logger = logger;
        }

        public Task ExecuteAsync(JobExecutingContext context, CancellationToken stoppingToken)
        {
            AlibabaCloud.OpenApiClient.Models.Config config = new AlibabaCloud.OpenApiClient.Models.Config();
            config.Protocol = "https";
            config.RegionId = "central";
            AlibabaCloud.SDK.Dingtalkoauth2_1_0.Client client = new AlibabaCloud.SDK.Dingtalkoauth2_1_0.Client(config);

            AlibabaCloud.SDK.Dingtalkoauth2_1_0.Models.GetAccessTokenRequest getAccessTokenRequest = new AlibabaCloud.SDK.Dingtalkoauth2_1_0.Models.GetAccessTokenRequest
            {
                AppKey = "dingjmnznyuoseexefo2",
                AppSecret = "MjeGZGk8N6H9Brv3pQ9NPZC-PmDS02lXG7AcNLIPkWsoBhIkT6ttYzx31vdWWTk1",
            };
            try
            {
                var token = client.GetAccessToken(getAccessTokenRequest);

                _redisCache.Set("dingdingtoken", token.Body);

                Console.WriteLine(token.Body);
            }
            catch (TeaException err)
            {
                if (!AlibabaCloud.TeaUtil.Common.Empty(err.Code) && !AlibabaCloud.TeaUtil.Common.Empty(err.Message))
                {
                    // err 中含有 code 和 message 属性，可帮助开发定位问题
                    _logger.LogError(err.Message);
                }
            }
            catch (Exception _err)
            {
                TeaException err = new TeaException(new Dictionary<string, object>
                {
                    { "message", _err.Message }
                });
                if (!AlibabaCloud.TeaUtil.Common.Empty(err.Code) && !AlibabaCloud.TeaUtil.Common.Empty(err.Message))
                {
                    // err 中含有 code 和 message 属性，可帮助开发定位问题
                    _logger.LogError(err.Message);

                }
            }

            Console.WriteLine("获取钉钉token");
            // _logger.LogInformation(context.ConvertToJSON());
            // _logger.LogDebug("获取钉钉token");
            return Task.CompletedTask;
        }
    }
}
