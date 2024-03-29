﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetList(string p);
        List<Content> GetListByHeadingID(int id);
        List<Content> GetListByWriterID(int id);
        void ContentAdd(Content c);
        Content GetById(int id);
        void ContentDelete(Content c);
        void ContentUpdate(Content c);
    }
}
