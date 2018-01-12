using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tiantianquan.Common.UI;
using Tiantianquan.Privilege.Domain;
using Tiantianquan.Privilege.Application;

namespace Tiantianquan.Privilege.WebApi.Controllers
{
     /// <summary>
    /// SYS_ApplicationRole
    /// </summary>
    public class ApplicationRoleController:ApiController
    {
        protected  ApplicationRoleService  ApplicationRoleService { get; }

        public ApplicationRoleController(ApplicationRoleService applicationRoleService)
        {
            this.ApplicationRoleService = applicationRoleService;
        }
        
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="searchParams"></param>
        /// <returns></returns>
        [HttpPost]
        public PageResult<ApplicationRole> GetApplicationRoleByPage([FromBody]ApplicationRoleSearchParams searchParams)
        {
            return this.ApplicationRoleService.GetApplicationRoleByPage(searchParams);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ApplicationRoleDto GetApplicationRoleById(String id)
        {
            return this.ApplicationRoleService.GetApplicationRoleById(id);
        }
        /// <summary>
        /// 新增
        /// </summary>
        [HttpPost]
        public String Post([FromBody]ApplicationRoleDto model)
        {
           return this.ApplicationRoleService.Save(model);
        }
        /// <summary>
        /// 修改
        /// </summary>
        [HttpPost]
        public void Put(String id,[FromBody]ApplicationRoleDto model)
        {
            this.ApplicationRoleService.Update(id, model);
        }
        /// <summary>
        /// 删除
        /// </summary>
        [HttpPost]
        public void Delete(String id)
        {
            this.ApplicationRoleService.Delete(id);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        [HttpPost]
        public void BatchDelete(List<String> ids)
        {
            this.ApplicationRoleService.BatchDelete(ids);
        }
       
    }
}


