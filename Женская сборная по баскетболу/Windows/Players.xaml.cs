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
using System.Windows.Shapes;


namespace Женская_сборная_по_баскетболу.Windows
{
    /// <summary>
    /// Логика взаимодействия для Игрок.xaml
    /// </summary>
    public partial class Игрок : Window
    {
        public Игрок()
        {
            InitializeComponent();
            Players.ItemsSource =Model.BasketballClubEntities.GetContext().Player.OrderBy(x => x.FCs).ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Главное_окно window2 = new Главное_окно();
            window2.Show();
            this.Hide();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            AddAndEditWindow window6 = new AddAndEditWindow((sender as Button).DataContext as Model.Player);
            window6.Show();
            this.Hide();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddAndEditWindow window6 = new AddAndEditWindow(null);
            window6.Show();
            this.Hide();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var deleteData = Players.SelectedItems.Cast<Model.Player>().ToList();
            if (MessageBox.Show($"Вы уверены в том, что хотите удалить {deleteData.Count()} элемент(-а / -ов)?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Model.BasketballClubEntities.GetContext().Player.RemoveRange(deleteData);
                Model.BasketballClubEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация удалена успешно", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                Players.ItemsSource = Model.BasketballClubEntities.GetContext().Player.OrderBy(x => x.FCs).ToList();
            }
        }

        private void BtnUp_Click(object sender, RoutedEventArgs e)
        {
           
            Players.ItemsSource = Model.BasketballClubEntities.GetContext().Player.OrderBy(x => x.FCs).ToList();
            
        }
    }
}
