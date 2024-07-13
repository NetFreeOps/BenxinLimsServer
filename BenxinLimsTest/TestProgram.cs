using Furion.Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

[assembly: TestFramework("BenxinLimsTest.TestProgram", "BenxinLimsTest")]

namespace BenxinLimsTest
{

    public class TestProgram:TestStartup
    {
        public TestProgram(IMessageSink messageSink) : base(messageSink)
        {
            // 初始化 Furion
            Serve.RunNative();
        }

    }
}
