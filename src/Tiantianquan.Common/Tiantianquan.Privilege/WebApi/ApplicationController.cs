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
    /// SYS_Application
    /// </summary>
    public class ApplicationController:ApiController
    {
        protected  ApplicationService  ApplicationService { get; }

        public ApplicationController(ApplicationService applicationService)
        {
            this.ApplicationService = applicationService;
        }
        
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="searchParams"></param>
        /// <returns></returns>
        [HttpPost]
        public PageResult<Tiantianquan.Privilege.Domain.Application> GetApplicationByPage([FromBody]ApplicationSearchParams searchParams)
        {
            return this.ApplicationService.GetApplicationByPage(searchParams);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ApplicationDto GetApplicationById(String id)
        {
            return this.ApplicationService.GetApplicationById(id);
        }
        /// <summary>
        /// 新增
        /// </summary>
        [HttpPost]
        public String Post([FromBody]ApplicationDto model)
        {
           return this.ApplicationService.Save(model);
        }
        /// <summary>
        /// 修改
        /// </summary>
        [HttpPost]
        public void Put(String id,[FromBody]ApplicationDto model)
        {
            this.ApplicationService.Update(id, model);
        }
        /// <summary>
        /// 删除
        /// </summary>
        [HttpPost]
        public void Delete(String id)
        {
            this.ApplicationService.Delete(id);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        [HttpPost]
        public void BatchDelete(List<String> ids)
        {
            this.ApplicationService.BatchDelete(ids);
        }
       
        /// <summary>
        /// 查询所有应用
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Tiantianquan.Privilege.Domain.Application> GetAllApplication()
        {
            return this.ApplicationService.GetAllApplication();
        }
    }
}


