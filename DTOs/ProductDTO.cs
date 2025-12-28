using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public record ProductDTO
    (
        int ProductId,

        string ProductName,

        decimal Price,

        string CategoryName,

        string Description

    );

    public record ProductShortDTO
    (
        int ProductId,

        string ProductName,

        decimal Price
    );
}
