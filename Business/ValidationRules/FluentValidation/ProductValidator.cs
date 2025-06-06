﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0).WithMessage("Birim fiyat 0'dan büyük olmalı !");
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1).WithMessage("İçecek kategorisi (1) için birim fiyat 10'dan büyük veya eşit olmalı !");
            RuleFor(p =>p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı !");

        }

        private bool StartWithA(string girilen)
        {
            return girilen.StartsWith("A");
        }
    }
}
