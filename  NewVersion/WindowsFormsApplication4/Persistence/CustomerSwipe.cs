using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication4.Persistence
{
    public class CustomerSwipe
    {
        public string swipeId;
        public bool isNew = false;
        public bool isDelete = false;
        public CustomerSwipe(string swipe)
        {
            swipeId = swipe;
        }
        public override string ToString()
        {
            return swipeId;
        }

    }
}
