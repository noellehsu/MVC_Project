using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHtmlHelpers.Helpers
{
    public static class Utility
    {
        public static List<SelectListItem> getCityList()
        {
            List<SelectListItem> CityList = new List<SelectListItem>
            {
                //new SelectListItem { Text = "選擇縣市", Value = "0", Selected = false },
                new SelectListItem { Text = "基隆市", Value = "1", Selected = true },
                new SelectListItem { Text = "台北市", Value = "2", Selected = false },
                new SelectListItem { Text = "新北市", Value = "3", Selected = false },
                new SelectListItem { Text = "桃園市", Value = "4", Selected = false },
                new SelectListItem { Text = "新竹市", Value = "5", Selected = false },
                new SelectListItem { Text = "新竹縣", Value = "6", Selected = false },
                new SelectListItem { Text = "苗粟縣", Value = "7", Selected = false },
                new SelectListItem { Text = "台中市", Value = "8", Selected = false },
                new SelectListItem { Text = "南投縣", Value = "9", Selected = false },
                new SelectListItem { Text = "彰化縣", Value = "10", Selected = false },
                new SelectListItem { Text = "雲林縣", Value = "11", Selected = false },
                new SelectListItem { Text = "嘉義市", Value = "12", Selected = false },
                new SelectListItem { Text = "嘉義縣", Value = "13", Selected = false },
                new SelectListItem { Text = "台南市", Value = "14", Selected = false },
                new SelectListItem { Text = "高雄市", Value = "15", Selected = false },
                new SelectListItem { Text = "屏東縣", Value = "16", Selected = false },
                new SelectListItem { Text = "台東縣", Value = "17", Selected = false },
                new SelectListItem { Text = "花蓮縣", Value = "18", Selected = false },
                new SelectListItem { Text = "宜蘭縣", Value = "19", Selected = false },
                new SelectListItem { Text = "澎湖縣", Value = "20", Selected = false },
                new SelectListItem { Text = "金門縣", Value = "21", Selected = false },
                new SelectListItem { Text = "連江縣", Value = "22", Selected = false },
            };

            return CityList;
        }

        public static List<SelectListItem> getGenderList()
        {
            List<SelectListItem> GenderList = new List<SelectListItem>
            {
                new SelectListItem { Text = "女性", Value = "0" },
                new SelectListItem { Text = "男性", Value = "1" },
                new SelectListItem { Text = "其他", Value = "2" }
            };

            return GenderList;
        }
        public static List<SelectListItem> getCommutermode()
        {
            List<SelectListItem> CommutermodeList = new List<SelectListItem>
            {
                new SelectListItem{ Text="腳踏車", Value="1", Selected = false},
                new SelectListItem{ Text="機車", Value="2", Selected = true},
                new SelectListItem{ Text="汽車", Value="3", Selected = false},
                new SelectListItem{ Text="捷運", Value="4", Selected = true},
                new SelectListItem{ Text="巴士", Value="5", Selected = false},
                new SelectListItem{ Text="高鐡", Value="6", Selected = false},
                new SelectListItem{ Text="飛機", Value="7", Selected = false},
            };

            return CommutermodeList;

        }

        public static MultiSelectList getCommutermodeM()
        {
            List<SelectListItem> CommutermodeList = new List<SelectListItem>
            {
                new SelectListItem{ Text="腳踏車", Value="1"},
                new SelectListItem{ Text="機車", Value="2"},
                new SelectListItem{ Text="汽車", Value="3"},
                new SelectListItem{ Text="捷運", Value="4"},
                new SelectListItem{ Text="巴士", Value="5"},
                new SelectListItem{ Text="高鐡", Value="6"},
                new SelectListItem{ Text="飛機", Value="7"},
            };

            MultiSelectList mList = new MultiSelectList(CommutermodeList, "Value", "Text", new int[] { 2, 4 });

            return mList;

        }
    }
}