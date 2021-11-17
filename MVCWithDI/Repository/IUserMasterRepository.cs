using System.Collections.Generic;
using System.Data;

namespace MVCWithDI.Repository
{
    public interface IUserMasterRepository
    {
        DataTable GetAll();
        UserMaster Get(int id);
        void Add(UserMaster item);
        void Update(UserMaster item);
        bool Delete(int id);
    }
}
