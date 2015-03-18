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
    public class TagController : ApiController
    {
        private IService<BLL.Model.Tag, DAL.Entities.Tag> _service;

        public TagController() : this(DependencyResolver.Current.GetService<IService<BLL.Model.Tag, DAL.Entities.Tag>>())
        {

        }
        public TagController(IService<BLL.Model.Tag, DAL.Entities.Tag> service)
        {
            _service = service;
        }

        [System.Web.Http.HttpPost]
        public long Insert(BLL.Model.Tag tag)
        {
            return _service.Insert(tag);
        }
        [System.Web.Http.HttpPost]
        public void Delete(long id)
        {
            _service.Delete(id);
        }
    }
}
