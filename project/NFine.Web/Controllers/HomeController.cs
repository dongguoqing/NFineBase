/*******************************************************************************
 * Copyright © 2016 .Framework 版权所有
 * Author: 
 * Description: 快速开发平台
 * Website：http://www..cn
*********************************************************************************/
using NFine.Application.SystemManage;
using NFine.Code;
using NFine.Domain.Entity.SystemManage;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace NFine.Web.Controllers
{
    [HandlerLogin]
    public class HomeController : Controller
    {
        private NewsApp newsApp = new NewsApp();
        private NewsTypeApp newsTypeApp = new NewsTypeApp();

        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Default()
        {
            return View();
        }
        [HttpGet]
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Sign()
        {
          
            return View();
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetAnnouncement(string NewsTypeTwo)
        {
            List<NewsTypeEntity> listNewsTypeEntity = newsTypeApp.GetList("",NewsTypeTwo);//通过新闻类型名称获取对应的新闻Id
            List<NewsEntity> listNewsEntity = newsApp.GetList("",listNewsTypeEntity[0].F_Id);
            //listNewsEntity.GroupBy(a=>a.F_Id).Select(a=>new NewsEntity
            //{
            //    F_Id=a.Key,
            //    F_Content=a.First().F_Content,
            //    F_SortCode=a.Sum(b=>b.F_SortCode)
            //})
            return Json(listNewsEntity,JsonRequestBehavior.AllowGet);
        }
    }
}
