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
    public class InvestigatorsController : ApiController
    {
        private EntitiesInformante db = new EntitiesInformante();

        // GET: api/Investigators
        public IQueryable<APP_VI_INVESTIGATORS> GetAPP_VI_INVESTIGATORS()
        {
            return db.APP_VI_INVESTIGATORS;
        }

        // GET: api/Investigators/5
        [ResponseType(typeof(APP_VI_INVESTIGATORS))]
        public async Task<IHttpActionResult> GetAPP_VI_INVESTIGATORS(decimal id)
        {
            APP_VI_INVESTIGATORS aPP_VI_INVESTIGATORS = await db.APP_VI_INVESTIGATORS.FindAsync(id);
            if (aPP_VI_INVESTIGATORS == null)
            {
                return NotFound();
            }

            return Ok(aPP_VI_INVESTIGATORS);
        }

        // PUT: api/Investigators/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAPP_VI_INVESTIGATORS(decimal id, APP_VI_INVESTIGATORS aPP_VI_INVESTIGATORS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aPP_VI_INVESTIGATORS.INVESTIGATOR_ID)
            {
                return BadRequest();
            }

            db.Entry(aPP_VI_INVESTIGATORS).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APP_VI_INVESTIGATORSExists(id))
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

        // POST: api/Investigators
        [ResponseType(typeof(APP_VI_INVESTIGATORS))]
        public async Task<IHttpActionResult> PostAPP_VI_INVESTIGATORS(APP_VI_INVESTIGATORS aPP_VI_INVESTIGATORS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.APP_VI_INVESTIGATORS.Add(aPP_VI_INVESTIGATORS);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = aPP_VI_INVESTIGATORS.INVESTIGATOR_ID }, aPP_VI_INVESTIGATORS);
        }

        // DELETE: api/Investigators/5
        [ResponseType(typeof(APP_VI_INVESTIGATORS))]
        public async Task<IHttpActionResult> DeleteAPP_VI_INVESTIGATORS(decimal id)
        {
            APP_VI_INVESTIGATORS aPP_VI_INVESTIGATORS = await db.APP_VI_INVESTIGATORS.FindAsync(id);
            if (aPP_VI_INVESTIGATORS == null)
            {
                return NotFound();
            }

            db.APP_VI_INVESTIGATORS.Remove(aPP_VI_INVESTIGATORS);
            await db.SaveChangesAsync();

            return Ok(aPP_VI_INVESTIGATORS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool APP_VI_INVESTIGATORSExists(decimal id)
        {
            return db.APP_VI_INVESTIGATORS.Count(e => e.INVESTIGATOR_ID == id) > 0;
        }
    }
}