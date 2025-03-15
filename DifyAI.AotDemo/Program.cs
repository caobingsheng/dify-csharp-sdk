using DifyAI.Interfaces;
using DifyAI.ObjectModels;
using Microsoft.Extensions.DependencyInjection;

namespace DifyAI.AotDemo
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services
                .AddDifyAIService(x =>
                {
                    x.BaseDomain = "http://192.168.1.200:19080/v1"; // https://www.gnhealth.top:20012/v1
                    x.DefaultApiKey = "app-SERBkntJ8fgFSxikzn4p4aF5";// app-rXR8RhkpLu6h8MpVStxoiMa3
                });

            var app = services.BuildServiceProvider();
            var _difyAIService = app.GetRequiredService<IDifyAIService>();

            var req = new ChatCompletionRequest
            {
                //Query = "我是一名医生，我在给患者检查，请你根据体检号：2501150001 给我生成一个模拟的体检数据并提取关键信息以方便我诊断",
                Query = "当前时间是什么",
                User = "cbs",
                //Inputs = new Dictionary<string, string>
                //{
                //    ["arg1"] = "1",
                //    ["arg2"] = "2",
                //},
            };
            var e = string.Empty;
            await foreach (var rsp in _difyAIService.ChatMessages.ChatStreamAsync(req))
            {
                //if (e != rsp.Event)
                {
                    //Console.WriteLine(rsp.Event);
                    e = rsp.Event;
                }
                if (rsp is ChunkCompletionAgentMessageResponse msg)
                {
                    foreach (var item in msg.Answer)
                    {
                        Console.Write(item);
                        await Task.Delay(10);
                    }
                }
                if (rsp is ChunkCompletionAgentThoughtResponse thinking)
                {
                    Console.WriteLine("<" + thinking.Thought+">");
                }
            }
        }
    }
}
