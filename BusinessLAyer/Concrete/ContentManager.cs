using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccess.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class ContentManager:IContentService
    {
        private IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public List<Content> GetList()
        {
           return _contentDal.List();
        }

        public List<Content> GetListByHeadingID(int id)
        {
            return _contentDal.List(x => x.ContentId == id);
        }

        public List<Content> GetListByWriterID(int id)
        {
            return _contentDal.List(x => x.WriterId == id );
        }

        public void ContentAdd(Content c)
        {
            _contentDal.insert(c);
        }

        public Content GetById(int id)
        {
           return _contentDal.Get(x => x.ContentId == id);
        }

        public void ContentDelete(Content c)
        {
           _contentDal.Delete(c);
        }

        public void ContentUpdate(Content c)
        {
            _contentDal.Update(c);
        }
    }
}
