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
using System.Linq;
using System.Web.Mvc;
using System.CodeDom;

namespace NFine.Web.Areas.SystemManage.Controllers
{
    public class ModuleController : ControllerBase
    {
        private ModuleApp moduleApp = new ModuleApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeSelectJson()
        {
            var data = moduleApp.GetList();
            var treeList = new List<TreeSelectModel>();
            foreach (ModuleEntity item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.F_Id;
                treeModel.text = item.F_FullName;   
                treeModel.parentId = item.F_ParentId;
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeSelectJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeGridJson(string keyword)
        {
            var data = moduleApp.GetList();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.TreeWhere(t => t.F_FullName.Contains(keyword));
            }
            var treeList = new List<TreeGridModel>();
            foreach (ModuleEntity item in data)
            {
                TreeGridModel treeModel = new TreeGridModel();
                bool hasChildren = data.Count(t => t.F_ParentId == item.F_Id) == 0 ? false : true;
                treeModel.id = item.F_Id;
                treeModel.isLeaf = hasChildren;
                treeModel.parentId = item.F_ParentId;
                treeModel.expanded = hasChildren;
                treeModel.entityJson = item.ToJson();
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeGridJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = moduleApp.GetForm(keyValue);
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ModuleEntity moduleEntity, string keyValue)
        {
            moduleApp.SubmitForm(moduleEntity, keyValue);
            return Success("操作成功。");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            moduleApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }

        ///// <summary>
        /////  创建路径对应的文件夹
        ///// </summary>
        ///// <param name="moduleEntity">创建的模块实体类</param>
        ///// <param name="ketValue">主键</param>
        ///// <returns></returns>
        //public bool CreateUrlFile(ModuleEntity moduleEntity,string ketValue) {
        //    string[] F_UrlAddress = moduleEntity.F_UrlAddress.Split(new char[] { '/'},System.StringSplitOptions.RemoveEmptyEntries);//获取模块的路径全名 分割成文件夹
        //    int muluId = 0;
        //    for (int i = 0; i < F_UrlAddress.Length; i++)
        //    {
        //        if (i == 0)
        //        {
        //            string filePath = Server.MapPath("\\Areas\\" + F_UrlAddress[i] + ""); // Areas/SystemManage/Area
        //            string controllerFile = Server.MapPath("\\Areas\\" + F_UrlAddress[i - 1] + "\\Controllers");// Areas/SustemManage/Controllers
        //            string viewFile = Server.MapPath("\\Areas\\" + F_UrlAddress[i - 1] + "\\Views");// Areas/SustemManage/Views
        //            FileHelper.CreateDir(filePath);
        //            FileHelper.CreateDir(controllerFile);
        //            FileHelper.CreateDir(viewFile);
        //        }
        //        else if(i==1)
        //        {
                   
        //        }
        //        muluId++;
        //    }

        //}

    }
}
