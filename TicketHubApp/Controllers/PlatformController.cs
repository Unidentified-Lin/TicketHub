﻿using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketHubApp.Models.ViewModels;
using TicketHubApp.Services;
using TicketHubDataLibrary.Models;

namespace TicketHubApp.Controllers
{
    [Authorize]
    public class PlatformController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // User 會員管理 //
        public ActionResult UserList()
        {
            return View();
        }

        public ActionResult UserDetail(string id)
        {
            PlatformService service = new PlatformService();
            var user = service.GetUser(id);

            return View(user);
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser([Bind(Include = "UserAccount, UserPwd, UserName, Mobile, Sex")] PlatformUserViewModel userVM)
        {
            var userManager = HttpContext.GetOwinContext().Get<AppIdentityUserManager>();

            PlatformService service = new PlatformService();
            var createResult = service.CreateUser(userVM, userManager);

            return RedirectToAction("CreateUser", "Platform");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser([Bind(Include = "Id, UserName, Mobile, Sex")] PlatformUserViewModel userVM)
        {
            PlatformService service = new PlatformService();
            service.EditUserById(userVM);

            return RedirectToAction($"UserDetail/{userVM.Id}");
        }

        public ActionResult DeleteUser(string id)
        {
            PlatformService service = new PlatformService();
            service.DeleteUserById(id);

            return RedirectToAction("UserList");
        }
        public ActionResult RestoreUser(string id)
        {
            PlatformService service = new PlatformService();
            service.RestoreUserById(id);

            return RedirectToAction("UserList");
        }

        public ActionResult GetTicketsBelongsToThisUser(string id)
        {
            ViewBag.id = id;
            return View();
        }

        public ActionResult GetUsersJson()
        {
            PlatformService service = new PlatformService();
            var usersTableData = service.GetUsersTableData();

            return Json(usersTableData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTicketsByUserJson(string id)
        {
            PlatformService service = new PlatformService();
            var ticketsTableData = service.GetTicketsTableData(id);

            return Json(ticketsTableData, JsonRequestBehavior.AllowGet);
        }

        // Shop 商家管理 //
        public ActionResult ShopList()
        {
            return View();
        }

        public ActionResult ShopDetail(string id)
        {
            PlatformService service = new PlatformService();
            var shop = service.GetShop(id);

            return View(shop);
        }

        public ActionResult ReviewShops()
        {
            return View();
        }

        public ActionResult GetAllEmployees(string id)
        {
            ViewBag.id = id;
            return View();
        }
        public ActionResult GetAllIssues(string id)
        {
            ViewBag.id = id;

            return View();
        }

        // Get Shop JSON Data //
        public ActionResult GetShopsJson()
        {
            PlatformService service = new PlatformService();
            var shopsTableData = service.GetShopsTableData();

            return Json(shopsTableData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetEmployeesByShopJson(string id)
        {
            PlatformService service = new PlatformService();
            var employeesTableData = service.GetEmployeesTableData(id);

            return Json(employeesTableData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetIssuessByShopJson(string id)
        {
            PlatformService service = new PlatformService();
            var issueTableData = service.GetIssuesTableData(id);

            return Json(issueTableData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetShopsToBeReviewdJson()
        {
            PlatformService service = new PlatformService();
            var shopsToBeReviewedTableData = service.GetShopsToBeReviewedTableData();

            return Json(shopsToBeReviewedTableData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSalesDataByIssue(string id)
        {

            PlatformService service = new PlatformService();
            var issueSalesData = service.GetSalesData(id);

            return Json(issueSalesData, JsonRequestBehavior.AllowGet);
        }

        // Order 訂單管理 //
        public ActionResult OrderList()
        {
            return View();
        }

        public ActionResult GetOrdersJsonData()
        {
            PlatformService service = new PlatformService();
            var orders = service.GetAllOrders();

            return Json(orders, JsonRequestBehavior.AllowGet);
        }

        // Admin 管理者 //
        public ActionResult AdminList()
        {
            return View();
        }


        public ActionResult AdminDetail(string id)
        {
            PlatformService service = new PlatformService();
            var admin = service.GetAdmin(id);

            return View(admin);
        }

        // Get Json Action
        public ActionResult GetAdminsJson()
        {
            PlatformService service = new PlatformService();
            var adminsTableData = service.GetAdminsTableData();

            return Json(adminsTableData, JsonRequestBehavior.AllowGet);
        }
    }
}