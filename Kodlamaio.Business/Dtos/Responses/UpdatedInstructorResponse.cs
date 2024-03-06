using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlamaio.Business.Dtos.Responses;

public class UpdatedInstructorResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime UpdatedDate { get; set; }
}
