using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proficiencytoday.Models.Business_logic;

namespace proficiencytoday.Controllers
{
    public class CardDatasController : Controller
    {
        private ProductEntities db = new ProductEntities();

        // GET: CardDatas
        public ActionResult Index()
        {
            return View(db.CardDatas.ToList());
        }
        public ActionResult OrderPlaced()
        {
            return View();
        }


        // GET: CardDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardData cardData = db.CardDatas.Find(id);
            if (cardData == null)
            {
                return HttpNotFound();
            }
            return View(cardData);
        }

        // GET: CardDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CardDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,CardNumber,ExpirationDate,Cvv")] CardData cardData)
        {
            if (ModelState.IsValid)
            {
                db.CardDatas.Add(cardData);
                db.SaveChanges();
                return RedirectToAction("OrderPlaced");
            }

            return View(cardData);
        }

        // GET: CardDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardData cardData = db.CardDatas.Find(id);
            if (cardData == null)
            {
                return HttpNotFound();
            }
            return View(cardData);
        }

        // POST: CardDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,CardNumber,ExpirationDate,Cvv")] CardData cardData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cardData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cardData);
        }

        // GET: CardDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardData cardData = db.CardDatas.Find(id);
            if (cardData == null)
            {
                return HttpNotFound();
            }
            return View(cardData);
        }

        // POST: CardDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CardData cardData = db.CardDatas.Find(id);
            db.CardDatas.Remove(cardData);
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
