using Kodlamaio.DataAccess.Abstracts;
using Kodlamaio.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlamaio.DataAccess.Concretes.EntityFramework;

public class EfCategoryDal : EfEntityRepositoryBase<Category>, ICategoryDal
{
    public EfCategoryDal(KodlamaioContext context) : base(context)
    {

    }
}
