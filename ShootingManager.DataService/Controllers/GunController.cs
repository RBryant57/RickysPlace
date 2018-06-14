using ShootingManager.Entities.Models;
using ShootingManager.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShootingManager.DataService.Controllers
{
    public class GunController : ApiController
    {
        // GET: api/Gun
        public IEnumerable<GunView> GetGuns()
        {
            var gunService = new GunService();
            return gunService.GetGunViews();
        }

        // GET: api/Gun/5
        public GunView GetGun(int id)
        {
            var gunService = new GunService();
            return gunService.GetGunViews().Where(g => g.Id == id).First();
        }

        // POST: api/Gun
        public void Post([FromBody]Gun value)
        {
            var gunService = new GunService();
            gunService.Add(value);
        }

        // PUT: api/Gun/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Gun/5
        public void Delete(int id)
        {
        }
    }
}
