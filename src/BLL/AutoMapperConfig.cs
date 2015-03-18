using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

namespace BLL
{
    /// <summary>
    /// Handles configuration of AutoMapper mappings
    /// </summary>
    public static class AutoMapperConfig
    {
        public static void ConfigureMappings()
        {
            Mapper.Configuration.AllowNullCollections = true;

            // Inbound
            Mapper.CreateMap<DAL.Entities.Contact, BLL.Model.Contact>();
            Mapper.CreateMap<DAL.Entities.Email, BLL.Model.Email>();
            Mapper.CreateMap<DAL.Entities.EntryType, BLL.Model.EntryType>();
            Mapper.CreateMap<DAL.Entities.Phone, BLL.Model.Phone>();
            Mapper.CreateMap<DAL.Entities.Tag, BLL.Model.Tag>();

            // Outbound
            Mapper.CreateMap<BLL.Model.Contact, DAL.Entities.Contact>();
            Mapper.CreateMap<BLL.Model.Email, DAL.Entities.Email>();
            Mapper.CreateMap<BLL.Model.EntryType, DAL.Entities.EntryType>();
            Mapper.CreateMap<BLL.Model.Phone, DAL.Entities.Phone>();
            Mapper.CreateMap<BLL.Model.Tag, DAL.Entities.Tag>();
        }
    }
}
