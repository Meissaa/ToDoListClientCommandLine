using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ToDoList.Common.Entities;

namespace ToDoList.WebApp.Models
{
    public class ToDoListTaskModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Text task is required")]
        public string Text { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? CompleteDate { get; set; }
        public virtual ToDoListItem ToDoListItem { get; set; }
    }
}