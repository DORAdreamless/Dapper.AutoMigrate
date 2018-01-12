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
    /// SYS_ApplicationUser
    /// </summary>
    public class ApplicationUserService:BaseService
    {
        protected  IApplicationUserRepository  ApplicationUserRepository { get; }

        public ApplicationUserService(IApplicationUserRepository applicationUserRepository)
        {
            this.ApplicationUserRepository = applicationUserRepository;
        }
        
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Transaction]
        public virtual String Save(ApplicationUserDto model)
        {
            ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.Id = model.Id;
             applicationUser.CreatedAt = model.CreatedAt;
             applicationUser.UpdatedAt = model.UpdatedAt;
             applicationUser.UserName = model.UserName;
             applicationUser.PasswordHash = model.PasswordHash;
             applicationUser.PasswordSalt = model.PasswordSalt;
             applicationUser.NickName = model.NickName;
             applicationUser.FirstName = model.FirstName;
             applicationUser.LastName = model.LastName;
             applicationUser.Sex = model.Sex;
             applicationUser.Birthday = model.Birthday;
             applicationUser.Age = model.Age;
             applicationUser.Phone = model.Phone;
             applicationUser.Email = model.Email;
             applicationUser.HeadImageUrl = model.HeadImageUrl;
             applicationUser.LastLoginTime = model.LastLoginTime;
             applicationUser.LastLoginIP = model.LastLoginIP;
             applicationUser.Locked = model.Locked;
             applicationUser.LockedTime = model.LockedTime;
             applicationUser.Logined = model.Logined;
            return this.ApplicationUserRepository.Save(applicationUser);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        [Transaction]
        public virtual void Update(String id,ApplicationUserDto model)
        {
            ApplicationUser applicationUser = this.ApplicationUserRepository.GetById(id);
             applicationUser.CreatedAt = model.CreatedAt;
             applicationUser.UpdatedAt = model.UpdatedAt;
             applicationUser.UserName = model.UserName;
             applicationUser.PasswordHash = model.PasswordHash;
             applicationUser.PasswordSalt = model.PasswordSalt;
             applicationUser.NickName = model.NickName;
             applicationUser.FirstName = model.FirstName;
             applicationUser.LastName = model.LastName;
             applicationUser.Sex = model.Sex;
             applicationUser.Birthday = model.Birthday;
             applicationUser.Age = model.Age;
             applicationUser.Phone = model.Phone;
             applicationUser.Email = model.Email;
             applicationUser.HeadImageUrl = model.HeadImageUrl;
             applicationUser.LastLoginTime = model.LastLoginTime;
             applicationUser.LastLoginIP = model.LastLoginIP;
             applicationUser.Locked = model.Locked;
             applicationUser.LockedTime = model.LockedTime;
             applicationUser.Logined = model.Logined;
            this.ApplicationUserRepository.Update(applicationUser);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        [Transaction]
        public virtual void Delete(String id)
        {
            this.ApplicationUserRepository.Delete(id);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        [Transaction]
        public virtual void BatchDelete(List<String> ids)
        {
            this.ApplicationUserRepository.BatchDelete(ids);
        }
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="id"></param>
        public virtual ApplicationUserDto GetApplicationUserById(String id)
        {
            ApplicationUser applicationUser = this.ApplicationUserRepository.GetById(id);
            ApplicationUserDto model = new ApplicationUserDto();
            model.Id = applicationUser.Id;
            model.CreatedAt = applicationUser.CreatedAt;
            model.UpdatedAt = applicationUser.UpdatedAt;
            model.UserName = applicationUser.UserName;
            model.PasswordHash = applicationUser.PasswordHash;
            model.PasswordSalt = applicationUser.PasswordSalt;
            model.NickName = applicationUser.NickName;
            model.FirstName = applicationUser.FirstName;
            model.LastName = applicationUser.LastName;
            model.Sex = applicationUser.Sex;
            model.Birthday = applicationUser.Birthday;
            model.Age = applicationUser.Age;
            model.Phone = applicationUser.Phone;
            model.Email = applicationUser.Email;
            model.HeadImageUrl = applicationUser.HeadImageUrl;
            model.LastLoginTime = applicationUser.LastLoginTime;
            model.LastLoginIP = applicationUser.LastLoginIP;
            model.Locked = applicationUser.Locked;
            model.LockedTime = applicationUser.LockedTime;
            model.Logined = applicationUser.Logined;
            return model;
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="categorySearchParams"></param>
        /// <returns></returns>
        public virtual PageResult<ApplicationUser> GetApplicationUserByPage(ApplicationUserSearchParams searchParams)
        {
             var items =  this.ApplicationUserRepository.GetApplicationUserByPage(searchParams);
             var total = this.ApplicationUserRepository.GetApplicationUserRecordCount(searchParams);
             return new PageResult<ApplicationUser>(total,items);
        }
       
    }
}


