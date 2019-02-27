using System;
namespace DataInterfaces
{
    public interface IDataAccess
    {

        string Read();
        void Create();
        void Update();
        void Delete();


    }
}