using Pagos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pagos.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            using (DbModels context = new DbModels())
            {

                return View(context.tblCliente.ToList());

            }
        }

        //GET: Cliente/Details/5
        public ActionResult Details (int id)
        {
            using(DbModels context = new DbModels())
            {
                return View(context.tblCliente.Where(x => x.idCliente == id)); //los id's sean iguales
            }
        }

        // GET: Cliente/Create
        public ActionResult Create (int id)
        {
            return View();
        }

        // POST: Cliente/Create
        public ActionResult Create(tblCliente cliente)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    context.tblCliente.Add(cliente);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}