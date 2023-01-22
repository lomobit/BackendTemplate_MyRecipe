using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipe.Domain
{
    public class Dish
    {
        /// <summary>
        /// Идентификатор блюда.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование блюда.
        /// </summary>
        public string Name { get; set; }
    }
}
