﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using RESTEventVisitor.Models;

namespace RESTEventVisitor.Controllers
{
    public class CheckUserController : ApiController
    {
        private ProfileModel db = new ProfileModel();

        //[Route("Profile")]
        // [ResponseType(typeof(Profiles))]
        [HttpPost]
            var log = db.Profile.Where(x => x.Profile_User_Id.Equals(inlogg.User_Id)).FirstOrDefault();

            if (log == null)

            // Convert Employee object to JSON format (Serialization) 
            string jsonString = JsonConvert.SerializeObject(User);
        }
    }
}