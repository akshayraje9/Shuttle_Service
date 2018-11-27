using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class RideDetail
    {

        static List<RideDetail> rd = new List<RideDetail>();

        public string CustName
        {
            get;
            set;
        }

        public string PickupAdd
        {
            get;
            set;
        }

        public string DropoffAdd
        {
            get;
            set;
        }

        public string TravelDt
        {
            get;
            set;
        }

        public string PickupTime
        {
            get;
            set;
        }

        public int RideId
        {
            get;
            set;
        }
    }
}