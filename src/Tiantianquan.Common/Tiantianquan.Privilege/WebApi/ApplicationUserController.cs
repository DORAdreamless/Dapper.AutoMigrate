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
    /// SYS_ApplicationUser
    /// </summary>
    public class ApplicationUserController:ApiController
    {
        protected  ApplicationUserService  ApplicationUserService { get; }

        public ApplicationUserController(ApplicationUserService applicationUserService)
        {
            this.ApplicationUserService = applicationUserService;
        }
        
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="searchParams"></param>
        /// <returns></returns>
        [HttpPost]
        public PageResult<ApplicationUser> GetApplicationUserByPage([FromBody]ApplicationUserSearchParams searchParams)
        {
            return this.ApplicationUserService.GetApplicationUserByPage(searchParams);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ApplicationUserDto GetApplicationUserById(String id)
        {
            return this.ApplicationUserService.GetApplicationUserById(id);
        }
        /// <summary>
        /// 新增
        /// </summary>
        [HttpPost]
        public String Post([FromBody]ApplicationUserDto model)
        {
           return this.ApplicationUserService.Save(model);
        }
        /// <summary>
        /// 修改
        /// </summary>
        [HttpPost]
        public void Put(String id,[FromBody]ApplicationUserDto model)
        {
            this.ApplicationUserService.Update(id, model);
        }
        /// <summary>
        /// 删除
        /// </summary>
        [HttpPost]
        public void Delete(String id)
        {
            this.ApplicationUserService.Delete(id);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        [HttpPost]
        public void BatchDelete(List<String> ids)
        {
            this.ApplicationUserService.BatchDelete(ids);
        }
       
    }
}


