using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleWayECommerce.Application.Features.Category.Results
{
    public class CategoryResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int MinimumStockQuantity { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
