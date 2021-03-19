using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MyInfo”的 XML 注释
    public class MyInfo : ApiController
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MyInfo”的 XML 注释
    {
        // GET api/<controller>
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MyInfo.Get()”的 XML 注释
        public IEnumerable<string> Get()
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MyInfo.Get()”的 XML 注释
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MyInfo.Get(int)”的 XML 注释
        public string Get(int id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MyInfo.Get(int)”的 XML 注释
        {
            return "value";
        }

        // POST api/<controller>
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MyInfo.Post(string)”的 XML 注释
        public void Post([FromBody]string value)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MyInfo.Post(string)”的 XML 注释
        {
        }

        // PUT api/<controller>/5
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MyInfo.Put(int, string)”的 XML 注释
        public void Put(int id, [FromBody]string value)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MyInfo.Put(int, string)”的 XML 注释
        {
        }

        // DELETE api/<controller>/5
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“MyInfo.Delete(int)”的 XML 注释
        public void Delete(int id)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“MyInfo.Delete(int)”的 XML 注释
        {
        }
    }
}