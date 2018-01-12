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
    /// SYS_NavigationMenu
    /// </summary>
    public class NavigationMenuController:ApiController
    {
        protected  NavigationMenuService  NavigationMenuService { get; }

        public NavigationMenuController(NavigationMenuService navigationMenuService)
        {
            this.NavigationMenuService = navigationMenuService;
        }
        
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="searchParams"></param>
        /// <returns></returns>
        [HttpPost]
        public PageResult<NavigationMenu> GetNavigationMenuByPage([FromBody]NavigationMenuSearchParams searchParams)
        {
            return this.NavigationMenuService.GetNavigationMenuByPage(searchParams);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public NavigationMenuDto GetNavigationMenuById(String id)
        {
            return this.NavigationMenuService.GetNavigationMenuById(id);
        }
        /// <summary>
        /// 新增
        /// </summary>
        [HttpPost]
        public String Post([FromBody]NavigationMenuDto model)
        {
           return this.NavigationMenuService.Save(model);
        }
        /// <summary>
        /// 修改
        /// </summary>
        [HttpPost]
        public void Put(String id,[FromBody]NavigationMenuDto model)
        {
            this.NavigationMenuService.Update(id, model);
        }
        /// <summary>
        /// 删除
        /// </summary>
        [HttpPost]
        public void Delete(String id)
        {
            this.NavigationMenuService.Delete(id);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        [HttpPost]
        public void BatchDelete(List<String> ids)
        {
            this.NavigationMenuService.BatchDelete(ids);
        }
        /// <summary>
        /// 获取级联选择的菜单数据
        /// </summary>
        /// <returns></returns>
       [HttpGet]
        public List<CascaderNode> GetNavigationMenuByCascaderNodes()
        {
            return this.NavigationMenuService.GetNavigationMenuByCascaderNodes();
        }
    }
}


