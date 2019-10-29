using System;
using SQLite;

namespace ComanderoMovil.Models
{
    public class GroupSizeModel
    {
        [PrimaryKey]
        public int SizeId { get; set; }
        public int GroupId { get; set; }
    }
}
