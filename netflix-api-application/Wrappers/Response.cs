using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netflix_api_application.Wrappers;

public class Response<T>
{

    public T Data { get; set; }
    public string Message { get; set; }
    public bool Success { get; set; }

    public List<string> Errors { get; set; }

    public Response()
    {

    }

    public Response(T data, string message = null)
    {
        Success = true;
        Message = message;
        Data = data;
    }

    public Response(string message = null)
    {
        Success = false;
        Message = message;

    }

}
