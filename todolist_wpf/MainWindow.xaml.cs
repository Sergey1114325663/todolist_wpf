using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Data.Entity;

namespace todolist_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<TodoItem> items = new ObservableCollection<TodoItem>();
        
     public MainWindow()
        {
            InitializeComponent();

            items.Add(new TodoItem("Сделать пет проект"));
            items.Add(new TodoItem("Закончить этот треш"));
            ListBox.ItemsSource = items;

        }
        class TodoItem
        {
            public string Title { get; set; }
            public bool IsDone { get; set; }

            public TodoItem(string title)
            {
                Title = title;
                IsDone = false;
            }
        }
        private void AddTask(object sender, TextChangedEventArgs e)
        {
            if (newTaskTextBox.Text.Length > 100)
            {
                TodoItem newTask = new TodoItem(newTaskTextBox.Text);
                items.Add(newTask);
                newTaskTextBox.Clear();
            }
        }
    public class TodoContext : DbContext
    {
       public DbSet<TodoItem> TodoItems { get; set; }
    }


     }
}
