﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor.Interfaces.Services
{
    public interface IJsonSerializerService
    {
        T DeserializeObject<T>(string source) where T : class;
        string SerializeObject(object source);
    }
}
