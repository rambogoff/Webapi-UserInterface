using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserPortalWeb.Models;

namespace UserPortalWeb.Controllers
{
    public class HomeController : ApiController
    {
        [Authorize] // token mekanizmasından geçenler buraya gelir //startup ve //tokenAuthoricationProvider
        public List<User> Get()
        {
            using (var db = new Context())
            {
               return db.Users.ToList();
            }
        }
        [Authorize]
        [HttpPost]
        public void Add(User user) //New_Add_login
        {
            using (var db = new Context())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        [HttpPut]
        public void Update(User user)
        {
            User dbUser;
            using (var db = new Context())
            {
                dbUser = db.Users.SingleOrDefault(x => x.Id == user.Id);
                dbUser.FirstName = user.FirstName;
                dbUser.LastName = user.LastName;
                dbUser.Mail = user.Mail;
                dbUser.Password = user.Password;
                dbUser.PhoneNumber = user.PhoneNumber;
                db.SaveChanges();
            }
        }
    }
}
