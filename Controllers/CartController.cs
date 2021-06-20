using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TruYum_Asp.Models;

namespace TruYum_ASP.Controllers
{
    public class CartController : Controller
    {
        public int UserId = 1;
        public truYumContext _context = new truYumContext();

        // GET: Cart
        public ActionResult Index()
        {
           /* var q = (from pd in _context.Cart
                     join od in _context.MenuItem on pd.MenuItemId equals od.Id
                     where pd.UserId == UserId && od.isActive == true
                     select od).ToList();*/
            
            var q = _context.Cart.Include("MenuItem").Where(x => x.UserId == UserId && x.MenuItem.isActive == true).ToList();
            List<MenuItems> menuItems = new List<MenuItems>();
            foreach (var i in q)
            {
                
                DateUtility nobj = new DateUtility();
                if (nobj.checkDate(i.MenuItem.DateOfLaunch))
                {
                    menuItems.Add(i.MenuItem);
                }
            }
            
            return View(q);
        }

        public ActionResult AddToCart(int? menuitemId)
        {
            var item = _context.MenuItem.Find(menuitemId);
            if(item==null)
            {
                return HttpNotFound();
            }
            try
            {
                Cart cartobj = new Cart()
                { 
                    UserId = UserId,
                    MenuItemId= (int)menuitemId
                };

                _context.Cart.Add(cartobj);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            catch(Exception e)
            {
                ViewBag.e = e;
                return View("Error");
            }

        }
        public ActionResult Delete(int? id )
        {

            var item = _context.MenuItem.Find(id);
            if(item==null)
            {
                return HttpNotFound();
            }
            try
            {
                var itemToDel = _context.Cart.Where(x => x.MenuItemId == id).First();
                _context.Cart.Remove(itemToDel);
                _context.SaveChanges();

                return RedirectToAction("index");
            }
            catch(Exception e)
            {
                ViewBag.e = e;
                return View("Error");
            }
        }
    }
}