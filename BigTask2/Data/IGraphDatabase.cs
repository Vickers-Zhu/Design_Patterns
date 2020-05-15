//This file contains fragments that You have to fulfill

using BigTask2.Api;
namespace BigTask2.Data
{
    public interface IGraphDatabase
    {
        //Fill the return type of the method below
        /* */ void GetRoutesFrom(City from);
        City GetByName(string cityName);
    }
}
