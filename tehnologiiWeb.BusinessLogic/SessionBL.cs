using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tehnologiiWeb.BusinessLogic.Core;
using tehnologiiWeb.BusinessLogic.Interfaces;

namespace tehnologiiWeb.BusinessLogic
{
    public class SessionBL : UserApi, ISession
    {
        public bool GetUserSessionStatus()
        {
            return UserSessionStatus();
        }
        public ULoginResp UserLogin(ULoginData data)
        {
            return UserSessionData(data);
        }
    }

}
