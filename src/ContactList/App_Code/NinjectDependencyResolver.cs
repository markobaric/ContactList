using System;
using System.Web.Http.Dependencies;
using System.Collections.Generic;

using Ninject;
using Ninject.Parameters;
using Ninject.Syntax;

using BLL.Services;
using DAL.Repositories;

namespace ContactList
{
    /// <summary>
    /// Custom IoC dependency resolver.
    /// It will dynamically resolve controller dependencies.
    /// </summary>
    public class NinjectDependencyResolver : System.Web.Mvc.IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}