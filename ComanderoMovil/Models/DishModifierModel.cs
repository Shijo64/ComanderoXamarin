using System;
using SQLite;

namespace ComanderoMovil.Models
{
    public class DishModifierModel
    {
        [PrimaryKey]
        public int ModifierId { get; set; }
        public int DishId { get; set; }
        public int LevelNumber { get; set; }
    }
}
