using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thư viện thiết kế class metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ListenAndWrite.Models
{
    [MetadataTypeAttribute(typeof(ChuDeMetadata))]
    public partial class chude
    {
        internal sealed class ChuDeMetadata
        {
            [Display(Name = "Mã Chủ đề")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public int idChuDe { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            [Display(Name = "Chủ Đề")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public string chuDe { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            [Display(Name = "Level")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public int levels { get; set; }
        }
    }
}