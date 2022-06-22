using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebBigSchool.DTO;
using WebBigSchool.Models;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace WebBigSchool.Controllers
{
    public class FollowingsController : ApiController
    {
        // GET: Followings
        private readonly ApplicationDbContext _dbContext;
        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var UserId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FolloweedId == UserId && f.FolloweedId == followingDto.FolloweeId))
                return BadRequest("Following already exits");
            var following = new Following
            {
                FollowerId = UserId,
                FolloweedId = followingDto.FolloweeId
            };
            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();
            return Ok();
        }
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}