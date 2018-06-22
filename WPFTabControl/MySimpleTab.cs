using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTabControl
{
    public class MySimpleTab : Tab
    {
        public MySimpleTab()
        {
            Name = String.Format("{0:hh:mm:ss}",DateTime.Now );
        }
    }
}
