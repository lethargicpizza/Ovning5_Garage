using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityDemo.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            ViewBag.Title = "Index";
            return View("Index");
        }

        [AllowAnonymous]
        public ActionResult Public()
        {
            ViewBag.Title = "Public";
            return View("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            ViewBag.Title = "Admin";
            return View("Index");
        }

        [OverrideAuthorization]
        [Authorize(Roles = "Editor")]
        public ActionResult Editor()
        {
            ViewBag.Title = "Editor";
            return View("Index");
        }

        [Authorize(Roles = "Editor, Admin")]
        public ActionResult AdminOrEditor()
        {
            ViewBag.Title = "AdminOrEditor";
            return View("Index");
        }

        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Editor")]
        public ActionResult AdminAndEditor()
        {
            ViewBag.Title = "AdminAndEditor";
            return View("Index");
        }

        [Authorize(Users ="jocke@lexicon.se", Roles ="Admin")]   // ingen vidare användbar lösning
        public ActionResult Jocke()
        {
            ViewBag.Title = "Jocke";
            return View("Index");
        }
    }
}