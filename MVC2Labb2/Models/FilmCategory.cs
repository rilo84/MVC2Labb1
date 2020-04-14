﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC2Labb2.Models
{
    [Table("film_category")]
    public partial class FilmCategory
    {
        [Key]
        [Column("film_id")]
        public int FilmId { get; set; }
        [Key]
        [Column("category_id")]
        public byte CategoryId { get; set; }
        [Column("last_update", TypeName = "datetime")]
        public DateTime LastUpdate { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("FilmCategory")]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(FilmId))]
        [InverseProperty("FilmCategory")]
        public virtual Film Film { get; set; }
    }
}
