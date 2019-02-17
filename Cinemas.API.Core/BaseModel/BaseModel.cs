﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas.API.Core.BaseModel
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
        public bool IsDelete { get; set; }
        public DateTimeOffset DeleteDate { get; set; }
    }
}
