using NFine.Application.SystemManage;
using NFine.Code;
using NFine.Domain.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.SystemManage.Controllers
{
    public class NewsController : ControllerBase
    {
        private NewsApp newsApp = new NewsApp();
        private NewsTypeApp newsTypeApp = new NewsTypeApp();

        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var newsTypeList = newsTypeApp.GetList();
            var listResult = (from a in newsApp.GetList(pagination, keyword)
                              join b in newsTypeList on a.F_Type equals b.F_Id into temp
                              from c in temp.DefaultIfEmpty()
                              select new NewsEntity
                              {
                                  F_Id = a.F_Id,
                                  F_Author = a.F_Author,
                                  F_Content = a.F_Content,
                                  F_From = a.F_From,
                                  F_CreatorTime = a.F_CreatorTime,
                                  F_Status = a.F_Status,
                                  F_Title = a.F_Title,
                                  F_Type = c.F_Name,

                              }).ToList();

            var data = new
            {
                rows = listResult,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }

        public ActionResult DeleteForm(string keyValue)
        {
            newsApp.DeleteForm(keyValue);
            return Success("操作成功。");
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetNewsType()
        {
            var list = newsTypeApp.GetList();
            var treeList = new List<TreeSelectModel>();
            foreach (NewsTypeEntity item in list)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.F_Id;
                treeModel.text = item.F_Name;
                treeModel.parentId = "0";
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeSelectJson());
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SubmitForm(NewsEntity newsEntity, string keyValue)
        {
            newsEntity.F_CreatorUserId = OperatorProvider.Provider.GetCurrent().UserCode;
            newsEntity.F_Status = 1;
            newsEntity.F_SortCode = 1;
            newsApp.SubmitForm(newsEntity, keyValue);
            return Success("操作成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult UploadImg()
        {
            HttpPostedFileBase file = Request.Files["fileDataFileName"];
            FileHelper.UpLoadResult result = FileHelper.UploadImage(file);
            return Json(result);
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = newsApp.GetForm(keyValue);
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAuthorize]
        public override ActionResult Index()
        {
           // ServiceReference1.BlueearthWebServiceSoapClient client = new ServiceReference1.BlueearthWebServiceSoapClient();
           // string result = client.CreateTable(new ServiceReference1.MySoapHeader() { userName = "jiuyunadmin", passWord = "jiuyun" }, "19EE595A-E775-409D-A48F-B33CF9F262C7", "蓝色星球", "lsxq");
           // string pr = client.GetAllProject(new ServiceReference1.MySoapHeader() { userName = "jiuyunadmin", passWord = "jiuyun" });
           // string pr1 = client.ChangeProject(new ServiceReference1.MySoapHeader() { userName = "jiuyunadmin", passWord = "jiuyun" }, "19EE595A-E775-409D-A48F-B33CF9F262C7");
           //// string pr2 = client.UploadBIM(new ServiceReference1.MySoapHeader() { userName = "jiuyunadmin", passWord = "jiuyun" }, @"D:\project\Amyself\NFine快速开发框架\project\NFine.Web\templates\版本B.rvt", "版本B", ".rvt");
           // string p4 = client.IsSuccess(new ServiceReference1.MySoapHeader() { userName = "jiuyunadmin", passWord = "jiuyun" }, "版本B", ".rvt");
           // string pr3 = client.PutInStorageConfigure(new ServiceReference1.MySoapHeader() { userName = "jiuyunadmin", passWord = "jiuyun" }, "普华", "ph", @"D:\project\Amyself\NFine快速开发框架\project\NFine.Web\templates\版本A.bms", "", "", "", "1.0", "普华");
            return View();
        }

    }
}