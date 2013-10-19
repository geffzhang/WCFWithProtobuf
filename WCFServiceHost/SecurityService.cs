using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WcfServiceContract;

namespace WCFServiceHost
{
    public class SecurityService : ISimpleContract
    {
        public bool IsAuthenticatedUser(User userObj)
        {
            throw new NotImplementedException();
        }

        public AuthenticateUserResponse AuthenticateUser(AuthenticateUserRequest userRequestObj)
        {
            AuthenticateUserResponse responseObj = new AuthenticateUserResponse();

            if ((userRequestObj.UserID == 1) && (userRequestObj.Password == "geffzhang@tencent"))
            {
                responseObj.StatusCode = 1;
                responseObj.StatusMessage = "Success";
                responseObj.IsAuthenticated = true;
            }
            else
            {
                responseObj.StatusCode = 2;
                responseObj.StatusMessage = "Not authenticated";
                responseObj.IsAuthenticated = false;
            }

            return responseObj;

        }
    }
}
