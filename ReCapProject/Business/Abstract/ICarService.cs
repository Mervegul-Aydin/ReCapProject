using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;


namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>>GetCarByBrandId(int id);
        IDataResult<List<Car>> GetCarByColorId(int Id);
        IDataResult<List<CarDetailDto>>GetCarDetail();
    }
}