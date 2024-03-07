using Kodlamaio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlamaio.Entities.Concretes;

public class Course : EntityBase<int>, IEntity
{
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public Category Category { get; set; }
}
