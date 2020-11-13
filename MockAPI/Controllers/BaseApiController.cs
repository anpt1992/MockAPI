using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MockAPI.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
         public BaseApiController()
        {                       
        }

        protected ResponseWrapper error(HttpStatusCode code, string msg)
        {
            Response.StatusCode = (int)code;
            return new ResponseWrapper(code, msg);
        }

        protected ResponseWrapper error(string msg)
        {
            return error(HttpStatusCode.InternalServerError, msg);
        }

        protected ResponseWrapper ok_get(object data, Meta meta = null)
        {
            Response.StatusCode = (int)HttpStatusCode.OK;
            return new ResponseWrapper(HttpStatusCode.OK, data, meta);
        }

        protected ResponseWrapper ok_create(object data)
        {
            Response.StatusCode = (int)HttpStatusCode.Created;
            return new ResponseWrapper(HttpStatusCode.Created, data,null,"Inserted");
        }

        protected ResponseWrapper ok_update()
        {
            Response.StatusCode = (int)HttpStatusCode.OK;
            return new ResponseWrapper(HttpStatusCode.OK, "Updated");
        }

        protected ResponseWrapper ok_delete()
        {
            Response.StatusCode = (int)HttpStatusCode.OK;
            return new ResponseWrapper(HttpStatusCode.OK, "Deleted");
        }

        protected ResponseWrapper notFound()
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return new ResponseWrapper(HttpStatusCode.NotFound, "Not found");
        }

        protected ResponseWrapper notFound(string msg)
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return new ResponseWrapper(HttpStatusCode.NotFound, msg);
        }

        protected ResponseWrapper badRequest(string msg)
        {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return new ResponseWrapper(HttpStatusCode.BadRequest, msg);
        }
    }
}
