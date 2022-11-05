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
    /// Логика взаимодействия для AddAndEditWindow.xaml
    /// </summary>
    public partial class AddAndEditWindow : Window
    {
        
        private Model.Player _player = new Model.Player();
        public AddAndEditWindow(Model.Player player)
        {
            InitializeComponent();
            if (player != null)
            {
                _player = player;
            }
            DataContext = _player;
            ClubBox.ItemsSource = Model.BasketballClubEntities.GetContext().Club.ToList();

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            
            if (string.IsNullOrEmpty(_player.FCs))
            {
                error.AppendLine("Пожалуйста, введите ФИО.");
            }
            if (_player.BirthDate.Year > 2000)
            {
                error.AppendLine("Извините, Ваш возраст не подходит под отбор.");
            }
            if (string.IsNullOrEmpty(_player.Post))
            {
                error.AppendLine("Пожалуйста введите разряд.");
            }
            if (_player.GameNumber < 0 && _player.GameNumber > 99)
            {
                error.AppendLine("Введите корректный игровой номер.");
            }
            if (string.IsNullOrEmpty(_player.Role))
            {
                error.AppendLine("Пожалуйста, укажите свою позицию.");
            }
            if(_player.Weight < 50)
            {
                error.AppendLine("Ваш вес не подходит под параметры");
            }
            if(_player.Height < 160)
            {
                error.AppendLine("Ваш рост не подходит под параметры.");
            }
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
            }
            if (_player.Id == 0)
            {
                Model.BasketballClubEntities.GetContext().Player.Add(_player);
            }


            try
            {
            Model.BasketballClubEntities.GetContext().SaveChanges();
            MessageBox.Show("Данные успешно сохранены!");
            Игрок player1 = new Игрок();
            player1.Show();
            this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
