
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
        private static truYumContext _context = new truYumContext();
        private List<Category> categories = _context.Categories.ToList();

        // GET: MenuItem
        public ActionResult Index(bool isAdmin=false)
        {
            ViewBag.isAdmin = isAdmin;
            if(isAdmin==true)
            {
                return View(_context.MenuItem.Include("Category").OrderBy(x=>x.Name).ToList());
            }

            var ActiveItems= _context.MenuItem.Include("Category").Where(x => x.isActive == true).ToList();
            List<MenuItems> CustMenuItems = new List<MenuItems>();
            foreach (var items in ActiveItems)
            {
                DateUtility nobj = new DateUtility();
                if (nobj.checkDate(items.DateOfLaunch))
                {
                    CustMenuItems.Add(items);
                }
            }
            return View(CustMenuItems);
            
        }
        public ActionResult Create()
        {
            
            
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public ActionResult Create(MenuItems item)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            try
            {

                _context.MenuItem.Add(item);
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