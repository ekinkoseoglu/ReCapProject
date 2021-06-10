using Backbone.CrossCuttingConcerns.Validation;
using Backbone.Utilities.Interceptors;
using Castle.DynamicProxy;
using FluentValidation;
using System;
using System.Linq;

namespace Backbone.Aspects.Autofac.Validation

{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değildir");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); // ProductValidator'un instancesini oluştur
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // Validator'un Base'inin Generic Type'ini bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); // Methodun parametrelerine bak ve validator'un base type ' i ile eşleştir
            foreach (var entity in entities) // Birden fazla vardır belki
            {
                ValidationTool.Validate(validator, entity); // Bu parametre ile validator'u validate et
            }
        }
    }
}
