using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingDB.ViewModels;

namespace ShoppingDB.Helpers
{
    public class Site
    {
        public List<SidebarItem> GetCategoriesData()
        {
            List<SidebarItem> cates = new List<SidebarItem>()
            {
                new SidebarItem { Id=1, Name="首頁", Url="/Home/Index", Icon="compass" },
                new SidebarItem { Id=2, Name="男裝", Url="/Home/Men", Icon="sun" },
                new SidebarItem { Id=3, Name="女裝", Url="/Home/Women", Icon="moon" },
                new SidebarItem { Id=4, Name="童裝", Url="/Home/Child", Icon="star" },
                new SidebarItem { Id=5, Name="鞋子", Url="/Home/Shoes", Icon="user" },            };

            return cates;
        }
    }
}