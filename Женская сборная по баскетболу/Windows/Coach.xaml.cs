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
    /// Логика взаимодействия для Тренер.xaml
    /// </summary>
    public partial class Тренер : Window
    {
        
        public Тренер()
        {
            InitializeComponent();
            CoachModel.ItemsSource = Model.BasketballClubEntities.GetContext().Coach.OrderBy(x => x.FCs).ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Главное_окно window2 = new Главное_окно();
            window2.Show();
            this.Hide();
        }
    }
}
