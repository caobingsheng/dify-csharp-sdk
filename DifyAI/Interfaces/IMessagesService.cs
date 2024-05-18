﻿using DifyAI.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DifyAI.Interfaces
{
    public interface IMessagesService
    {
        /// <summary>
        /// 消息反馈（点赞）
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task FeedbacksAsync(MessageFeedbacksRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取下一轮建议问题列表
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<MessageSuggestedResponse> SuggestedAsync(MessageSuggestedRequest request, CancellationToken cancellationToken = default);
    }
}
