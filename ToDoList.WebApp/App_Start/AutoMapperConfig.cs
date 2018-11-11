using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Common.Entities;
using ToDoList.WebApp.Models;

namespace ToDoList.WebApp.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ToDoListItemModel, ToDoListItem>();
                cfg.CreateMap<ToDoListItem, ToDoListItemModel>();
                cfg.CreateMap<ToDoListTaskModel, ToDoListTask>();
                cfg.CreateMap<ToDoListTask, ToDoListTaskModel>();

            });
        }
    }
}