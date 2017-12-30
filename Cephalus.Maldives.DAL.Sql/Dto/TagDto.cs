using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Cephalus.Maldives.DAL.Sql.Dto
{
    public abstract class TagDto
    {
        [Key]
        public long Id { get; set; }

        public Guid TagId { get; set; }

        public TagTypeDto TagType { get; set; }

        public string Name { get; set; }

        public CustomerDto Customer { get; set; }

        public TagDto()
        {
            TagId = Guid.NewGuid();
        }

        public abstract string Display();

        public virtual bool IsMatch (string[] keyWords)
        {
            return keyWords.Any(k => Name.Like(k));
        }
    }
}