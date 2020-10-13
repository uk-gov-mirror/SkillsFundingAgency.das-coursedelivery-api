﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.CourseDelivery.Api.AcceptanceTests.Infrastructure
{
    public static class ContextKeys
    {
        public const string HttpClient = nameof(HttpClient);
        public const string HttpMethod = nameof(HttpMethod);
        public const string HttpUri = nameof(HttpUri);
        public const string HttpResponse = nameof(HttpResponse);
        public const string HttpContent = nameof(HttpContent);
    }
}