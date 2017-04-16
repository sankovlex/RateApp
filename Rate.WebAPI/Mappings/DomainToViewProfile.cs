using AutoMapper;
using Rate.Models.Domain;
using Rate.WebAPI.ViewModels.Currencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rate.WebAPI.Mappings
{
    public class DomainToViewProfile : Profile
    {
        public override string ProfileName => "Domain-to-view";

        public DomainToViewProfile()
        {
            CreateMap<Currency, CurrencyViewModel>()
                .AfterMap((src, dst) => dst.DateCreate = src.DateCreate.ToString("yyyy-MM-dd hh:mm"));
        }
    }
}
