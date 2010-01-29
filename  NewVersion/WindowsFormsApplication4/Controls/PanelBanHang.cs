using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication4.Controls
{
    public partial class PanelBanHang : panel
    {
        public PanelBanHang()
        {
            InitializeComponent();
        }

        public PanelBanHang(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
