using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Tiantianquan.Common
{
    public class TransactionScopeInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var methodInfo=invocation.Method;
            if (methodInfo == null)
            {
                methodInfo = invocation.MethodInvocationTarget;
            }
            if (!methodInfo.IsDefined(typeof(TransactionAttribute),false)){
                invocation.Proceed();
                return;
            }

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                invocation.Proceed();
                scope.Complete();
            }
        }
    }
}
