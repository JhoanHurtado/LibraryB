using System;

namespace Library.Utility.Utility
{
    public class BusinessResult<T>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T Result { get; set; }

        public BusinessResult() { }

        public static BusinessResult<T> Sucess(T result, string message)
        {
            return new BusinessResult<T>()
            {
                Message = message,
                IsSuccess = true,
                Result = result
            };
        }

        public static BusinessResult<T> Issue(T result, string mesage)
        {
            return new BusinessResult<T>()
            {
                Message = mesage,
                IsSuccess = false,
                Result = result
            };
        }

    }
}
