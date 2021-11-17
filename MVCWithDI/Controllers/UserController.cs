using MVCWithDI.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithDI.Controllers
{
    public class UserController : Controller
    {
        readonly IUserMasterRepository userRepository;
        public UserController(IUserMasterRepository repository)
        {
            this.userRepository = repository;
        }
        // GET: User
        public ActionResult Index()
        {
            DataTable dt = userRepository.GetAll();
                return View(dt);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var data = userRepository.Get(id);
            return View(data);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserMaster userMaster)
        {
            try
            {

                userRepository.Add(userMaster);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var dt = userRepository.Get(id);
            return View(dt);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserMaster userMaster)
        {
            try
            {
                // TODO: Add update logic here

                userRepository.Update(userMaster);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var dt = userRepository.Get(id);
            return View(dt);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                userRepository.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
