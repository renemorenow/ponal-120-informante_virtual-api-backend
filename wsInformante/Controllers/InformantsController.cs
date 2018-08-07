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
    public class InformantsController : ApiController
    {
        private EntitiesInformante db = new EntitiesInformante();

        // GET: api/Informants
        public IQueryable<APP_VI_INFORMANTS> GetAPP_VI_INFORMANTS()
        {
            return db.APP_VI_INFORMANTS;
        }

        // GET: api/Informants/5
        [ResponseType(typeof(APP_VI_INFORMANTS))]
        public async Task<IHttpActionResult> GetAPP_VI_INFORMANTS(decimal id)
        {
            APP_VI_INFORMANTS aPP_VI_INFORMANTS = await db.APP_VI_INFORMANTS.FindAsync(id);
            if (aPP_VI_INFORMANTS == null)
            {
                return NotFound();
            }

            return Ok(aPP_VI_INFORMANTS);
        }

        // PUT: api/Informants/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAPP_VI_INFORMANTS(decimal id, APP_VI_INFORMANTS aPP_VI_INFORMANTS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aPP_VI_INFORMANTS.INFORMANT_ID)
            {
                return BadRequest();
            }

            db.Entry(aPP_VI_INFORMANTS).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APP_VI_INFORMANTSExists(id))
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

        // POST: api/Informants
        [ResponseType(typeof(APP_VI_INFORMANTS))]
        public async Task<IHttpActionResult> PostAPP_VI_INFORMANTS(APP_VI_INFORMANTS aPP_VI_INFORMANTS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.APP_VI_INFORMANTS.Add(aPP_VI_INFORMANTS);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = aPP_VI_INFORMANTS.INFORMANT_ID }, aPP_VI_INFORMANTS);
        }

        // DELETE: api/Informants/5
        [ResponseType(typeof(APP_VI_INFORMANTS))]
        public async Task<IHttpActionResult> DeleteAPP_VI_INFORMANTS(decimal id)
        {
            APP_VI_INFORMANTS aPP_VI_INFORMANTS = await db.APP_VI_INFORMANTS.FindAsync(id);
            if (aPP_VI_INFORMANTS == null)
            {
                return NotFound();
            }

            db.APP_VI_INFORMANTS.Remove(aPP_VI_INFORMANTS);
            await db.SaveChangesAsync();

            return Ok(aPP_VI_INFORMANTS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool APP_VI_INFORMANTSExists(decimal id)
        {
            return db.APP_VI_INFORMANTS.Count(e => e.INFORMANT_ID == id) > 0;
        }
    }
}