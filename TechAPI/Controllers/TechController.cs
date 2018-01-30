using System;
using System.Net.Http;
using System.Web.Http;
using TF.DBO;
using System.Net;
using System.Collections.Generic;
using TechAPI.Models;
using TechAPI.DataTransform;

namespace TechAPI.Controllers
{
    //[Authorize]
    [RoutePrefix("api/TechForum")]
    public class TechController : ApiController
    {
        GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        [Route("test")]
        [HttpGet]
        public string Get()
        {
            return "value";
        }

        // GET api/TechForum/Threads
        [Route("Threads")]
        [HttpGet]
        public HttpResponseMessage GetThreads()
        {
            try
            {
                IEnumerable<ThreadMaster> tm = _unitOfWork.GetRepoInstance<ThreadMaster>().GetAll();
                List<Thread> thread = new List<Thread>();
                thread = DataSync.ThreadSync(tm);
                if (thread != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, thread);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, " Employee Not Found");
                }

            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured while executing GetThreads");
            }
        }

        // GET api/TechForum/ask
        [Route("ask")]
        [HttpGet]
        public HttpResponseMessage AddThread(Thread threadMaster)
        {
            try
            {
                ThreadMaster thread = DataSync.ThreadSync(threadMaster);
                _unitOfWork.GetRepoInstance<ThreadMaster>().Add(thread);
                return Request.CreateResponse(HttpStatusCode.OK, thread);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured while executing AddThread");
            }

        }

        // GET api/TechForum/update
        [Route("update")]
        [HttpGet]
        public void UpdateThread(ThreadMaster threadMaster)
        {
            ThreadMaster _threadToUpdate = _unitOfWork.GetRepoInstance<ThreadMaster>().GetFirstOrDefault(i => i.ID == threadMaster.ID);
            _threadToUpdate.Name = threadMaster.Name;
            _threadToUpdate.Status = threadMaster.Status;
            _threadToUpdate.TagID = threadMaster.TagID;
            _threadToUpdate.Description = threadMaster.Description;
            _threadToUpdate.UpdatedDate = DateTime.Now;
        }
    }
}
