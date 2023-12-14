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

namespace PersonHeapSort {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private Person[] persons = new Person[] {
            new Person() { FirstName = "Александр", LastName = "Пушкин"},
            new Person() { FirstName = "Николай", LastName = "Гоголь"},
            new Person() { FirstName = "Лев", LastName = "Толстой"}
        };

        public MainWindow() {
            InitializeComponent();

            dataGrid.ItemsSource = persons;
        }

        private void AskButtonClick(object sender, RoutedEventArgs e) {
            dataGrid.ItemsSource = Sort(persons, true);
        }

        private void DeskButtonClick(object sender, RoutedEventArgs e) {
            dataGrid.ItemsSource = Sort(persons, false);
        }

        private Person[] Sort(Person[] array, bool isAsk) {

            IOrderedEnumerable<Person> result = null;

            if (isAsk) {
                result = array.OrderBy(p => p.FirstName);
            } else {
                result = array.OrderByDescending(p => p.FirstName);
            }

            return result.ToArray();
        }
    }
}
