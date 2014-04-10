using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SENG471_Prototype
{
    public static class EventHandlers
    {
        public delegate void LoginHandler(string username);
        public delegate void EmptyHandler();
    }
}
