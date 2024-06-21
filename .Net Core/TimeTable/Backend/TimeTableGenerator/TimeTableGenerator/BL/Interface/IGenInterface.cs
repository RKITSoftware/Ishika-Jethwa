using TimeTableGenerator.enm;
using TimeTableGenerator.ML.POCO;

namespace TimeTableGenerator.BL.Interface
{
    public interface IGenInterface<T> where T : class
    {

        enmOperation Operation { get; set;  }

        Response GetAll();

        Response GetbyID(int id);

        Response Validate(T obj);

        Response Save();

        Response ValidateOnDelete(int id);

        Response DeletebyID(int id);
    }
}
