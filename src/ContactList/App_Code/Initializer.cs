using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using System.IO;

using Ninject;
using SpecExpress;

using BLL.Services;
using DAL.Repositories;

namespace ContactList
{
    /// <summary>
    /// Static class that handles initialization logic. 
    /// Usualy called from global.asax.
    /// </summary>
    public static class Initializer
    {
        /// <summary>
        /// Configures AutoMapper
        /// </summary>
        public static void ConfigureMappings()
        {
            BLL.AutoMapperConfig.ConfigureMappings();
        }

        /// <summary>
        /// Configures bindings for Ninject resolver
        /// </summary>
        public static void ConfigureNinjectResolver()
        {
            var kernel = new StandardKernel();

            kernel.Bind<IService<BLL.Model.Contact, DAL.Entities.Contact>>().To<ContactService>();
            kernel.Bind<IService<BLL.Model.Email, DAL.Entities.Email>>().To<EmailService>();
            kernel.Bind<IService<BLL.Model.EntryType, DAL.Entities.EntryType>>().To<EntryTypeService>();
            kernel.Bind<IService<BLL.Model.Phone, DAL.Entities.Phone>>().To<PhoneService>();
            kernel.Bind<IService<BLL.Model.Tag, DAL.Entities.Tag>>().To<TagService>();

            kernel.Bind<IRepository<DAL.Entities.Contact>>().To<ContactRepository>();
            kernel.Bind<IRepository<DAL.Entities.Email>>().To<EmailRepository>();
            kernel.Bind<IRepository<DAL.Entities.EntryType>>().To<EntryTypeRepository>();
            kernel.Bind<IRepository<DAL.Entities.Phone>>().To<PhoneRepository>();
            kernel.Bind<IRepository<DAL.Entities.Tag>>().To<TagRepository>();

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }

        /// <summary>
        /// Configures SpecExpress validation catalog
        /// </summary>
        public static void ConfigureValidationCatalog()
        {
            string path = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\BLL.dll").LocalPath;
            Assembly assembly = Assembly.LoadFrom(path);
            ValidationCatalog.Scan(x => x.AddAssembly(assembly));
        }
    }
}