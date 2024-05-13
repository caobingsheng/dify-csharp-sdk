﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public class SuggestedResponse
    {
        [JsonPropertyName("data")]
        public IReadOnlyList<string> Data { get; set; }
    }
}
