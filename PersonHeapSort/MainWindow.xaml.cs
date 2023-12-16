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
            new Person() { FirstName = "Николай", LastName = "Островский"},
            new Person() { FirstName = "Александр", LastName = "Островский"},
            new Person() { FirstName = "Николай", LastName = "Гоголь"},
            new Person() { FirstName = "Лев", LastName = "Толстой"}
        };

        private HeapSort heapSort;

        public MainWindow() {
            InitializeComponent();

            heapSort = new HeapSort();
            //heapSort.Sort(persons);

            dataGrid.ItemsSource = persons;
        }

        private void AskButtonClick(object sender, RoutedEventArgs e) {
            heapSort.OrderBy(persons);
            CollectionViewSource.GetDefaultView(dataGrid.ItemsSource).Refresh();
        }

        private void DeskButtonClick(object sender, RoutedEventArgs e) {
            heapSort.OrderByDescending(persons);
            CollectionViewSource.GetDefaultView(dataGrid.ItemsSource).Refresh();
        }
    }
}
