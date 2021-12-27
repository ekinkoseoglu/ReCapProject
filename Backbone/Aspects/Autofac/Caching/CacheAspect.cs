using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backbone.CrossCuttingConcerns.Caching;
using Backbone.Utilities.Interceptors;
using Backbone.Utilities.IoC;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace Backbone.Aspects.Autofac.Caching
{
    public class CacheAspect:MethodInterception
    {
        private ICacheManager _cacheManager;
        private int _duration;

        public CacheAspect(int duration=60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }


        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var parameters = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", parameters.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheManager.isAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key,invocation.ReturnValue,_duration);
        }
    }
}
