﻿namespace E_Commerce.HandelResponses
{
    public class ApiValidationErrorResponse : ApiException
    {
        public ApiValidationErrorResponse() 
            : base(400)
        {
        }
        public IEnumerable<string> Errors { get; set; }
    }
}
