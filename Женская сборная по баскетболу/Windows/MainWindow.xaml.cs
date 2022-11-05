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
using Word = Microsoft.Office.Interop.Word;

namespace Женская_сборная_по_баскетболу.Windows
{
    /// <summary>
    /// Логика взаимодействия для Главное_окно.xaml
    /// </summary>
    public partial class Главное_окно : Window
    {
        public Главное_окно()
        {
            InitializeComponent();
        }

        private void Players_Click(object sender, RoutedEventArgs e)
        {
            Игрок window1 = new Игрок();
            window1.Show();
            this.Hide();
        }

        private void Couch_Click(object sender, RoutedEventArgs e)
        {
            Тренер window3 = new Тренер();
            window3.Show();
            this.Hide();
        }

        private void TrainingHalls_Click(object sender, RoutedEventArgs e)
        {
            Игровой_зал window5 = new Игровой_зал();
            window5.Show();
            this.Hide();
        }

        private void Doc_Click(object sender, RoutedEventArgs e)
        {
            var player = Model.BasketballClubEntities.GetContext().Player.OrderBy(x => x.FCs).ToList();
            Word.Application app = new Word.Application();
            Word.Document document = app.Documents.Add();
            int startRowIndex = 1;
            Word.Paragraph paragraph = document.Paragraphs.Add();
            Word.Range range = paragraph.Range;
            range.Text = "Список Игроков";
            paragraph.set_Style("Заголовок 1");
            range.InsertParagraphAfter();
            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table table = document.Tables.Add(tableRange, player.Count() + 1, 8);
            Word.Range cellRange;
            cellRange = table.Cell(1, 1).Range;
            cellRange.Text = "Фамилия Имя Отчество";
            cellRange = table.Cell(1, 2).Range;
            cellRange.Text = "Дата рождения";
            cellRange = table.Cell(1, 3).Range;
            cellRange.Text = "Пост";
            cellRange = table.Cell(1, 4).Range;
            cellRange.Text = "Номер";
            cellRange = table.Cell(1, 5).Range;
            cellRange.Text = "Роль";
            cellRange = table.Cell(1, 6).Range;
            cellRange.Text = "Рост";
            cellRange = table.Cell(1, 7).Range;
            cellRange.Text = "Вес";
            cellRange = table.Cell(1, 8).Range;
            cellRange.Text = "Клуб";
            startRowIndex++;
            foreach (var item in player)
            {
                cellRange = table.Cell(startRowIndex, 1).Range;
                cellRange.Text = item.FCs;
                cellRange = table.Cell(startRowIndex, 2).Range;
                cellRange.Text = item.BirthDate.ToString();
                cellRange = table.Cell(startRowIndex, 3).Range;
                cellRange.Text = item.Post;
                cellRange = table.Cell(startRowIndex, 4).Range;
                cellRange.Text = Convert.ToString(item.GameNumber);
                cellRange = table.Cell(startRowIndex, 5).Range;
                cellRange.Text = item.Role;
                cellRange = table.Cell(startRowIndex, 6).Range;
                cellRange.Text = Convert.ToString(item.Height);
                cellRange = table.Cell(startRowIndex, 7).Range;
                cellRange.Text = Convert.ToString(item.Weight);
                cellRange = table.Cell(startRowIndex, 8).Range;
                cellRange.Text = Convert.ToString(item.Club.Name);
                startRowIndex++;
            }
            app.Visible = true;
            document.SaveAs2(@"C:\Users\User\OneDrive\Рабочий стол\Практика окт-нояб\document.docx");
            document.SaveAs2(@"C:\Users\User\OneDrive\Рабочий стол\Практика окт-нояб\document.pdf", Word.WdExportFormat.wdExportFormatPDF);

        }
    }
}
