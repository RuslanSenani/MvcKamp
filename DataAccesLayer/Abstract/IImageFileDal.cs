﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace DataAccesLayer.Abstract
{
    public interface IImageFileDal : IRepository<ImageFile>
    {
    }
}