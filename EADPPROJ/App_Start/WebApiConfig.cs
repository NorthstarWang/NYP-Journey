using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“WebApiConfig”的 XML 注释
    public static class WebApiConfig
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“WebApiConfig”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“WebApiConfig.Register(HttpConfiguration)”的 XML 注释
        public static void Register(HttpConfiguration config)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“WebApiConfig.Register(HttpConfiguration)”的 XML 注释
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
