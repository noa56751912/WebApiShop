using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public record OrderItemDTO
    (
        int OrderItemId,


        int ProductId,

        int OrderId,
        

        int? Quantity
        
        );
}
