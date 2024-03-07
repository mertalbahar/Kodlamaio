﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlamaio.Business.Dtos.Responses;

public class UpdatedCourseResponse
{
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string ImageUrl { get; set; }
}
