using AutoMapper;
using Rate.Models.Domain;
using Rate.WebAPI.ViewModels.Currencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rate.WebAPI.Mappings
{
    public class ViewToDomainProfile : Profile
    {
        public override string ProfileName => "View-to-domain";

        public ViewToDomainProfile()
        {
            CreateMap<CurrencyPostModel, Currency>();
        }
    }
}
