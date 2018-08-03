using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using wsInformante.Models;
using ServiceStack.Text;
using System.Configuration.Provider;

namespace wsInformante.Controllers
{
    //[RoutePrefix("api/Investigations")]
    public class InvestigationsController : ApiController
    {
        public InvestigationsController()
        {
        }
        private EntitiesInformante db = new EntitiesInformante();

        // GET: api/Investigations
        public IQueryable<APP_VI_INVESTIGATIONS> GetAPP_VI_INVESTIGATIONS()
        {
            return db.APP_VI_INVESTIGATIONS;
        }

        // GET: api/Investigations/5
        [ResponseType(typeof(APP_VI_INVESTIGATIONS))]
        public async Task<IHttpActionResult> GetAPP_VI_INVESTIGATIONS(decimal id)
        {
            APP_VI_INVESTIGATIONS aPP_VI_INVESTIGATIONS = await db.APP_VI_INVESTIGATIONS.FindAsync(id);
            if (aPP_VI_INVESTIGATIONS == null)
            {
                return NotFound();
            }
                        
            var result = JsonConvert.SerializeObject(aPP_VI_INVESTIGATIONS);

            return Ok(aPP_VI_INVESTIGATIONS);
        }

        // PUT: api/Investigations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAPP_VI_INVESTIGATIONS(decimal id, APP_VI_INVESTIGATIONS aPP_VI_INVESTIGATIONS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aPP_VI_INVESTIGATIONS.INVESTIGATION_ID)
            {
                return BadRequest();
            }

            db.Entry(aPP_VI_INVESTIGATIONS).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APP_VI_INVESTIGATIONSExists(id))
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

        // POST: api/Investigations
        [ResponseType(typeof(APP_VI_INVESTIGATIONS))]
        //[Route("Investigations")]
        public async Task<IHttpActionResult> PostAPP_VI_INVESTIGATIONS(APP_VI_INVESTIGATIONS aPP_VI_INVESTIGATIONS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.APP_VI_INVESTIGATIONS.Add(aPP_VI_INVESTIGATIONS);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = aPP_VI_INVESTIGATIONS.INVESTIGATION_ID }, aPP_VI_INVESTIGATIONS);
        }

        // DELETE: api/Investigations/5
        [ResponseType(typeof(APP_VI_INVESTIGATIONS))]
        public async Task<IHttpActionResult> DeleteAPP_VI_INVESTIGATIONS(decimal id)
        {
            APP_VI_INVESTIGATIONS aPP_VI_INVESTIGATIONS = await db.APP_VI_INVESTIGATIONS.FindAsync(id);
            if (aPP_VI_INVESTIGATIONS == null)
            {
                return NotFound();
            }

            db.APP_VI_INVESTIGATIONS.Remove(aPP_VI_INVESTIGATIONS);
            await db.SaveChangesAsync();

            return Ok(aPP_VI_INVESTIGATIONS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool APP_VI_INVESTIGATIONSExists(decimal id)
        {
            return db.APP_VI_INVESTIGATIONS.Count(e => e.INVESTIGATION_ID == id) > 0;
        }
    }
}