using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiantianquan.Common.Dependency;
using Tiantianquan.Common.Runtime.Session;

namespace Tiantianquan.Common.Application
{
    [Intercept(typeof(TransactionScopeInterceptor))]
    public abstract class BaseService
    {
        public virtual IAbpSession AbpSession
        {
            get
            {
                return ObjectContainer.Resolve<IAbpSession>();
            }
        }
    }
}
