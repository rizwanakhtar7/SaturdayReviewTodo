using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaturdayReviewTodo.Application.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, int key) : base($"{name} {key} not found")
        {
            
        }
    }
}
