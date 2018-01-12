using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tiantianquan.Common.UI;
using Tiantianquan.Privilege.Domain;
using Tiantianquan.Privilege.Application;

namespace Tiantianquan.PrivilegeWebApi.Controllers
{
     /// <summary>
    /// SYS_Permission
    /// </summary>
    public class PermissionController:ApiController
    {
        protected  PermissionService  PermissionService { get; }

        public PermissionController(PermissionService permissionService)
        {
            this.PermissionService = permissionService;
        }
        
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="searchParams"></param>
        /// <returns></returns>
        [HttpPost]
        public PageResult<Permission> GetPermissionByPage([FromBody]PermissionSearchParams searchParams)
        {
            return this.PermissionService.GetPermissionByPage(searchParams);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public PermissionDto GetPermissionById(String id)
        {
            return this.PermissionService.GetPermissionById(id);
        }
        /// <summary>
        /// 新增
        /// </summary>
        [HttpPost]
        public String Post([FromBody]PermissionDto model)
        {
           return this.PermissionService.Save(model);
        }
        /// <summary>
        /// 修改
        /// </summary>
        [HttpPost]
        public void Put(String id,[FromBody]PermissionDto model)
        {
            this.PermissionService.Update(id, model);
        }
        /// <summary>
        /// 删除
        /// </summary>
        [HttpPost]
        public void Delete(String id)
        {
            this.PermissionService.Delete(id);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        [HttpPost]
        public void BatchDelete(List<String> ids)
        {
            this.PermissionService.BatchDelete(ids);
        }
       
    }
}


