using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.SystemManage.Controllers
{
    public class TestController:ControllerBase
    {
        private static ServiceReference1.BlueearthWebServiceSoapClient client = new ServiceReference1.BlueearthWebServiceSoapClient();

        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult ChangeProject(string Sign)
        {
            string pr1 = client.ChangeProject(new ServiceReference1.MySoapHeader() { userName = "jiuyunadmin", passWord = "jiuyun" }, Sign);
            return Content(pr1);
        }

        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult AddProject(string ProjectID,string ProjectName,string ProjectSign)
        {
            string result = client.CreateTable(new ServiceReference1.MySoapHeader() { userName = "jiuyunadmin", passWord = "jiuyun" }, ProjectID, ProjectName, ProjectSign);
            return Content(result);
        }

        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult UploadBIM(string fileUrl, string fileName, string fileExt)
        {
            string pr2 = client.UploadBIM(new ServiceReference1.MySoapHeader() { userName = "jiuyunadmin", passWord = "jiuyun" },fileUrl, fileName, fileExt);
            return Content(pr2);
        }

        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult PutInStorageConfigure(string ProjectSign, string BeeName, string x, string y, string z, string VersionName, string TreeName)
        {
            string p4 = client.IsSuccess(new ServiceReference1.MySoapHeader() { userName = "jiuyunadmin", passWord = "jiuyun" }, "test", ".rvt");
            string pr3 = string.Empty;
            if (p4 == "{\"status\": \"1\",\"message\":\"模型转换成功\"}")
            {
                pr3 = client.PutInStorageConfigure(new ServiceReference1.MySoapHeader() { userName = "jiuyunadmin", passWord = "jiuyun" }, ProjectSign, BeeName, x, y, z, VersionName, TreeName);
            }
            else
                pr3 = "{\"status\": \"0\",\"message\":\"请先等待模型转换完毕\"}";
            return Content(pr3);
        }

        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult GetAll()
        {
            string p1 = client.GetAllProject(new ServiceReference1.MySoapHeader() { userName = "jiuyunadmin", passWord = "jiuyun" });
            return Content(p1);
        }
    }


}