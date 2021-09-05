﻿using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (!GetByCarIdForReturnDate(rental.CarID).Success)
            {
                return new ErrorResult("Bu araç zaten kiralanmış!");
            }
            _rentalDal.Add(rental);
            return new SuccessResult("Kiralama kaydı eklendi");
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult("Kiralama kaydı silindi.");
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == Id));
        }

        public IResult GetByCarIdForReturnDate(int CarId)
        {
            var result = _rentalDal.Get(r => r.CarID == CarId && (r.RentDate != null && r.ReturnDate == null));
            if (result != null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult("Kiralama kaydı güncellendi.");
        }
    }
}
