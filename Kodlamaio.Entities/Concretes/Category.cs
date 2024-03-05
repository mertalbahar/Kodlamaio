using Kodlamaio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlamaio.Entities.Concretes;

public class Category : EntityBase<int>, IEntity
{
    public string Title { get; set; }
}
