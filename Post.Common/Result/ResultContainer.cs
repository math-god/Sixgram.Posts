﻿using Post.Common.Response;

namespace Post.Common.Result
{
    public class ResultContainer<T>
    {
        public T Data { get; set; }
        public ErrorType? ResponseCode { get; set; }
    }
}