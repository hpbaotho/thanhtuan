using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication4
{
    class FormManage:Service.IPosInService
    {
        public void updateForm(byte t)
        {
            FrmLayout.GetInstance().RefreshForm();
        }
    }
}
