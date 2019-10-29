using System;
using SQLite;

namespace ComanderoMovil.Models
{
    public class LevelModel
    {
        [PrimaryKey]
        public int Number { get; set; }
        public int DishId { get; set; }
        public string Name { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
    }
}
