using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cephalus.Maldives.DAL.Sql.Dto
{
    [Table("Customer")]
    public class CustomerDto
    {
        [Key]
        [Column(Order = 1)]
        public long Id { get; set; }

        public Guid CustomerId { get; set; }

        public string CustomerNumber { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? BirthDate { get; set; }

        public virtual ICollection<TagDto> Tags { get; set; }

        public CustomerDto()
        {
            CustomerId = Guid.NewGuid();
        }
    }
}
