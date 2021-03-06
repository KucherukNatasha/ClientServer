﻿using System;
using System.IO;
using Client.Models;
using Microsoft.AspNetCore.Mvc;
namespace Client.Controllers
{
    public class HomeController : Controller
    {
        public  SocketClient socketClient;
        public HomeController(SocketClient sockCl)
        {
            socketClient = sockCl;
        }
        public ActionResult Index()
        {
            return View();
        }
        
       
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PostData ()
        {   //То же касается запроса. Проверка модели здесь не будет работать. Мы работаем з данными запроса, а не модели!!! Оставляю для наглядности просто.
            if (ModelState.IsValid)
            {
                GetRequest();
                return RedirectToAction("Index");
            }
            else { 
                return RedirectToAction("Add");
            }
        }
        [HttpGet]
        public JsonResult GetData()
        {
            object obj = GetRequest();
            return Json(obj);
        }


        private Object GetRequest()
        {
            object obj;
            string s = Request.HttpContext.Request.Method;
            PersonData personData = new PersonData();
            using (var reader = new StreamReader(Request.Body))
            {
                var body = reader.ReadToEnd();
                string postStr = $"{s}&{body}";
                obj=socketClient.KlientPostGet(postStr);
            }
            return obj;
        }
       

    }
}