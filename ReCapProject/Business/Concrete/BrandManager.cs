﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult();
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult();
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var result = _brandDal.GetAll();

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.SuccessGetAllMessage);
        }

        public IDataResult<Brand> GetById(int id)
        {
            var result = _brandDal.Get(p => p.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Brand>(Messages.ErrorGetByIdMessage);
            }
            return new SuccessDataResult<Brand>(result, Messages.SuccessGetByIdMessage);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.UpdatedSuccessMessage);
        }
    }
}