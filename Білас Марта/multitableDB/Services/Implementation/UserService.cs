using ClientWebAPI.Infrastructure;
using Dapper;
using inClass.Models;
using System.Data;

namespace multitableDataBase.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly AppDb _appDB;
        private readonly IFake _fake;

        public UserService(AppDb appDB, IFake fake)
        {
            _appDB = appDB;
            _fake = fake;
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            if (_appDB.Connection.State == ConnectionState.Closed)
            {
                _appDB.Connection.Open();
            }

            var users = await _appDB.Connection.QueryAsync<User, UsersInfo, UsersPhone, User>(
                UserQueryConst.GET_ALL_USERS,
                (user, userInfo, userPhone) =>
                {
                    user.Info = userInfo;
                    user.Info.Phone = userPhone;
                    return user;
                });

            return users;
        }
    }
}
