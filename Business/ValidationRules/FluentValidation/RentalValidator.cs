using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            /*yapısal kurallar ekleniyor.*/
            /**/
            //RuleFor(p => p.RentDate > DateTime.Now).GreaterThanOrEqualTo(p => p.ReturnDate == DateTime.Now).When(p => p.CarID == 1);
            /*olmayan bir kuralı oluşturmak*/
            //RuleFor(p=>p.Creator).Must(StartWithA);
            //RuleFor(p => p.Creator).Must(StartWithA).WithMessage("Oluşturucu adı a ile başlamalıdır.");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith('A');/*A ile mi başlıyor*/
        }
    }
}