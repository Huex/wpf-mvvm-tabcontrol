using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFTabControl
{
    public class MySimpleTab : ITab
    {
        public string Name { get; set; }
        public ICommand CloseCommand { get; }
        public event EventHandler CloseRequested;

        public byte[] SomeData;

        public MySimpleTab()
        {
            CloseCommand = new ActionCommand(p => CloseRequested?.Invoke(this, EventArgs.Empty));
            Name = String.Format("{0:hh:mm:ss}",DateTime.Now );
            SomeData = new byte[1000000];
        }

        public void Dispose()
        {
            Name = null;
            SomeData = null;
        }
    }
}
