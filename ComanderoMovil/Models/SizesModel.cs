using System;
using SQLite;

namespace ComanderoMovil.Models
{
    public class SizesModel
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
