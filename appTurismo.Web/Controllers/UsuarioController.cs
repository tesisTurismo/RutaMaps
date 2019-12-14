using appTurismo.Web.App_Start;
using appTurismoIqq.Modelo;
using MongoDB.Bson;
using MongoDB.Driver;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appTurismo.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly MongoContext db = new MongoContext();
        string conec = "mongodb+srv://user:tesis123456@tesis1-7onzc.azure.mongodb.net/test";
        string bdname = "bdTurismo";
      

        // GET: Usuario
        public ActionResult Index()
        {
            var cliente = new MongoClient(conec);

            var database = cliente.GetDatabase(bdname);
            var usuarios = database.GetCollection<Usuario>("usuario").Find(new BsonDocument()).ToList();
            return View(usuarios);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Usuario usu)
        {
            try
            {
                // TODO: Add insert logic here
                var cliente = new MongoClient(conec);

                var database = cliente.GetDatabase(bdname);
                var usuarios = database.GetCollection<Usuario>("usuario");
                usuarios.InsertOneAsync(usu);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
