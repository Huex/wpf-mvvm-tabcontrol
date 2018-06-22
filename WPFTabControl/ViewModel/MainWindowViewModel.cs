using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFTabControl
{
    public class MainWindowViewModel
    {
        private readonly ObservableCollection<ITab> _tabs;

        public ICommand NewTabCommand { get; }
        public ICollection<ITab> Tabs { get; }

        public MainWindowViewModel()
        {
            NewTabCommand = new ActionCommand(p => NewTab());
            _tabs = new ObservableCollection<ITab>();
            _tabs.CollectionChanged += Tabs_CollectionChanged;
            Tabs = _tabs;
        }

        private void NewTab()
        {
            Tabs.Add(new MySimpleTab());
        }

        private void Tabs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ITab tab;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    tab = (ITab)e.NewItems[0];
                    tab.CloseRequested += OnTabCloseRequested;
                    break;
                case NotifyCollectionChangedAction.Remove:
                    tab = (ITab)e.OldItems[0];
                    tab.CloseRequested -= OnTabCloseRequested;
                    break;
            }
        }

        private void OnTabCloseRequested(object sender, EventArgs e)
        {
            Tabs.Remove((ITab)sender);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
