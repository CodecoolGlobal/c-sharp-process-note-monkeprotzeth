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

namespace process_note
{
    /// <summary>
    /// Interaction logic for ProcessList.xaml
    /// </summary>
    public partial class ProcessList : UserControl
    {
        public ObservableCollection<Process> Processes { get; set; }

        public ProcessList()
        {
            InitializeComponent();
            Processes = new ObservableCollection<Process>();
            DataContext = this;
        }

        public Process[] GetProcesses()
        {
            return Process.GetProcesses();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Processes.Clear();
            foreach (var process in GetProcesses())
            {
                //var CPUTime = process.TotalProcessorTime.ToString();
                //this.Processes.Add(CPUTime);
                this.Processes.Add(process);
            }
        }
    }
}
