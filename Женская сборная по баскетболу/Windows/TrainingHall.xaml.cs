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
    /// Логика взаимодействия для Игровой_зал.xaml
    /// </summary>
    public partial class Игровой_зал : Window
    {
        
        public Игровой_зал()
        {
            InitializeComponent();
            TrainingHallModel.ItemsSource = Model.BasketballClubEntities.GetContext().TrainingHall.OrderBy(x => x.Name).ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Главное_окно window3 = new Главное_окно();
            window3.Show();
            this.Hide();
        }
    }
}
