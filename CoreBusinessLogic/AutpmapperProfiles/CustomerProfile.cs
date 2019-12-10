using AutoMapper;
using CoreDataLayer.ModelsDB;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBusinessLogic.AutpmapperProfiles
{
    class CustomerProfile: Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customers, CustomersModel>();
            CreateMap<CustomersModel, Customers>();
        }
    }
}


// Note: In dot net core, As soon as our application starts and initializes AutoMapper, AutoMapper will scan our application and look for classes that inherit from the Profile class and load their mapping configurations.
