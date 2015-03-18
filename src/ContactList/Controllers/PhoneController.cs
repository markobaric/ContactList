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
    public class PhoneController : ApiController
    {
        private IService<BLL.Model.Phone, DAL.Entities.Phone> _service;

        public PhoneController() : this(DependencyResolver.Current.GetService<IService<BLL.Model.Phone, DAL.Entities.Phone>>())
        {

        }
        public PhoneController(IService<BLL.Model.Phone, DAL.Entities.Phone> service)
        {
            _service = service;
        }

        [System.Web.Http.HttpPost]
        public long Insert(BLL.Model.Phone phone)
        {
            return _service.Insert(phone);
        }
        [System.Web.Http.HttpPost]
        public void Delete(long id)
        {
            _service.Delete(id);
        }
    }
}
