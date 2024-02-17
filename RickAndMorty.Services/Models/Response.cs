﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RickAndMorty.Data.RequestFeatures;

namespace RickAndMorty.Services.Models
{
    public class Response
    {
        public string Message { get; set; }
        public object Data { get; set; }
        public int Code { get; set; }
        public Info Info { get; set; }
    }
}
