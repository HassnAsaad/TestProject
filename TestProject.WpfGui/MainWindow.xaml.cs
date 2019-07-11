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
using TestProject.DataLayar;



namespace TestProject.WpfGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeRepostry repo = new EmployeeRepostry();
        EmployeeValidation validitor = new EmployeeValidation();
        char[] num = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public MainWindow()
        {
            InitializeComponent();
            this.EmployeeList.ItemsSource = repo.GetAll();

        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {

            string massage = "";
            Employee newEmployee = new Employee();
            newEmployee.FirstName = First_Name.Text;
            newEmployee.LastName = Last_Name.Text;
            newEmployee.StartDate = StartDate.SelectedDate.Value.Date.ToLongDateString();
            if (!string.IsNullOrEmpty(Salary.Text))
                newEmployee.Salary = Convert.ToInt32(Salary.Text);
            else newEmployee.Salary = 0;
            validitor.Check(newEmployee);
            if (!validitor.IsValid())
            {
                foreach (var error in validitor.Erorrs)
                {
                    massage = string.Join(" and ", validitor.Erorrs);
                }
                MessageBox.Show(massage);
            }
            else
                repo.Add(newEmployee);
            this.EmployeeList.ItemsSource = repo.GetAll();
            First_Name.Clear();
            Last_Name.Clear();
            Salary.Clear();

        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            Employee NewInfo = new Employee();
            NewInfo.FirstName = First_Name.Text;
            NewInfo.LastName = Last_Name.Text;
            NewInfo.Salary = Convert.ToInt32(Salary.Text);
            NewInfo.StartDate = StartDate.SelectedDate.Value.Date.ToShortDateString();
            var a = (Employee)EmployeeList.SelectedItems[0];
            repo.Update(NewInfo, a.EmployeeId);
            this.EmployeeList.ItemsSource = repo.GetAll();
        }

        private void Button_Click_delete(object sender, RoutedEventArgs e)
        {
            var a = (Employee)EmployeeList.SelectedItems[0];
            repo.Delete(a.EmployeeId);
            this.EmployeeList.ItemsSource = repo.GetAll();


        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void First_Name_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}
