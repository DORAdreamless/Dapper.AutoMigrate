using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiantianquan.Common.Application;
using Tiantianquan.Common.Enums;
using Tiantianquan.Common.UI;
using Tiantianquan.Privilege.Domain;

namespace Tiantianquan.Privilege.Application
{
     /// <summary>
    /// SYS_NavigationMenu
    /// </summary>
    public class NavigationMenuService:BaseService
    {
        protected  INavigationMenuRepository  NavigationMenuRepository { get; }

        public NavigationMenuService(INavigationMenuRepository navigationMenuRepository)
        {
            this.NavigationMenuRepository = navigationMenuRepository;
        }
        
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Transaction]
        public virtual String Save(NavigationMenuDto model)
        {
            NavigationMenu navigationMenu = new NavigationMenu();
                navigationMenu.Id = model.Id;
             navigationMenu.CreatedAt = model.CreatedAt;
             navigationMenu.UpdatedAt = model.UpdatedAt;
             navigationMenu.ApplicationId = model.ApplicationId;
             navigationMenu.ParentId = model.ParentId;
             navigationMenu.Name = model.Name;
             navigationMenu.DisplayName = model.DisplayName;
             navigationMenu.Style = model.Style;
             navigationMenu.LinkAddress = model.LinkAddress;
             navigationMenu.ResourceType = model.ResourceType;
             navigationMenu.Attributes = model.Attributes;
            return this.NavigationMenuRepository.Save(navigationMenu);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        [Transaction]
        public virtual void Update(String id,NavigationMenuDto model)
        {
            NavigationMenu navigationMenu = this.NavigationMenuRepository.GetById(id);
             navigationMenu.CreatedAt = model.CreatedAt;
             navigationMenu.UpdatedAt = model.UpdatedAt;
             navigationMenu.ApplicationId = model.ApplicationId;
             navigationMenu.ParentId = model.ParentId;
             navigationMenu.Name = model.Name;
             navigationMenu.DisplayName = model.DisplayName;
             navigationMenu.Style = model.Style;
             navigationMenu.LinkAddress = model.LinkAddress;
             navigationMenu.ResourceType = model.ResourceType;
             navigationMenu.Attributes = model.Attributes;
            this.NavigationMenuRepository.Update(navigationMenu);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        [Transaction]
        public virtual void Delete(String id)
        {
            this.NavigationMenuRepository.Delete(id);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        [Transaction]
        public virtual void BatchDelete(List<String> ids)
        {
            this.NavigationMenuRepository.BatchDelete(ids);
        }
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="id"></param>
        public virtual NavigationMenuDto GetNavigationMenuById(String id)
        {
            NavigationMenu navigationMenu = this.NavigationMenuRepository.GetById(id);
            NavigationMenuDto model = new NavigationMenuDto();
            model.Id = navigationMenu.Id;
            model.CreatedAt = navigationMenu.CreatedAt;
            model.UpdatedAt = navigationMenu.UpdatedAt;
            model.ApplicationId = navigationMenu.ApplicationId;
            model.ParentId = navigationMenu.ParentId;
            model.Name = navigationMenu.Name;
            model.DisplayName = navigationMenu.DisplayName;
            model.Style = navigationMenu.Style;
            model.LinkAddress = navigationMenu.LinkAddress;
            model.ResourceType = navigationMenu.ResourceType;
            model.Attributes = navigationMenu.Attributes;
            return model;
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="categorySearchParams"></param>
        /// <returns></returns>
        public virtual PageResult<NavigationMenu> GetNavigationMenuByPage(NavigationMenuSearchParams searchParams)
        {
             var items =  this.NavigationMenuRepository.GetNavigationMenuByPage(searchParams);
             var total = this.NavigationMenuRepository.GetNavigationMenuRecordCount(searchParams);
             return new PageResult<NavigationMenu>(total,items);
        }
       

        public virtual List<CascaderNode> GetNavigationMenuByCascaderNodes()
        {
            var items = this.NavigationMenuRepository.GetAll().ToList();

            return this.ConvertToCascaderNodes(items, string.Empty);
        }

        private List<CascaderNode> ConvertToCascaderNodes(List<NavigationMenu> listNavigationMenu, string ParentId)
        {
            List<CascaderNode> listCascaderNode = new List<CascaderNode>();
            var list = new List<NavigationMenu>();
            if (string.IsNullOrWhiteSpace(ParentId))
            {
                list = listNavigationMenu.Where(item => string.IsNullOrWhiteSpace(item.ParentId)).ToList();
            }
            else
            {
                list = listNavigationMenu.Where(item => item.ParentId==ParentId.Trim()).ToList();
            }
            foreach (NavigationMenu navigationMenu in list)
            {
                CascaderNode cascaderNode = new CascaderNode();
                cascaderNode.Label = navigationMenu.Name;
                cascaderNode.Value = navigationMenu.Id;
                cascaderNode.IsLeaf=!listNavigationMenu.Any(item => item.ParentId == navigationMenu.Id);
                if (!cascaderNode.IsLeaf)
                {
                    cascaderNode.Children= ConvertToCascaderNodes(listNavigationMenu, navigationMenu.Id);
                }
                listCascaderNode.Add(cascaderNode);
            }
            return listCascaderNode;
        }
    }
}


