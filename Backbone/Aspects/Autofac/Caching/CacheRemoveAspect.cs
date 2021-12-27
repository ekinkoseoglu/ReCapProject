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
    public class CacheRemoveAspect:MethodInterception
    {
        private ICacheManager _cacheManager;
        private string _pattern;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
