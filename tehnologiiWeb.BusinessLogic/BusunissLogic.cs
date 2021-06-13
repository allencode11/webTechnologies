using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tehnologiiWeb.BusinessLogic.Interfaces;

namespace tehnologiiWeb.BusinessLogic.LogicBL
{
    
    public class BusinessLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }

    }
    

}
