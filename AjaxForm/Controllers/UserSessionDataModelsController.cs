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
using AjaxForm.DataContext;
using AjaxForm.Models;

namespace AjaxForm.Controllers
{
    public class UserSessionDataModelsController : ApiController
    {
        private SessionContext db = new SessionContext();

        // GET: api/UserSessionDataModels
        public IQueryable<UserSessionDataModel> GetForms()
        {
            return db.Forms;
        }

        // GET: api/UserSessionDataModels/5
        [ResponseType(typeof(UserSessionDataModel))]
        public IHttpActionResult GetUserSessionDataModel(int id)
        {
            UserSessionDataModel userSessionDataModel = db.Forms.Find(id);
            if (userSessionDataModel == null)
            {
                return NotFound();
            }

            return Ok(userSessionDataModel);
        }

        // PUT: api/UserSessionDataModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserSessionDataModel(int id, UserSessionDataModel userSessionDataModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userSessionDataModel.Id)
            {
                return BadRequest();
            }

            db.Entry(userSessionDataModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSessionDataModelExists(id))
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

        // POST: api/UserSessionDataModels
        [ResponseType(typeof(UserSessionDataModel))]
        public IHttpActionResult PostUserSessionDataModel(UserSessionDataModel userSessionDataModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Forms.Add(userSessionDataModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userSessionDataModel.Id }, userSessionDataModel);
        }

        // DELETE: api/UserSessionDataModels/5
        [ResponseType(typeof(UserSessionDataModel))]
        public IHttpActionResult DeleteUserSessionDataModel(int id)
        {
            UserSessionDataModel userSessionDataModel = db.Forms.Find(id);
            if (userSessionDataModel == null)
            {
                return NotFound();
            }

            db.Forms.Remove(userSessionDataModel);
            db.SaveChanges();

            return Ok(userSessionDataModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserSessionDataModelExists(int id)
        {
            return db.Forms.Count(e => e.Id == id) > 0;
        }
    }
}