using System;
using SQLite;

namespace ComanderoMovil.Models
{
    public class GroupTypeModel
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
