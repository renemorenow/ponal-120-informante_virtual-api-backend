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
    public class ContributionsController : ApiController
    {
        private EntitiesInformante db = new EntitiesInformante();

        // GET: api/Contributions
        public IQueryable<APP_VI_CONTRIBUTIONS> GetAPP_VI_CONTRIBUTIONS()
        {
            return db.APP_VI_CONTRIBUTIONS;
        }

        // GET: api/Contributions/5
        [ResponseType(typeof(APP_VI_CONTRIBUTIONS))]
        public async Task<IHttpActionResult> GetAPP_VI_CONTRIBUTIONS(decimal id)
        {
            APP_VI_CONTRIBUTIONS aPP_VI_CONTRIBUTIONS = await db.APP_VI_CONTRIBUTIONS.FindAsync(id);
            if (aPP_VI_CONTRIBUTIONS == null)
            {
                return NotFound();
            }

            return Ok(aPP_VI_CONTRIBUTIONS);
        }

        // PUT: api/Contributions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAPP_VI_CONTRIBUTIONS(decimal id, APP_VI_CONTRIBUTIONS aPP_VI_CONTRIBUTIONS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aPP_VI_CONTRIBUTIONS.CONTRIBUTION_ID)
            {
                return BadRequest();
            }

            db.Entry(aPP_VI_CONTRIBUTIONS).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APP_VI_CONTRIBUTIONSExists(id))
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

        // POST: api/Contributions
        [ResponseType(typeof(APP_VI_CONTRIBUTIONS))]
        public async Task<IHttpActionResult> PostAPP_VI_CONTRIBUTIONS(APP_VI_CONTRIBUTIONS aPP_VI_CONTRIBUTIONS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.APP_VI_CONTRIBUTIONS.Add(aPP_VI_CONTRIBUTIONS);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = aPP_VI_CONTRIBUTIONS.CONTRIBUTION_ID }, aPP_VI_CONTRIBUTIONS);
        }

        // DELETE: api/Contributions/5
        [ResponseType(typeof(APP_VI_CONTRIBUTIONS))]
        public async Task<IHttpActionResult> DeleteAPP_VI_CONTRIBUTIONS(decimal id)
        {
            APP_VI_CONTRIBUTIONS aPP_VI_CONTRIBUTIONS = await db.APP_VI_CONTRIBUTIONS.FindAsync(id);
            if (aPP_VI_CONTRIBUTIONS == null)
            {
                return NotFound();
            }

            db.APP_VI_CONTRIBUTIONS.Remove(aPP_VI_CONTRIBUTIONS);
            await db.SaveChangesAsync();

            return Ok(aPP_VI_CONTRIBUTIONS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool APP_VI_CONTRIBUTIONSExists(decimal id)
        {
            return db.APP_VI_CONTRIBUTIONS.Count(e => e.CONTRIBUTION_ID == id) > 0;
        }
    }
}