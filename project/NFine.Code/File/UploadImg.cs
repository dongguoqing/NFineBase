using ImageWriter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NFine.Code
{
    public static class UploadImg
    {
        public static FileModel Upload(HttpPostedFileBase postedFile)
        {
            //上传和返回(保存到数据库中)的路径
            string uppath = string.Empty;
            string savepath = string.Empty;
            HttpContext context = HttpContext.Current;
            //创建图片新的名称
            string nameImg = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string strPath = postedFile.FileName;
            string type = strPath.Substring(strPath.LastIndexOf(".") + 1).ToLower();
            if (ValidateImg(postedFile))
            {
                //拼写上传图片的路径
                savepath = context.Server.MapPath(Configs.GetValue("FileSrc") + type + "/");
                savepath += nameImg + "." + type;
                uppath = context.Server.MapPath(Configs.GetValue("FileSrc")) + type;
                FileHelper.CreateDirectory(uppath);
                FileHelper.CreateDirectory(uppath + "/水印");//水印图片地址
                FileHelper.CreateDirectory(uppath + "/文字");//文字图片地址
                //uppath += nameImg + "." + type;
                //上传图片
                postedFile.SaveAs(savepath);
                ImageManager writer = new ImageManager();
                    
                //调用很简单 im.SaveWatermark(原图地址, 水印地址, 透明度, 水印位置, 边距,保存到的位置); 
                writer.SaveWatermark(savepath, context.Server.MapPath(Configs.GetValue("FileSrc")) + "Logo.png", 0.9f, ImageManager.WatermarkPosition.RigthBottom, 10, uppath + "/水印/" + nameImg + "." + type);
                writer.AddTextToImg(savepath, "蓝色星球", uppath + "/文字/" + nameImg + "." + type);
            }
            return new FileModel()
            {
                RealName = nameImg + "." + type,
                FileName = strPath,
                FileMax = postedFile.ContentLength.ToString()
            };
        }

        public static bool ValidateImg(HttpPostedFileBase postedFile)
        {
            //获取文件后缀名

            string[] imgType = new string[] { "gif", "jpg", "png", "bmp" };

            int i = 0;
            bool blean = false;
            string message = string.Empty;

            string imgName = Path.GetExtension(postedFile.FileName);
            //using (FileStream fs = new FileStream(postedFile.FileName, FileMode.Open, FileAccess.Read))
            //{
            //    byte[] buffer = new byte[fs.Length];
            //    fs.Read(buffer, 0, (int)fs.Length);

            //    string fileClass = string.Empty;
            //    fileClass = buffer[0].ToString() + buffer[1].ToString();

            //    //jpg gif bmp png rar 
            //    string[] fileType = { "255216", "7173", "6677", "13780", "8297", "5549", "870", "87111", "8075" };
            //    for (int j = 0; j < fileType.Length; j++)
            //    {
            //        if (fileClass == fileType[j])
            //        {
            //            blean = true;
            //        }
            //    }
            //}

            //判断是否为Image类型文件
            while (i < imgType.Length)
            {
                if (imgName.Equals(imgType[i].ToString()))
                {
                    blean = true;
                    break;
                }
                else if (i == (imgType.Length - 1))
                {
                    break;
                }
                else
                {
                    i++;
                }
            }
            return blean;
        }

        public class FileModel
        {
            public string FileName { get; set; }
            public string FileMax { get; set; }
            public string RealName { get; set; }
        }
    }
}
