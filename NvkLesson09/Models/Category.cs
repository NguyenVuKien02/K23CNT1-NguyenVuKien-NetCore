using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NvkLesson09.Models;

public partial class Category
{
    [Key]
    [Display(Name = "ID")]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Tên thể loại không được để trống")]
    [StringLength(100, ErrorMessage = "Tên thể loại tối đa 100 kí tự")]
    [Display(Name = "Tên thể loại")]
    public string? CategoryName { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
