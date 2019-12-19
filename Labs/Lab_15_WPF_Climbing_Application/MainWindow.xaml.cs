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

namespace Lab_15_WPF_Climbing_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ClimbIndoor> indoors = new List<ClimbIndoor>();
        List<ClimbOutdoor> outdoors = new List<ClimbOutdoor>();
        ClimbIndoor climbIndoor = new ClimbIndoor();
        ClimbOutdoor climbOutdoor = new ClimbOutdoor();
        string tableName = "Indoors";
        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }
        void Initialise()
        {
            using (var db = new ClimbingDBEntities())
            {
                indoors = db.ClimbIndoors.ToList();
                outdoors = db.ClimbOutdoors.ToList();
            }
            ListViewIndoors.ItemsSource = indoors;
            ListViewOutdoors.ItemsSource = outdoors;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (tableName)
            {
                case "Indoors":
                    climbIndoor = (ClimbIndoor)ListViewIndoors.SelectedItem;
                    if (climbIndoor != null)
                    {
                        TextBoxClimbID.Text = climbIndoor.ClimbID.ToString();
                        TextBoxClimbName.Text = climbIndoor.ClimbName.ToString();
                        TextBoxClimbGrade.Text = climbIndoor.ClimbGrade.ToString();
                        CheckboxClimbDone.IsChecked = climbIndoor.ClimbDone;
                        TextBoxClimbLocation.Text = climbIndoor.ClimbLocation.ToString();
                    }
                    break;
                case "Outdoors":
                    climbOutdoor = (ClimbOutdoor)ListViewOutdoors.SelectedItem;
                    if (climbOutdoor != null)
                    {
                        TextBoxClimbID.Text = climbOutdoor.ClimbID.ToString();
                        TextBoxClimbName.Text = climbOutdoor.ClimbName.ToString();
                        TextBoxClimbGrade.Text = climbOutdoor.ClimbGrade.ToString();
                        CheckboxClimbDone.IsChecked = climbOutdoor.ClimbDone;
                        TextBoxClimbLocation.Text = climbOutdoor.ClimbLocation.ToString();
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
                TextBoxClimbName.IsReadOnly = false;
                TextBoxClimbGrade.IsReadOnly = false;
                CheckboxClimbDone.IsEnabled = true;
                TextBoxClimbLocation.IsReadOnly = false;
                TextBoxClimbName.Background = Brushes.White;
                TextBoxClimbGrade.Background = Brushes.White;
                TextBoxClimbLocation.Background = Brushes.White;
                ButtonEdit.Content = "Save";
            }
            else
            {
                BrushConverter brush = new BrushConverter();
                using (var db = new ClimbingDBEntities())
                {
                    switch (tableName)
                    {
                        case "Indoors":
                            var climbToEdit = db.ClimbIndoors.Find(climbIndoor.ClimbID);
                            climbToEdit.ClimbName = TextBoxClimbName.Text;
                            climbToEdit.ClimbGrade = TextBoxClimbGrade.Text;
                            climbToEdit.ClimbDone = (bool)CheckboxClimbDone.IsChecked;
                            climbToEdit.ClimbLocation = TextBoxClimbLocation.Text;
                            db.SaveChanges();
                            ListViewIndoors.ItemsSource = null;
                            indoors = db.ClimbIndoors.ToList();
                            ListViewIndoors.ItemsSource = indoors;
                            break;
                        case "Outdoors":                            
                            var climbToEdit1 = db.ClimbOutdoors.Find(climbOutdoor.ClimbID);
                            climbToEdit1.ClimbName = TextBoxClimbName.Text;
                            climbToEdit1.ClimbGrade = TextBoxClimbGrade.Text;
                            climbToEdit1.ClimbDone = (bool)CheckboxClimbDone.IsChecked;
                            climbToEdit1.ClimbLocation = TextBoxClimbLocation.Text;
                            db.SaveChanges();
                            ListViewOutdoors.ItemsSource = null;
                            outdoors = db.ClimbOutdoors.ToList();
                            ListViewOutdoors.ItemsSource = outdoors;                            
                            break;
                        default:
                            break;
                    }
                }
                TextBoxClimbName.IsReadOnly = true;
                TextBoxClimbGrade.IsReadOnly = true;
                CheckboxClimbDone.IsEnabled = false;
                TextBoxClimbLocation.IsReadOnly = true;
                TextBoxClimbName.Background = (Brush)brush.ConvertFrom("#BECCE8");
                TextBoxClimbGrade.Background = (Brush)brush.ConvertFrom("#BECCE8");
                TextBoxClimbLocation.Background = (Brush)brush.ConvertFrom("#BECCE8");
                ButtonEdit.Content = "Edit";
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if ((string)ButtonAdd.Content == "Add")
            {
                TextBoxClimbName.IsReadOnly = false;
                TextBoxClimbGrade.IsReadOnly = false;
                CheckboxClimbDone.IsEnabled = true;
                TextBoxClimbLocation.IsReadOnly = false;
                TextBoxClimbName.Background = Brushes.White;
                TextBoxClimbGrade.Background = Brushes.White;
                TextBoxClimbLocation.Background = Brushes.White;
                ButtonAdd.Content = "Confirm";
            }
            else
            {
                BrushConverter brush = new BrushConverter();
                using (var db = new ClimbingDBEntities())
                {
                    switch (tableName)
                    {
                        case "Indoors":
                            ClimbIndoor climbIndoor = new ClimbIndoor
                            {
                                ClimbName = TextBoxClimbName.Text,
                                ClimbGrade = TextBoxClimbGrade.Text,
                                ClimbDone = (bool)CheckboxClimbDone.IsChecked,
                                ClimbLocation = TextBoxClimbLocation.Text
                            };
                            db.ClimbIndoors.Add(climbIndoor);
                            db.SaveChanges();
                            ListViewIndoors.ItemsSource = null;
                            indoors = db.ClimbIndoors.ToList();
                            ListViewIndoors.ItemsSource = indoors;
                            break;
                        case "Outdoors":
                            ClimbOutdoor climbOutdoor = new ClimbOutdoor
                            {
                                ClimbName = TextBoxClimbName.Text,
                                ClimbGrade = TextBoxClimbGrade.Text,
                                ClimbDone = (bool)CheckboxClimbDone.IsChecked,
                                ClimbLocation = TextBoxClimbLocation.Text
                            };
                            db.ClimbOutdoors.Add(climbOutdoor);
                            db.SaveChanges();
                            ListViewOutdoors.ItemsSource = null;
                            outdoors = db.ClimbOutdoors.ToList();
                            ListViewOutdoors.ItemsSource = outdoors;
                            break;
                        default:
                            break;
                    }
                }
                TextBoxClimbName.IsReadOnly = true;
                TextBoxClimbGrade.IsReadOnly = true;
                CheckboxClimbDone.IsEnabled = false;
                TextBoxClimbLocation.IsReadOnly = true;
                TextBoxClimbName.Background = (Brush)brush.ConvertFrom("#BECCE8");
                TextBoxClimbGrade.Background = (Brush)brush.ConvertFrom("#BECCE8");
                TextBoxClimbLocation.Background = (Brush)brush.ConvertFrom("#BECCE8");
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
                using (var db = new ClimbingDBEntities())
                {
                    switch (tableName)
                    {
                        case "Indoors":
                            var climbToDelete = db.ClimbIndoors.Find(climbIndoor.ClimbID);
                            db.ClimbIndoors.Remove(climbToDelete);
                            db.SaveChanges();
                            ListViewIndoors.ItemsSource = null;
                            indoors = db.ClimbIndoors.ToList();
                            ListViewIndoors.ItemsSource = indoors;
                            break;
                        case "Outdoors":
                            var climbToDelete1 = db.ClimbOutdoors.Find(climbOutdoor.ClimbID);
                            db.ClimbOutdoors.Remove(climbToDelete1);
                            db.SaveChanges();
                            ListViewOutdoors.ItemsSource = null;
                            outdoors = db.ClimbOutdoors.ToList();
                            ListViewOutdoors.ItemsSource = outdoors;
                            break;
                        default:
                            break;
                    }
                }
                ButtonDelete.Content = "Delete";
                BrushConverter brush = new BrushConverter();
                ButtonDelete.Background = (Brush)brush.ConvertFrom("#BECCE8");
            }
        }

        private void LabelIndoors_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tableName = "Indoors";
            ListViewOutdoors.SelectedItem = null;
        }

        private void LabelOutdoors_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tableName = "Outdoors";
            ListViewIndoors.SelectedItem = null;
        }
    }
}
