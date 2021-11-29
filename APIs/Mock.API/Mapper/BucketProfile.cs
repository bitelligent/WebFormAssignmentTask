﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.ViewModels;
using AutoMapper;
using Mock.Model.Entities;

namespace Mock.API.Mapper
{
    public class BucketProfile : Profile
    {
        public BucketProfile()
        {
            CreateMap<Bucket, BucketViewModel>().ReverseMap();
            CreateMap<SupplierInvoice, InvoiceViewModel>().ReverseMap();


        }

    }
}
