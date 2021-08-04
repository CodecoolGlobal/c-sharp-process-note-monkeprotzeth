using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Collections.ObjectModel;
using process_note.ViewModels;
using System.Globalization;
using System.Windows.Controls.Primitives;

namespace process_note
{
    /// <summary>
    /// Interaction logic for ProcessList.xaml
    /// </summary>
    public partial class ProcessList : UserControl
    {
        public ObservableCollection<WindowsProcess> Processes { get; set; }

        public ProcessList()
        {
            InitializeComponent();
            Processes = new ObservableCollection<WindowsProcess>();
            DataContext = this;
        }

        public List<WindowsProcess> GetProcesses()
        {
            List<WindowsProcess> windowsProcesses = new List<WindowsProcess>();
            foreach (var process in Process.GetProcesses())
            {
                var windowsprocess = new WindowsProcess();
                windowsprocess.Id = process.Id;
                windowsprocess.ProcessName = process.ProcessName;
                windowsprocess.VirtualMemorySize = process.VirtualMemorySize;

                try
                {
                    windowsprocess.StartTime = process.StartTime.ToString("h'h 'm'm 's's'");
                    windowsprocess.CPUTime = process.TotalProcessorTime.ToString();
                    windowsprocess.RunningTime = (process.StartTime - DateTime.Now).ToString("h'h 'm'm 's's'");
                }
                catch
                { }
                

                windowsProcesses.Add(windowsprocess);

            }
            return windowsProcesses;
        }

        private void RefreshList()
        {
            this.Processes.Clear();
            foreach (var process in GetProcesses())
            {
                this.Processes.Add(process);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshList();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            RefreshList();
        }
    }
}
