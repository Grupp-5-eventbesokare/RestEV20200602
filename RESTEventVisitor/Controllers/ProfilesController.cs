using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;
using RESTEventVisitor.Models;


namespace RESTEventVisitor.Controllers
{
    public class ProfilesController : ApiController
    {
        private ProfileModel db = new ProfileModel();

        // GET: api/Profiles
        public IQueryable<Profile> GetProfile()
        {
            return db.Profile;
        }
        /*
        [Route("Profile")]
        // [ResponseType(typeof(Profiles))]
        [HttpPost]        public string MyProfile(LoginClass inlogg)        {
            var log = db.Profile.Where(x => x.Profile_User_Id.Equals(inlogg.User_Id)).FirstOrDefault();

            if (log == null)            {                return null;            }            LoginClass User = new LoginClass()            {                Id = log.Profile_Id,                User_Id = log.Profile_User_Id            };

            // Convert Employee object to JSON format (Serialization) 
            string jsonString = JsonConvert.SerializeObject(User);            return (jsonString);
        } */


        // GET: api/Profiles/5
        [ResponseType(typeof(Profile))]
        public IHttpActionResult GetProfile(int id)
        {
            Profile profile = db.Profile.Find(id);
            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        // PUT: api/Profiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProfile(int id, Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profile.Profile_Id)
            {
                return BadRequest();
            }

            db.Entry(profile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Profiles
        [ResponseType(typeof(Profile))]
        public IHttpActionResult PostProfile(Profile NewProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            // Klistrat in

            //    using (var ctx = new ProfileModel())
            //    {

            //        ctx.Profile.Add(new Profile()
            //        {
            //            Profile_Firstname = NewProfile.Profile_Firstname,
            //            Profile_Lastname = NewProfile.Profile_Lastname,
            //            Profile_Email = NewProfile.Profile_Email,
            //            Profile_User_Id = NewProfile.Profile_User_Id,
            //            Profile_Role = NewProfile.Profile_Role,
            //            Profile_Birthday = NewProfile.Profile_Birthday,
            //            Profile_PhoneNr = NewProfile.Profile_PhoneNr,

            //        });
            //        ctx.Profile.Add(NewProfile);
            //        ctx.SaveChanges();
            //    }

            //    return Ok();
            //}

            db.Profile.Add(NewProfile);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = NewProfile.Profile_Id }, NewProfile);
        }

        // DELETE: api/Profiles/5
        [ResponseType(typeof(Profile))]
        public IHttpActionResult DeleteProfile(int id)
        {
            Profile profile = db.Profile.Find(id);
            if (profile == null)
            {
                return NotFound();
            }

            db.Profile.Remove(profile);
            db.SaveChanges();

            return Ok(profile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProfileExists(int id)
        {
            return db.Profile.Count(e => e.Profile_Id == id) > 0;
        }
    }
}