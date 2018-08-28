using NFine.Application.SystemManage;
using NFine.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NFine.Domain.Entity.SystemManage;

namespace NFine.Web.Areas.SystemManage.Controllers
{
    public class FileController : ControllerBase
    {
        private FileApp fileApp = new FileApp();
        private UserApp userApp = new UserApp();
        private RoleAuthorizeApp roleAuthorizeApp = new RoleAuthorizeApp();
        private ModuleApp moduleApp = new ModuleApp();
        private ModuleButtonApp moduleButtonApp = new ModuleButtonApp();
        private TreeApp treeApp = new TreeApp();
        private DirectoryApp directoryApp = new DirectoryApp();


        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var newsTypeList = fileApp.GetList();
            var listResult = (from a in fileApp.GetList(pagination, keyword)
                              join b in userApp.GetList() on a.F_UploadUser equals b.F_Id into team
                              from c in team.DefaultIfEmpty()
                              select new FileEntity()
                              {
                                  F_FileMax = a.F_FileMax,
                                  F_Id = a.F_Id,
                                  F_FileName = a.F_FileName,
                                  F_FileVersion = a.F_FileVersion,
                                  F_UploadDate = a.F_UploadDate,
                                  F_UploadUser = c.F_RealName
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

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Upload()
        {
            HttpPostedFileBase postedFile = Request.Files["file_data"];
            if (postedFile == null)
                return JsAlert("没有选择文件");
            UploadImg.FileModel filemodel = UploadImg.Upload(postedFile);
            FileEntity fileEntity = new FileEntity()
            {
                F_FileMax = Convert.ToDouble(filemodel.FileMax) / 1024 + "kb",
                F_FileName = filemodel.FileName,
                F_RealName = filemodel.RealName,
                F_CreatorTime = DateTime.Now,
                F_CreatorUserId = OperatorProvider.Provider.GetCurrent().UserId,
                F_UploadDate = DateTime.Now,
                F_UploadUser = OperatorProvider.Provider.GetCurrent().UserId
            };
            fileApp.SubmitForm(fileEntity, "");
            return Success("操作成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult AddDirectory(DirectoryEntity directoryEntity, string keyValue)
        {
            directoryApp.SubmitForm(directoryEntity, keyValue);
            return Success("操作成功。");
        }



        //[HttpPost]
        //[HandlerAjaxOnly]
        //[ValidateAntiForgeryToken]
        //[ValidateInput(false)]
        //public ActionResult SubmitForm(string F_FileVersion)
        //{

        //}

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetSelectJson()
        {
            var data = directoryApp.GetList();
            var treeList = new List<TreeSelectModel>();
            foreach (DirectoryEntity item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.F_Id;
                treeModel.text = item.F_FullName;
                treeModel.parentId = item.F_ParentId.Trim(new char[] { ' ' });
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeSelectJson());
        }

        [HttpGet]
        [HandlerAuthorize]
        public ActionResult Directory()
        {
            return View();
        }

        public ActionResult GetPermissionTree(string roleId)
        {
            var directorydata = directoryApp.GetList();
            var treeList = new List<TreeViewModel>();
            foreach (DirectoryEntity item in directorydata)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = directorydata.Count(t => t.F_ParentId == item.F_Id) == 0 ? false : true;
                tree.id = item.F_Id;
                tree.text = item.F_FullName;
                tree.value = item.F_EnCode;
                tree.parentId = item.F_ParentId.Trim(new char[] { ' ' });
                tree.isexpand = true;
                tree.complete = true;
                tree.showcheck = true;
                tree.hasChildren = hasChildren;
                tree.img = item.F_Icon == "" ? "" : item.F_Icon;
                treeList.Add(tree);
            }
            return Content(treeList.TreeViewJson());
        }
    }
}