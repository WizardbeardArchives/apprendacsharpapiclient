using ApprendaAPIClient;

namespace Apprenda.Testing.RestAPITestTools.Repositories
{
    public interface IUserLoginRepository
    {
        /// <summary>
        /// Assumes we have a pool of user logins and wish to get the next one
        /// </summary>
        /// <returns></returns>
        IUserLogin GetNextAvailableUserLogin();

        IUserLogin GetAdminUserLogin();
    }
}
