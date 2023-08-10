using Pagos.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

        // GET: Cliente/Details/5
        public ActionResult Details (int id)
        {
            using(DbModels context = new DbModels())
            {
                return View(context.tblCliente.Where(x => x.idCliente == id).FirstOrDefault()); //los id's sean iguales
            }
        }

        // GET: Cliente/Create
        public ActionResult Create ()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(tblCliente cliente)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    //Sumar el saldo
                    cliente.saldo += cliente.deposito;

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

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.tblCliente.Where(x => x.idCliente == id).FirstOrDefault());//Nos traerá el primero por defecto que sea 5
            }
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(tblCliente cliente)
        {
            
                if (ModelState.IsValid)
                {

                    using(DbModels context = new DbModels())
                    {
                        var availableBalance = context.tblCliente.Find(cliente.idCliente);

                        if (availableBalance != null)
                        {
                            availableBalance.saldo += cliente.deposito - cliente.retiro;
                            context.Entry(availableBalance).State = EntityState.Modified;
                            context.SaveChanges();

                            return RedirectToAction("Index");
                        }
                    }


                }
                return View(cliente);
            
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.tblCliente.Where(x => x.idCliente == id).FirstOrDefault());//Nos traerá el primero por defecto que sea 5
            }
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, tblCliente Cliente)
        {
            try
            {
                using(DbModels context = new DbModels())
                {
                    Cliente = context.tblCliente.Where(x => x.idCliente == id).FirstOrDefault();
                    context.tblCliente.Remove(Cliente);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Retiro/5
        public ActionResult Retiro(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.tblCliente.Where(x => x.idCliente == id).FirstOrDefault());//Nos traerá el primero por defecto que sea 5
            }
        }

        // POST: Cliente/Retiro/5
        [HttpPost]
        public ActionResult Retiro(int id,tblCliente cliente)
        {
            if (ModelState.IsValid)
            {

                using (DbModels context = new DbModels())
                {
                    var availableBalance = context.tblCliente.Find(cliente.idCliente);

                    if (availableBalance != null)
                    {
                        availableBalance.saldo += cliente.deposito - cliente.retiro;
                        context.Entry(availableBalance).State = EntityState.Modified;
                        context.SaveChanges();

                        return RedirectToAction("Index");
                    }
                }


            }
            return View(cliente);
        }



    }
}