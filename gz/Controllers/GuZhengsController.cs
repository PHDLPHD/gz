using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using gz.Models;

namespace gz.Controllers
{
    public class GuZhengsController : Controller
    {
        private GuZhengDBcontext db = new GuZhengDBcontext();

        // GET: GuZhengs
        public ActionResult Index()
        {
            return View(db.GetGuZheng.ToList());
        }

        // GET: GuZhengs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuZheng guZheng = db.GetGuZheng.Find(id);
            if (guZheng == null)
            {
                return HttpNotFound();
            }
            return View(guZheng);
        }

        // GET: GuZhengs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GuZhengs/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GZNumber,MaterialCname,GZPhotoAddress,GZCname,TechnologyCname,GZprice")] GuZheng guZheng)
        {
            if (ModelState.IsValid)
            {
                db.GetGuZheng.Add(guZheng);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guZheng);
        }

        // GET: GuZhengs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuZheng guZheng = db.GetGuZheng.Find(id);
            if (guZheng == null)
            {
                return HttpNotFound();
            }
            return View(guZheng);
        }

        // POST: GuZhengs/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GZNumber,MaterialCname,GZPhotoAddress,GZCname,TechnologyCname,GZprice")] GuZheng guZheng)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guZheng).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guZheng);
        }

        // GET: GuZhengs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuZheng guZheng = db.GetGuZheng.Find(id);
            if (guZheng == null)
            {
                return HttpNotFound();
            }
            return View(guZheng);
        }

        // POST: GuZhengs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GuZheng guZheng = db.GetGuZheng.Find(id);
            db.GetGuZheng.Remove(guZheng);
            db.SaveChanges();
            return RedirectToAction("Index");
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
