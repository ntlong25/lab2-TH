using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab2_ThucHanh.Models
{
    public class Book
    {
        private int id;
        private string title;
        private string author;
        private string img_path;
        public Book() { }

        public Book(int id, string title, string author, string img_path)
        {
            this.Id = id;
            this.Title = title;
            this.Author = author;
            this.Img_path = img_path;
        }
        
        public int Id { get ; set ; }
        [Required(ErrorMessage = "Tieu de ko dc trong")]
        [StringLength(250, ErrorMessage ="Tieu de sach ko dc vuot qua 250 ky tu")]
        [Display(Name ="Tieu de ")]
        public string Title { get; set; }
        public string Author { get; set; }
        public string Img_path { get; set; }
    }
}