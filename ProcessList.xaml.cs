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
        public Comment _Comments = new Comment();
      

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
                this.Processes.Add(process);
            }
        }


        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            //get all textboxes
            List<TextBox> collection = CommentColumn.TextBoxList();
            foreach (TextBox item in collection)
            {
                if (item.Text.Length != 0)
                {
                _Comments.Comments.Add(item.Text);

                }
            }
            Save.saveData(_Comments, "comm.xml");
        }
        
        
    }
}

public static class Helper
{
    //Method for getting all controls of a type
    public static IEnumerable<T> Descendants<T>(DependencyObject dependencyItem) where T : DependencyObject
    {
        if (dependencyItem != null)
        {
            for (var index = 0; index < VisualTreeHelper.GetChildrenCount(dependencyItem); index++)
            {
                var child = VisualTreeHelper.GetChild(dependencyItem, index);
                if (child is T dependencyObject)
                {
                    yield return dependencyObject;
                }

                foreach (var childOfChild in Descendants<T>(child))
                {
                    yield return childOfChild;
                }
            }
        }
    }

    //Extension method to get all TextBox Controls
    public static List<TextBox> TextBoxList(this DependencyObject control) => Descendants<TextBox>(control).ToList();


}
