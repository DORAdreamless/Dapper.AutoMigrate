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
    /// SYS_Application
    /// </summary>
    public class ApplicationService:BaseService
    {
        protected  IApplicationRepository  ApplicationRepository { get; }

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            this.ApplicationRepository = applicationRepository;
        }
        
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Transaction]
        public virtual String Save(ApplicationDto model)
        {
            Tiantianquan.Privilege.Domain.Application application = new Tiantianquan.Privilege.Domain.Application();
                application.Id = model.Id;
             application.CreatedAt = model.CreatedAt;
             application.UpdatedAt = model.UpdatedAt;
             application.Name = model.Name;
             application.Description = model.Description;
            return this.ApplicationRepository.Save(application);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        [Transaction]
        public virtual void Update(String id,ApplicationDto model)
        {
            Tiantianquan.Privilege.Domain.Application application = this.ApplicationRepository.GetById(id);
             application.CreatedAt = model.CreatedAt;
             application.UpdatedAt = model.UpdatedAt;
             application.Name = model.Name;
             application.Description = model.Description;
            this.ApplicationRepository.Update(application);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        [Transaction]
        public virtual void Delete(String id)
        {
            this.ApplicationRepository.Delete(id);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        [Transaction]
        public virtual void BatchDelete(List<String> ids)
        {
            this.ApplicationRepository.BatchDelete(ids);
        }

        public List<Domain.Application> GetAllApplication()
        {
            return this.ApplicationRepository.GetAll().ToList();
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="id"></param>
        public virtual ApplicationDto GetApplicationById(String id)
        {
            Tiantianquan.Privilege.Domain.Application application = this.ApplicationRepository.GetById(id);
            ApplicationDto model = new ApplicationDto();
            model.Id = application.Id;
            model.CreatedAt = application.CreatedAt;
            model.UpdatedAt = application.UpdatedAt;
            model.Name = application.Name;
            model.Description = application.Description;
            return model;
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="categorySearchParams"></param>
        /// <returns></returns>
        public virtual PageResult<Tiantianquan.Privilege.Domain.Application> GetApplicationByPage(ApplicationSearchParams searchParams)
        {
             var items =  this.ApplicationRepository.GetApplicationByPage(searchParams);
             var total = this.ApplicationRepository.GetApplicationRecordCount(searchParams);
             return new PageResult<Tiantianquan.Privilege.Domain.Application>(total,items);
        }
       
    }
}


