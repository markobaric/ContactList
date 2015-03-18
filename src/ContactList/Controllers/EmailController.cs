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
    public class EmailController : ApiController
    {
        private IService<BLL.Model.Email, DAL.Entities.Email> _service;

        public EmailController() : this(DependencyResolver.Current.GetService<IService<BLL.Model.Email, DAL.Entities.Email>>())
        {

        }
        public EmailController(IService<BLL.Model.Email, DAL.Entities.Email> service)
        {
            _service = service;
        }

        [System.Web.Http.HttpPost]
        public long Insert(BLL.Model.Email email)
        {
            return _service.Insert(email);
        }
        [System.Web.Http.HttpPost]
        public void Delete(long id)
        {
            _service.Delete(id);
        }
    }
}
