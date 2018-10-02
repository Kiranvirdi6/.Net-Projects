using MemberClubDBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemberClubUIPractice.Controllers
{
    public class GamesController : Controller
    {
        private Model1Container db = new Model1Container();
        // GET: Games
        public ActionResult Index()
        {
            return View(db.Games.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int? id)
        {
            return View();
        }
        public ActionResult Details(int? id)
        {
            return View();
        }
        public ActionResult Delete(int? id)
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}