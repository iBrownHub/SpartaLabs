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

namespace Lab_14_WPF_ToDo_Application_Framework
{
    public partial class MainWindow : Window
    {
        List<Category> categories = new List<Category>();
        List<Task> tasks = new List<Task>();
        List<User> users = new List<User>();
        Category category = new Category();
        Task task = new Task();
        User user = new User();
        string tableName = "Tasks";

        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        void Initialise()
        {
            using(var db = new TasksDBEntities())
            {
                tasks = db.Tasks.ToList();
                categories = db.Categories.ToList();
                users = db.Users.ToList();
            }
            ListBox.ItemsSource = tasks;
            ListBox.DisplayMemberPath = "Description";
            ComboBox1.ItemsSource = categories;
            ComboBox1.DisplayMemberPath = "CategoryName";
            ComboBox2.ItemsSource = users;
            ComboBox2.DisplayMemberPath = "UserName";
        }

        private void ListBoxTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (tableName)
            {
                case "Tasks":
                    task = (Task)ListBox.SelectedItem;
                    if (task != null)
                    {
                        TextBoxID.Text = task.TaskID.ToString();
                        TextBoxDescription.Text = task.Description.ToString();
                        LabelCategory.Content = "Category";
                        TextBoxCategoryID.Text = task.CategoryID.ToString();
                        LabelUser.Content = "User";
                        TextBoxUserID.Text = task.UserID.ToString();
                        ComboBox1.SelectedIndex = ((int)task.CategoryID - 1);
                        if (task.UserID != null)
                        {
                            if (task.UserID >= 3)
                            {
                                ComboBox2.SelectedIndex = ((int)task.UserID - 2);
                            }
                            else
                            {
                                ComboBox2.SelectedIndex = ((int)task.UserID - 1);
                            }
                        }
                    }
                    break;
                case "Categories":
                    category = (Category)ListBox.SelectedItem;
                    if (category != null)
                    {
                        TextBoxID.Text = category.CategoryID.ToString();
                        TextBoxDescription.Text = category.CategoryName.ToString();
                        LabelCategory.Content = "";
                        TextBoxCategoryID.Text = "";
                        LabelUser.Content = "";
                        TextBoxUserID.Text = "";
                        ComboBox1.SelectedIndex = ((int)task.TaskID - 1);
                        if (task.UserID != null)
                        {
                            ComboBox2.SelectedIndex = ((int)task.UserID - 1);
                        }
                    }
                    break;
                case "Users":
                    user = (User)ListBox.SelectedItem;
                    if (user != null)
                    {
                        TextBoxID.Text = user.UserID.ToString();
                        TextBoxDescription.Text = user.UserName.ToString();
                        LabelCategory.Content = "";
                        TextBoxCategoryID.Text = "";
                        LabelUser.Content = "";
                        TextBoxUserID.Text = "";
                        if (task != null)
                        {
                            ComboBox1.SelectedIndex = ((int)task.TaskID - 1);
                            ComboBox2.SelectedIndex = ((int)task.CategoryID - 1);
                        }
                    }
                    break;
                default:
                    break;
            }
            ButtonEdit.IsEnabled = true;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if ((string)ButtonEdit.Content == "Edit")
            {
                switch (tableName)
                {
                    case "Tasks":
                        TextBoxDescription.IsReadOnly = false;
                        TextBoxCategoryID.IsReadOnly = false;
                        TextBoxUserID.IsReadOnly = false;
                        TextBoxDescription.Background = Brushes.White;
                        TextBoxCategoryID.Background = Brushes.White;
                        TextBoxUserID.Background = Brushes.White;
                        break;
                    case "Categories":
                        TextBoxDescription.IsReadOnly = false;
                        TextBoxDescription.Background = Brushes.White;
                        break;
                    case "Users":
                        TextBoxDescription.IsReadOnly = false;
                        TextBoxDescription.Background = Brushes.White;
                        break;
                    default:
                        break;
                }
                
                ButtonEdit.Content = "Save";
            }
            else
            {
                BrushConverter brush = new BrushConverter();
                switch (tableName)
                {
                    case "Tasks":
                        using (var db = new TasksDBEntities())
                        {
                            var taskToEdit = db.Tasks.Find(task.TaskID);
                            taskToEdit.Description = TextBoxDescription.Text;
                            taskToEdit.CategoryID = Convert.ToInt32(TextBoxCategoryID.Text);
                            taskToEdit.UserID = Convert.ToInt32(TextBoxUserID.Text);
                            db.SaveChanges();
                            ListBox.ItemsSource = null;
                            tasks = db.Tasks.ToList();
                            ListBox.ItemsSource = tasks;
                        }
                        TextBoxDescription.IsReadOnly = true;
                        TextBoxCategoryID.IsReadOnly = true;
                        TextBoxUserID.IsReadOnly = true;
                        TextBoxDescription.Background = (Brush)brush.ConvertFrom("#E8D79B");
                        TextBoxCategoryID.Background = (Brush)brush.ConvertFrom("#E8D79B");
                        TextBoxUserID.Background = (Brush)brush.ConvertFrom("#E8D79B");
                        break;
                    case "Categories":
                        using (var db = new TasksDBEntities())
                        {
                            var categoryToEdit = db.Categories.Find(category.CategoryID);
                            categoryToEdit.CategoryName = TextBoxDescription.Text;
                            db.SaveChanges();
                            ListBox.ItemsSource = null;
                            categories = db.Categories.ToList();
                            ListBox.ItemsSource = categories;
                        }
                        TextBoxDescription.IsReadOnly = true;
                        TextBoxDescription.Background = (Brush)brush.ConvertFrom("#E8D79B");
                        break;
                    case "Users":
                        using (var db = new TasksDBEntities())
                        {
                            var userToEdit = db.Users.Find(user.UserID);
                            userToEdit.UserName = TextBoxDescription.Text;
                            db.SaveChanges();
                            ListBox.ItemsSource = null;
                            users = db.Users.ToList();
                            ListBox.ItemsSource = users;
                        }
                        TextBoxDescription.IsReadOnly = true;
                        TextBoxDescription.Background = (Brush)brush.ConvertFrom("#E8D79B");
                        break;
                    default:
                        break;
                }
                ButtonEdit.Content = "Edit";
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if ((string)ButtonAdd.Content == "Add")
            {
                switch (tableName)
                {
                    case "Tasks":
                        TextBoxDescription.IsReadOnly = false;
                        TextBoxCategoryID.IsReadOnly = false;
                        TextBoxUserID.IsReadOnly = false;
                        TextBoxDescription.Background = Brushes.White;
                        TextBoxCategoryID.Background = Brushes.White;
                        TextBoxUserID.Background = Brushes.White;
                        break;
                    case "Categories":
                        TextBoxDescription.IsReadOnly = false;
                        TextBoxDescription.Background = Brushes.White;
                        break;
                    case "Users":
                        TextBoxDescription.IsReadOnly = false;
                        TextBoxDescription.Background = Brushes.White;
                        break;
                    default:
                        break;
                }
                ButtonAdd.Content = "Confirm";
            }
            else
            {
                BrushConverter brush = new BrushConverter();
                switch (tableName)
                {
                    case "Tasks":
                        using (var db = new TasksDBEntities())
                        {
                            Task newTask = new Task
                            {
                                Description = TextBoxDescription.Text,
                                CategoryID = Convert.ToInt32(TextBoxCategoryID.Text)
                            };
                            db.Tasks.Add(newTask);
                            db.SaveChanges();
                            ListBox.ItemsSource = null;
                            tasks = db.Tasks.ToList();
                            ListBox.ItemsSource = tasks;
                        }
                        TextBoxDescription.IsReadOnly = true;
                        TextBoxCategoryID.IsReadOnly = true;
                        TextBoxUserID.IsReadOnly = true;
                        TextBoxDescription.Background = (Brush)brush.ConvertFrom("#E8D79B");
                        TextBoxCategoryID.Background = (Brush)brush.ConvertFrom("#E8D79B");
                        TextBoxUserID.Background = (Brush)brush.ConvertFrom("#E8D79B");
                        break;
                    case "Categories":
                        using (var db = new TasksDBEntities())
                        {
                            Category newCategory = new Category
                            {
                                CategoryName = TextBoxDescription.Text,
                            };
                            db.Categories.Add(newCategory);
                            db.SaveChanges();
                            ListBox.ItemsSource = null;
                            categories = db.Categories.ToList();
                            ListBox.ItemsSource = categories;
                        }
                        TextBoxDescription.IsReadOnly = true;
                        TextBoxDescription.Background = (Brush)brush.ConvertFrom("#E8D79B");
                        break;
                    case "Users":
                        using (var db = new TasksDBEntities())
                        {
                            User newUser = new User
                            {
                                UserName = TextBoxDescription.Text,
                            };
                            db.Users.Add(newUser);
                            db.SaveChanges();
                            ListBox.ItemsSource = null;
                            users = db.Users.ToList();
                            ListBox.ItemsSource = users;
                        }
                        TextBoxDescription.IsReadOnly = true;
                        TextBoxDescription.Background = (Brush)brush.ConvertFrom("#E8D79B");
                        break;
                    default:
                        break;
                }
                ButtonAdd.Content = "Add";
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if ((string)ButtonDelete.Content == "Delete")
            {                
                ButtonDelete.Content = "Are You Sure?";
                ButtonDelete.Background = Brushes.Red;
            }
            else
            {
                switch (tableName)
                {
                    case "Tasks":
                        using (var db = new TasksDBEntities())
                        {
                            var taskToDelete = db.Tasks.Find(task.TaskID);
                            db.Tasks.Remove(taskToDelete);
                            db.SaveChanges();
                            ListBox.ItemsSource = null;
                            tasks = db.Tasks.ToList();
                            ListBox.ItemsSource = tasks;
                        }
                        break;
                    case "Categories":
                        using (var db = new TasksDBEntities())
                        {
                            var categoryToDelete = db.Categories.Find(category.CategoryID);
                            db.Categories.Remove(categoryToDelete);
                            db.SaveChanges();
                            ListBox.ItemsSource = null;
                            categories = db.Categories.ToList();
                            ListBox.ItemsSource = categories;
                        }
                        break;
                    case "Users":
                        using (var db = new TasksDBEntities())
                        {
                            var userToDelete = db.Users.Find(user.UserID);
                            db.Users.Remove(userToDelete);
                            db.SaveChanges();
                            ListBox.ItemsSource = null;
                            users = db.Users.ToList();
                            ListBox.ItemsSource = users;
                        }
                        break;
                    default:
                        break;
                }          
                ButtonDelete.Content = "Delete";
                BrushConverter brush = new BrushConverter();
                ButtonDelete.Background = (Brush)brush.ConvertFrom("#FFE4AB");
            }
        }

        private void ButtonSwitchTable_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string i = (string)btn.Content;
            switch (i)
            {
                case "Tasks":
                    tableName = "Tasks";
                    ListBox.ItemsSource = tasks;
                    ListBox.DisplayMemberPath = "Description";
                    ComboBox1.ItemsSource = categories;
                    ComboBox1.DisplayMemberPath = "CategoryName";
                    ComboBox2.ItemsSource = users;
                    ComboBox2.DisplayMemberPath = "UserName";
                    break;
                case "Categories":
                    tableName = "Categories";
                    ListBox.ItemsSource = categories;
                    ListBox.DisplayMemberPath = "CategoryName";
                    ComboBox1.ItemsSource = tasks;
                    ComboBox1.DisplayMemberPath = "Description";
                    ComboBox2.ItemsSource = users;
                    ComboBox2.DisplayMemberPath = "UserName";
                    break;
                case "Users":
                    tableName = "Users";
                    ListBox.ItemsSource = users;
                    ListBox.DisplayMemberPath = "UserName";
                    ComboBox1.ItemsSource = tasks;
                    ComboBox1.DisplayMemberPath = "Description";
                    ComboBox2.ItemsSource = categories;
                    ComboBox2.DisplayMemberPath = "CategoryName";
                    break;
                default:
                    break;
            }
        }
    }
}