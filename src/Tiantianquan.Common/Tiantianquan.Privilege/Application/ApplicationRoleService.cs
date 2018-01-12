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
    /// SYS_ApplicationRole
    /// </summary>
    public class ApplicationRoleService:BaseService
    {
        protected  IApplicationRoleRepository  ApplicationRoleRepository { get; }

        public ApplicationRoleService(IApplicationRoleRepository applicationRoleRepository)
        {
            this.ApplicationRoleRepository = applicationRoleRepository;
        }
        
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Transaction]
        public virtual String Save(ApplicationRoleDto model)
        {
            ApplicationRole applicationRole = new ApplicationRole();
                applicationRole.Id = model.Id;
             applicationRole.CreatedAt = model.CreatedAt;
             applicationRole.UpdatedAt = model.UpdatedAt;
             applicationRole.Name = model.Name;
             applicationRole.Description = model.Description;
            return this.ApplicationRoleRepository.Save(applicationRole);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        [Transaction]
        public virtual void Update(String id,ApplicationRoleDto model)
        {
            ApplicationRole applicationRole = this.ApplicationRoleRepository.GetById(id);
             applicationRole.CreatedAt = model.CreatedAt;
             applicationRole.UpdatedAt = model.UpdatedAt;
             applicationRole.Name = model.Name;
             applicationRole.Description = model.Description;
            this.ApplicationRoleRepository.Update(applicationRole);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        [Transaction]
        public virtual void Delete(String id)
        {
            this.ApplicationRoleRepository.Delete(id);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        [Transaction]
        public virtual void BatchDelete(List<String> ids)
        {
            this.ApplicationRoleRepository.BatchDelete(ids);
        }
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="id"></param>
        public virtual ApplicationRoleDto GetApplicationRoleById(String id)
        {
            ApplicationRole applicationRole = this.ApplicationRoleRepository.GetById(id);
            ApplicationRoleDto model = new ApplicationRoleDto();
            model.Id = applicationRole.Id;
            model.CreatedAt = applicationRole.CreatedAt;
            model.UpdatedAt = applicationRole.UpdatedAt;
            model.Name = applicationRole.Name;
            model.Description = applicationRole.Description;
            return model;
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="categorySearchParams"></param>
        /// <returns></returns>
        public virtual PageResult<ApplicationRole> GetApplicationRoleByPage(ApplicationRoleSearchParams searchParams)
        {
             var items =  this.ApplicationRoleRepository.GetApplicationRoleByPage(searchParams);
             var total = this.ApplicationRoleRepository.GetApplicationRoleRecordCount(searchParams);
             return new PageResult<ApplicationRole>(total,items);
        }
       
    }
}


