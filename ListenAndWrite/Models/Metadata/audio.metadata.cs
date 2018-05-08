using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thư viện thiết kế class metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ListenAndWrite.Models
{
    [MetadataTypeAttribute(typeof(AudioMetadata))]

    public partial class audio
    {
        internal sealed class AudioMetadata
        {
            [Display(Name = "Mã Audio")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public int idAudio { get; set; }
            [Display(Name = "Tên Audio")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public string name { get; set; }
            [Display(Name = "File audio")]//Thuộc tính Display dùng để đặt tên lại cho cột

            public string url { get; set; }
            [Display(Name = "Text")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public string text { get; set; }
            [Display(Name = "Chủ đề")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public int idChuDe { get; set; }
        }
    }
}