
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TruYum_Asp.Models;

namespace TruYum_ASP.Controllers
{
    public class MenuItemController : Controller
    {
        private truYumContext _context = new truYumContext();
       
        // GET: MenuItem
        public ActionResult Index(bool isAdmin=false)
        {
            ViewBag.isAdmin = isAdmin;
            if(isAdmin==true)
            {
                return View(_context.MenuItem.Include("Category").ToList());
            }

            var x2= _context.MenuItem.Include("Category").Where(x => x.isActive == true).ToList();
            List<MenuItems> menuItems = new List<MenuItems>();
            foreach(var i in x2)
            {
                DateUtility nobj = new DateUtility();
                if(nobj.checkDate(i.DateOfLaunch))
                {
                    menuItems.Add(i);
                }
            }
            return View(menuItems);
            
        }
        public ActionResult Create()
        {
            var categories = _context.Categories.ToList();
            
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public ActionResult Create(MenuItems m)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            try
            {

                _context.MenuItem.Add(m);
                _context.SaveChanges();
                return RedirectToAction("Index", new { isAdmin = true });
            }

            catch(Exception e)
            {
                ViewBag.e = e;
                return View("Error");
            }
            
        }


        public ActionResult Edit(int? id)
        {
            var m = _context.MenuItem.Find(id);
            if (m==null)
            {
                return HttpNotFound();
            }
            try
            {
                var categories = _context.Categories.ToList();
                ViewBag.Categories = categories;
                return View(m);
            }
            catch (Exception e)
            {
                ViewBag.e = e;
                return View("Error");
            }

        }

        [HttpPost]
        public ActionResult Edit(MenuItems m)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _context.Entry(m).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index", new { isAdmin = true });
            }
            catch (Exception e)
            {
                ViewBag.e = e;
                return View("Error");
            }
        }

        public ActionResult Delete(int? id)
        {
            var item = _context.MenuItem.Find(id);
            if ( item == null)
            {
                return HttpNotFound();
            }
            try
            {
                _context.MenuItem.Remove(item);
                _context.SaveChanges();
                return RedirectToAction("index",new { isAdmin = true });
            }
            catch(Exception e)
            {
                
                ViewBag.e = e; 
                return View("Error");
            }
        }
    }
}