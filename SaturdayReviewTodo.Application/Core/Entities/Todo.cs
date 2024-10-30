using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaturdayReviewTodo.Application.Core.Entities
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }   
        public string Description { get; set; }

        public DateTime DatePosted { get; set; }
    }
}
