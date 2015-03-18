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
    public class ContactController : ApiController
    {
        private IService<BLL.Model.Contact, DAL.Entities.Contact> _service;

        public ContactController() : this(DependencyResolver.Current.GetService<IService<BLL.Model.Contact, DAL.Entities.Contact>>())
        {

        }
        public ContactController(IService<BLL.Model.Contact, DAL.Entities.Contact> service)
        {
            _service = service;
        }

        [System.Web.Http.HttpPost]
        public IList<BLL.Model.Contact> GetAll([FromBody]GetContactsRequest request)
        {
            return _service.GetAllWithFilteringSortingAndPaging(request.Search, request.Sort, request.Desc);
        }
        [System.Web.Http.HttpPost]
        public BLL.Model.Contact GetById([FromBody]long id)
        {
            return _service.GetById(id);
        }
        [System.Web.Http.HttpPost]
        public long Insert([FromBody]BLL.Model.Contact contact)
        {
            return _service.Insert(contact);
        }
        [System.Web.Http.HttpPost]
        public void Update([FromBody]BLL.Model.Contact contact)
        {
            _service.Update(contact);
        }
        [System.Web.Http.HttpPost]
        public void Delete([FromBody]long id)
        {
            _service.Delete(id);
        }
    }
}
