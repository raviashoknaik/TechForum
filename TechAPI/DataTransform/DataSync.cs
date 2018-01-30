using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechAPI.Models;
using TF.DBO;

namespace TechAPI.DataTransform
{
    public static class DataSync
    {
        public static List<Thread> ThreadSync(IEnumerable<ThreadMaster> tm)
        {
            List<Thread> thread = new List<Thread>();
            foreach (var item in tm)
            {
                thread.Add(new Models.Thread
                {
                    Id = item.ID,
                    Name = item.Name,
                    Description = item.Description,
                    StatusID = item.StatusID,
                    TagID = item.TagID,
                    CreatedDate = item.CreatedDate,
                    UpdateDate = item.UpdatedDate
                });
            }
            return thread;
        }

        public static ThreadMaster ThreadSync(Thread item)
        {
            ThreadMaster thread = new ThreadMaster
            {
                ID = item.Id,
                Name = item.Name,
                Description = item.Description,
                StatusID = item.StatusID ?? 0,
                TagID = item.TagID,
                CreatedDate = item.CreatedDate,
                UpdatedDate = item.UpdateDate
            };

            return thread;
        }
    }
}