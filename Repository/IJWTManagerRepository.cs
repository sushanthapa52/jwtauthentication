using test_webapi_notification.Models;

namespace test_webapi_notification.Repository
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(Users users);


    }
}
