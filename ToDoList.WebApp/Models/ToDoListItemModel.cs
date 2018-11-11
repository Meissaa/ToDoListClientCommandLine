using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ToDoList.Common.Entities;

namespace ToDoList.WebApp.Models
{
    public class ToDoListItemModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name list is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual IList<ToDoListTask> Tasks { get; set; }
    }
}