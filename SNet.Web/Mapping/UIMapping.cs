using AutoMapper;
using SNet.Common.DomainModels;
using SNet.Web.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNet.DomainServices.Mapping
{
    public partial class UIMapping
    {
        public static void Configure()
        {
            Mapper.CreateMap<AccountModel, AccountDomain>()
               .ForMember(dest => dest.Id, source => source.MapFrom(x => x.Id))
               .ForMember(dest => dest.FirstName, source => source.MapFrom(x => x.FirstName))
               .ForMember(dest => dest.LastName, source => source.MapFrom(x => x.LastName))
               .ForMember(dest => dest.AgreedToTermsDate, source => source.MapFrom(x => x.AgreedToTermsDate))
           ;
            Mapper.CreateMap<AccountDomain, AccountModel>()
               .ForMember(dest => dest.Id, source => source.MapFrom(x => x.Id))
               .ForMember(dest => dest.FirstName, source => source.MapFrom(x => x.FirstName))
               .ForMember(dest => dest.LastName, source => source.MapFrom(x => x.LastName))
               .ForMember(dest => dest.AgreedToTermsDate, source => source.MapFrom(x => x.AgreedToTermsDate))
          ;
        }

    }
}
