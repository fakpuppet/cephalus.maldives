﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Cephalus.Maldives.DAL.Sql.Dto
{
    public abstract class TagDto
    {
        [Key]
        public int Id { get; set; }

        public Guid TagId { get; set; }

        public long CustomerId { get; set; }

        public abstract string Display();
    }
}