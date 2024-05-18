﻿using DifyAI.Interfaces;
using DifyAI.ObjectModels;
using DifySdk.Dtos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyAI.Test
{
    public class DifyAIServiceTest
    {
        private readonly IDifyAIService _difyAIService;

        public DifyAIServiceTest()
        {
            var services = new ServiceCollection();

            services
                .AddDifyAIService(x =>
                {
                    x.BaseDomain = "http://10.13.60.91/v1";
                    x.ApiKey = "app-3ppSoe6ynEvBgTpugCyenxr6";
                });

            var app = services.BuildServiceProvider();
            _difyAIService = app.GetRequiredService<IDifyAIService>();
        }

        [Fact]
        public async Task Completion()
        {
            var req = new CompletionRequest
            {
                Query = "你好",
                //User = "user123",
            };
            var rsp = await _difyAIService.ChatMessages.CompletionAsync(req);
            Assert.NotNull(rsp.MessageId);
        }

        [Fact]
        public async Task CompletionStream()
        {
            var req = new CompletionRequest
            {
                Query = "你好",
                User = "user123",
            };

            await foreach (var rsp in _difyAIService.ChatMessages.CompletionStreamAsync(req))
            {
                Assert.NotNull(rsp.Event);
            }
        }

        [Fact]
        public async Task Upload()
        {
            var req = new UploadRequest
            {
                File = @"C:\Users\obsgo\Pictures\36703881.png",
                User = "user123",
            };

            var rsp = await _difyAIService.Files.UploadAsync(req);
            Assert.NotEmpty(rsp.Name);
        }
    }
}
