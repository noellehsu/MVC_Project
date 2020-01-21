using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DashboardChart.ViewModels;

namespace DashboardChart.Helpers
{
    public class Sitebar
    {
        public List<SidebarItem> GetSidebarData()
        {
            List<SidebarItem> cates = new List<SidebarItem>()
            {
                new SidebarItem { Id=1, Name="線條圖", Url="/Charts/LineTemperature", Icon="trending-up" },
                new SidebarItem { Id=2, Name="線條圖Data", Url="/Charts/LineTemperatureData", Icon="trending-down" },
                new SidebarItem { Id=3, Name="長條圖", Url="/Charts/BarTravel", Icon="align-left" },
                new SidebarItem { Id=4, Name="長條圖Data", Url="/Charts/BarTravelData", Icon="align-right" },
                new SidebarItem { Id=5, Name="雷達圖", Url="/Charts/RadarCar", Icon="aperture" },
                new SidebarItem { Id=6, Name="雷達圖Data", Url="/Charts/RadarCarData", Icon="chrome" },
                new SidebarItem { Id=7, Name="圖餅圖", Url="/Charts/PieSales", Icon="clock" },
                new SidebarItem { Id=8, Name="圖餅圖Data", Url="/Charts/PieSalesData", Icon="check-circle" },
                new SidebarItem { Id=9, Name="JSON Encode", Url="/Json/Encode", Icon="check-square" },
                new SidebarItem { Id=10, Name="Pass Clothing JSON Data", Url="/PassJson/PassClothingData", Icon="cast" },
                new SidebarItem { Id=11, Name="Pass Clothing JSON Data From DB", Url="/PassJson/PassClothingFromDB", Icon="cast" }
            };

            return cates;
        }
    }
}