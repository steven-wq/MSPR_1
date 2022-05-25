using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dailybiz_API.com.dailybiz.exe;

namespace Dailybiz_API.Models
{
    public static class API
    {
        public static Idylisapi idev = new com.dailybiz.exe.Idylisapi();
        public static string test;
        public static string cSessionID;

        public static void setSession()
        {
            String session = "";
            session = API.idev.authentification1("mathiasapi", "mathias.hue@hotmail.com", "Lenny27");
            API.idev.SessionIDHeaderValue = new com.dailybiz.exe.SessionIDHeader();
            API.idev.SessionIDHeaderValue.SessionID = session;
           
        }
    }
}