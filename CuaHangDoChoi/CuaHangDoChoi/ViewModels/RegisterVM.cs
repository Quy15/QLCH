using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CuaHangDoChoi.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Không được trống")]
        public string hoKH { get; set; }
        [Required(ErrorMessage = "Không được trống")]
        public string tenKH { get; set; }
        [Required(ErrorMessage = "Không được trống")]
        public string diaChi { get; set; }
        [Required(ErrorMessage = "Không được trống")]
        public string SĐT { get; set; }
        [Required(ErrorMessage = "Không được trống")]
        public string taiKhoan { get; set; }
        [Required(ErrorMessage = "Không được trống")]
        public string matKhau { get; set; }
        [Required(ErrorMessage = "Không được trống")]
        [Compare("matKhau", ErrorMessage ="Không giống với mật khẩu")]
        public string xacNhanMK { get; set; }
        public string avatar { get; set; }
    }
}