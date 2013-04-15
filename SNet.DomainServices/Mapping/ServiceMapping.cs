using AutoMapper;
using SNet.Common.DomainModels;
using SNet.Repositories.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNet.DomainServices.Mapping
{
    public partial class ServiceMapping
    {
        public static void Configure()
        {
            Mapper.CreateMap<Account, AccountDomain>()
               .ForMember(dest => dest.FirstName, source => source.MapFrom(x => x.FirstName))
               .ForMember(dest => dest.LastName, source => source.MapFrom(x => x.LastName))
               .ForMember(dest => dest.AgreedToTermsDate, source => source.MapFrom(x => x.AgreedToTermsDate))
           ;
            Mapper.CreateMap<AccountDomain, Account>()
               .ForMember(dest => dest.FirstName, source => source.MapFrom(x => x.FirstName))
               .ForMember(dest => dest.LastName, source => source.MapFrom(x => x.LastName))
               .ForMember(dest => dest.AgreedToTermsDate, source => source.MapFrom(x => x.AgreedToTermsDate))
          ;
        }
    }
}
