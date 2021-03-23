using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalClinics
{
   public static class cls_Shared
    {
        public static string connectionsString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    }
}
