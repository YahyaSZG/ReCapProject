﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByColorId(int Id);
        IDataResult<List<Car>> GetAllByBrandID(int Id);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<Car> GetById(int carId);
        IResult Add(Car car);
        //List<Car> GetAll();
        //List<Car> GetCarsByBrandId(int brandId);
        //List<Car> GetCarsByColorId(int colorId);
        //List<CarDetailDto> GetCarDetails();
        //Car GetById(int Id);
        //void Add(Car car);
        //void Update(Car car);
        //void Delete(Car car);
    }
}
