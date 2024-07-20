﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAdressByIdQuery
    {
        public int Id { get; set; }
        public GetAdressByIdQuery(int id)
        {
                Id = id;
        }
    }
}