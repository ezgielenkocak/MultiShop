﻿using Dapper;
using Multishop.Discount.Context;
using Multishop.Discount.Dtos;

namespace Multishop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code, Rate, IsActive, ValidDate) values (@code, @rate, @isActive, @validDate)";

            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);
            using(var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

         }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "Delete From Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId", id);

            using(var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);    
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "select * from coupons";
            using (var connection=_context.CreateConnection())
            {
                var values=await connection.QueryAsync<ResultDiscountCouponDto>(query); 
                return values.ToList();
            }
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            string query = "select * from Coupons where CouponId=@couponId";
            var parameters=new DynamicParameters();
            parameters.Add("@couponId", id);
            using(var connection= _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query, parameters);
               
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "update coupons set Code=@code, Rate=@rate, IsActive=@isactive, ValidDate=@validDate where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            parameters.Add("@couponId", updateCouponDto.CouponId);
            using (var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);

            }
        }
    }
}
