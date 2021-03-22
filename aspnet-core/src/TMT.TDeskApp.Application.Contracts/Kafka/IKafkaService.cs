﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TMT.TDeskApp.Messages
{
    public interface IKafkaService 
    { 
        Task CreateAsync(MessageEto input);
    }
}