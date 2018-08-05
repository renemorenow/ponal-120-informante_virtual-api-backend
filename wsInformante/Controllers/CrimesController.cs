using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using wsInformante.Models;

namespace wsInformante.Controllers
{
    public class CrimesController : ApiController
    {
        private EntitiesInformante db = new EntitiesInformante();

        // GET: api/Crimes
        public IQueryable<APP_VI_CRIMES> GetAPP_VI_CRIMES()
        {
            return db.APP_VI_CRIMES;
        }

        // GET: api/Crimes/5
        [ResponseType(typeof(APP_VI_CRIMES))]
        public async Task<IHttpActionResult> GetAPP_VI_CRIMES(decimal id)
        {
            APP_VI_CRIMES aPP_VI_CRIMES = await db.APP_VI_CRIMES.FindAsync(id);
            if (aPP_VI_CRIMES == null)
            {
                return NotFound();
            }

            return Ok(aPP_VI_CRIMES);
        }

        // PUT: api/Crimes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAPP_VI_CRIMES(decimal id, APP_VI_CRIMES aPP_VI_CRIMES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aPP_VI_CRIMES.CRIME_ID)
            {
                return BadRequest();
            }

            db.Entry(aPP_VI_CRIMES).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APP_VI_CRIMESExists(id))
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

        // POST: api/Crimes
        [ResponseType(typeof(APP_VI_CRIMES))]
        public async Task<IHttpActionResult> PostAPP_VI_CRIMES(APP_VI_CRIMES aPP_VI_CRIMES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.APP_VI_CRIMES.Add(aPP_VI_CRIMES);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = aPP_VI_CRIMES.CRIME_ID }, aPP_VI_CRIMES);
        }

        // DELETE: api/Crimes/5
        [ResponseType(typeof(APP_VI_CRIMES))]
        public async Task<IHttpActionResult> DeleteAPP_VI_CRIMES(decimal id)
        {
            APP_VI_CRIMES aPP_VI_CRIMES = await db.APP_VI_CRIMES.FindAsync(id);
            if (aPP_VI_CRIMES == null)
            {
                return NotFound();
            }

            db.APP_VI_CRIMES.Remove(aPP_VI_CRIMES);
            await db.SaveChangesAsync();

            return Ok(aPP_VI_CRIMES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool APP_VI_CRIMESExists(decimal id)
        {
            return db.APP_VI_CRIMES.Count(e => e.CRIME_ID == id) > 0;
        }
    }
}