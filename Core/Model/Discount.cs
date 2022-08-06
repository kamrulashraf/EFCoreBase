using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Discount
    {
        public long DiscountId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double  Percentage { get; set; }
        public long VariationId { get; set; }
        public ProductVariation ProductVeriation { get; set; }

    }
}
