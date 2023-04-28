namespace multitableDataBase.Services.Implementation
{
    public class UserQueryConst
    {
        public const string GET_ALL_USERS = @"SELECT usr.*, info.*, users_phone.*
                FROM users_data usr
                    INNER JOIN  users_info info ON usr.id = info.user_id 
                    INNER JOIN  users_phone ON info.id = users_phone.user_info_id";
    }
}
