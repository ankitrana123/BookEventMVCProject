using DataAccess.DataAccessModels;
using Services.ServiceModels;
using DataAccess.DataAccessServices;
using System;

namespace Services.ServiceOperations
{
    public class AccountOperations
    {
        public bool Login(AccountModel accountLoginModel)
        {
            User userEntity = new User();
            userEntity.EmailId = accountLoginModel.EmailId;
            userEntity.Password = accountLoginModel.Password;
            AccountDataAccess accountDataAccess = new AccountDataAccess();
            return accountDataAccess.Login(userEntity);
        }

        public int SignUp(AccountModel accountModel)
        {
            User model = new User();
            model.EmailId = accountModel.EmailId;
            model.Password = accountModel.Password;
            model.FullName = accountModel.FullName;
            AccountDataAccess accountDataAccess = new AccountDataAccess();
            var isValid = accountDataAccess.UserExists(model);
            if (isValid)
            {
                return 0;
            }
            return accountDataAccess.SignUp(model);

        }


    }
}
