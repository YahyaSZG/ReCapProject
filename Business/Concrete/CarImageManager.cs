using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Utilities;
using Core.Utilities.Helpers.FileHelper;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(/*IFormFile formFile,*/ CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImageCount(carImage.CarID));
            if (result != null)
            {
                return result;
            }

            //FileHelperForLocalStroge.Add(formFile, CreateNewPath(formFile, out var pathForDb));
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult("Ekleme işlemi başarılı");
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult("Silme işlemi başarılı");
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetByID(int carImageID)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == carImageID));
        }

        public IDataResult<List<CarImage>> GetImagesByCarID(int carID)
        {
            var result = _carImageDal.GetAll(c => c.CarID == carID);
            if (result.Count == 0)
            {
                return new SuccessDataResult<List<CarImage>>(CarImageNotHave());
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarID == carID));
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            var fileInfo = new FileInfo(formFile.FileName);
            FileHelperForLocalStroge.Update(formFile, fileInfo.DirectoryName, CreateNewPath(formFile, out var pathForDb));
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult("Güncelleme işlemi başarılı");
        }

        private string CreateNewPath(IFormFile formFile, out string pathForDb)
        {
            var fileInfo = new FileInfo(formFile.FileName);
            pathForDb = $@"{Guid.NewGuid() }_{DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}_{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}_{DateTime.Now.Millisecond}{fileInfo.Extension}";//Dosyaya isim verme işlemi.
            var createPathForHdd = $@"{Environment.CurrentDirectory}\wwwroot\images\" + pathForDb;

            return createPathForHdd;
        }

        private IResult CheckCarImageCount(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarID == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult("Maksimum 5 resim ekleyebilirsiniz.");
            }
            return new SuccessResult();
        }

        private List<CarImage> CarImageNotHave()
        {
            var result = new List<CarImage>();
            result.Add(new CarImage { ImagePath = $@"{Environment.CurrentDirectory}\wwwroot\images\DefaultCarImage.jpg" });
            return result;
        }
    }
}
