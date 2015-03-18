using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

using BLL.Model;
using BLL.Services;
using DAL.Repositories;
using DAL.Entities;

namespace ContactList.Controllers
{
    public class EntryTypeController : ApiController
    {
        private IService<BLL.Model.EntryType, DAL.Entities.EntryType> _service;

        public EntryTypeController() : this(DependencyResolver.Current.GetService<IService<BLL.Model.EntryType, DAL.Entities.EntryType>>())
        {

        }
        public EntryTypeController(IService<BLL.Model.EntryType, DAL.Entities.EntryType> service)
        {
            _service = service;
        }

        public IList<BLL.Model.EntryType> GetAll()
        {
            return _service.GetAll();
        }
    }
}
