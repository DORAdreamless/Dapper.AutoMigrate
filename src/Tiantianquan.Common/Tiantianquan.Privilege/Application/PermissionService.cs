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
    /// SYS_Permission
    /// </summary>
    public class PermissionService:BaseService
    {
        protected  IPermissionRepository  PermissionRepository { get; }

        public PermissionService(IPermissionRepository permissionRepository)
        {
            this.PermissionRepository = permissionRepository;
        }
        
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Transaction]
        public virtual String Save(PermissionDto model)
        {
            Permission permission = new Permission();
                permission.Id = model.Id;
             permission.CreatedAt = model.CreatedAt;
             permission.UpdatedAt = model.UpdatedAt;
             permission.ApplicationId = model.ApplicationId;
             permission.ApplicationRoleId = model.ApplicationRoleId;
             permission.ApplicationUserId = model.ApplicationUserId;
             permission.NavigationMenuId = model.NavigationMenuId;
             permission.Granted = model.Granted;
             permission.CreatedUserId = model.CreatedUserId;
            return this.PermissionRepository.Save(permission);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        [Transaction]
        public virtual void Update(String id,PermissionDto model)
        {
            Permission permission = this.PermissionRepository.GetById(id);
             permission.CreatedAt = model.CreatedAt;
             permission.UpdatedAt = model.UpdatedAt;
             permission.ApplicationId = model.ApplicationId;
             permission.ApplicationRoleId = model.ApplicationRoleId;
             permission.ApplicationUserId = model.ApplicationUserId;
             permission.NavigationMenuId = model.NavigationMenuId;
             permission.Granted = model.Granted;
             permission.CreatedUserId = model.CreatedUserId;
            this.PermissionRepository.Update(permission);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        [Transaction]
        public virtual void Delete(String id)
        {
            this.PermissionRepository.Delete(id);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        [Transaction]
        public virtual void BatchDelete(List<String> ids)
        {
            this.PermissionRepository.BatchDelete(ids);
        }
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="id"></param>
        public virtual PermissionDto GetPermissionById(String id)
        {
            Permission permission = this.PermissionRepository.GetById(id);
            PermissionDto model = new PermissionDto();
            model.Id = permission.Id;
            model.CreatedAt = permission.CreatedAt;
            model.UpdatedAt = permission.UpdatedAt;
            model.ApplicationId = permission.ApplicationId;
            model.ApplicationRoleId = permission.ApplicationRoleId;
            model.ApplicationUserId = permission.ApplicationUserId;
            model.NavigationMenuId = permission.NavigationMenuId;
            model.Granted = permission.Granted;
            model.CreatedUserId = permission.CreatedUserId;
            return model;
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="categorySearchParams"></param>
        /// <returns></returns>
        public virtual PageResult<Permission> GetPermissionByPage(PermissionSearchParams searchParams)
        {
             var items =  this.PermissionRepository.GetPermissionByPage(searchParams);
             var total = this.PermissionRepository.GetPermissionRecordCount(searchParams);
             return new PageResult<Permission>(total,items);
        }
       
    }
}


