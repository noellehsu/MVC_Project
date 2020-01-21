using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcRouting
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //路由會忽略掉WebResource.axd或ScriptResource.axd之類的請求，
            //不會將這類請求傳給Controller處理
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //1.Car
            routes.MapRoute(
                name: "Car",
                url: "Car",
                defaults: new { controller = "Automobile", action = "Index" }
            );

            //2.Brand/{brand}
            routes.MapRoute(
                name: "FindCarByBrand",
                url: "Brand/{brand}",
                defaults: new
                {
                    controller = "Automobile",
                    action = "FindBrand",
                    brand = UrlParameter.Optional
                } //brand參數為選擇性提供
                );

            //3.Car/{cat}
            routes.MapRoute(
                name: "CarCategory",
                url: "Car/Category/{cat}",
                defaults: new { controller = "Automobile", action = "FindCategory", cat = "轎車" }
                //category參數預設為"轎車"
                );

            //4.Car/Id/{id}
            routes.MapRoute(
                name: "FindCarById",
                url: "Car/Id/{Id}",
                defaults: new { controller = "Automobile", action = "FindId", id = UrlParameter.Optional }
            );

            //5.Car/Year/{year}
            routes.MapRoute(
                name: "FindCarByYear",
                url: "Car/Year/{year}",
                defaults: new { controller = "Automobile", action = "FindYear", year = 2017 }, //預設顯示2017年
                constraints: new { year = @"\d{4}" } // 限制{year}是四位數
            );

            //6.Car/Brand-Year/{brand}-{year}
            //-分隔符號可換成= ~ @ | _符號，但不接受+ : & *符號
            //兩個參數中間必須加上⼀個分隔符號
            routes.MapRoute(
                name: "FindCarByBrandYear",
                url: "Car/Brand-Year/{brand}-{year}",
                defaults: new { controller = "Automobile", action = "FindBrandYear" },
                constraints: new { brand = @"\w+", year = @"\d{4}" }  // 限制{brand}至少要打上一個字母
            );

            //路由6可替換如下
            routes.MapRoute(
                name: "FindCarByBrandYear2",
                url: "Car/BrandYear/{brand}={year}",
                defaults: new { controller = "Automobile", action = "FindBrandYear" },
                constraints: new { brand = @"\w+", year = @"\d{4}" }
            );

            //7.Car/TopSales/{topnumber} 
            routes.MapRoute(
                name: "CarTopSales",
                url: "Car/TopSales/{topnumber}",
                defaults: new { controller = "Automobile", action = "TopSales", topnumber = 5 },
                constraints: new { topnumber = @"[1-9]+[0-9]*" }
                //regular expression 正規表達式
            );


            routes.MapRoute(
                name: "GetRouteData",
                url: "Car/Route/{RouteParam}",
                defaults: new { controller = "Automobile", action = "GetRouteData", RouteParam = UrlParameter.Optional }
            );

            //系統內建的一筆路由定義，其名稱為Default，名稱必須是唯一,否則會產生衝突
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

/*
            routes.MapRoute(
                //1.路由名稱(名稱必須是唯一)
                name: "Default",
                //2.url是指URL pattern,裡面兩個斜線區隔出三個Segments,
                //而每個Segment中{}大括所包含的稱為Placeholder,Placeholder即為URL參數
                url: "{controller}/{action}/{id}",
                //3.defaults是指定Placeholder的預設值,例如{controller}中controller預設值為Home
                //id = UrlParameter.Optional表示這個參數是選擇性的,URL中可能有提供,也可能沒有
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                //4.替路由參數加上限制條件,例如限制id參數只能是數字,不能是英文或其他符號
                constraints: new { id = @"\d+",  brand = @"[A-Za-z0-9]+}}
            );
 * */
