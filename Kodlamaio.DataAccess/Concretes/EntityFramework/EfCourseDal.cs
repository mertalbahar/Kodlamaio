using Kodlamaio.DataAccess.Abstracts;
using Kodlamaio.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kodlamaio.DataAccess.Concretes.EntityFramework;

public class EfCourseDal : EfEntityRepositoryBase<Course>, ICourseDal
{
    public EfCourseDal(KodlamaioContext context) : base(context)
    {
        
    }
}
