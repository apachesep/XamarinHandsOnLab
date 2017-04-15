﻿using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XamarinHandsOnLabService.DataObjects;
using XamarinHandsOnLabService.Models;

namespace XamarinHandsOnLabService.Controllers
{
    [MobileAppController]
    public class UserTasksController : ApiController
    {
        APIResult fooAPIResult = new APIResult();
        private XamarinHandsOnLabContext db = new XamarinHandsOnLabContext();

        [HttpGet]
        [Route("Filter")]
        // GET: api/UserTasks
        public APIResult Get(string account, DateTime startDate, DateTime lastDate)
        {
            var fooTasks = db.UserTasks.Where(x => x.Account == account 
                           && DbFunctions.TruncateTime(x.TaskDateTime) >= startDate
                           && DbFunctions.TruncateTime(x.TaskDateTime) <= lastDate).ToList();

            fooAPIResult.Success = true;
            fooAPIResult.Message = "";
            fooAPIResult.Payload = fooTasks;
            return fooAPIResult;
        }

        // GET: api/UserTasks/5
        [HttpGet]
        [Route("FilterById")]
        public APIResult Get(long id)
        {
            var fooTask = db.UserTasks.FirstOrDefault(x => x.Id == id);
            if (fooTask == null)
            {
                fooAPIResult.Success = false;
                fooAPIResult.Message = "沒有發現指定的工作紀錄";
                fooAPIResult.Payload = null;
            }
            else
            {
                fooAPIResult.Success = true;
                fooAPIResult.Message = "";
                fooAPIResult.Payload = fooTask;
            }
            return fooAPIResult;
        }

        // POST: api/UserTasks
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserTasks/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserTasks/5
        public void Delete(int id)
        {
        }
    }
}