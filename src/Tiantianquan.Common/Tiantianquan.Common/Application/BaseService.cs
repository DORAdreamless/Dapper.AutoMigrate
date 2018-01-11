using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiantianquan.Common.Application
{
    [Intercept(typeof(TransactionScopeInterceptor))]
    public abstract class BaseService
    {

    }
}
