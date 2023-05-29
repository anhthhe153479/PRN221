using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace DemoUI2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var converter = new BrushConverter();
            ObservableCollection<Member> members= new ObservableCollection<Member>();

            //Create DataGrid item infork
            members.Add(new Member { Number = "1", Character = "A", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh1", Position="s",Email="ss",Phone="ss" });
            members.Add(new Member { Number = "2", Character = "B", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Huy anh2", Position="ss",Email="ss",Phone="ss" });
            members.Add(new Member { Number = "3", Character = "C", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh3", Position="sss",Email="ss",Phone="ss" });
            members.Add(new Member { Number = "4", Character = "D", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh4", Position="s",Email="ss",Phone="ss" });
            members.Add(new Member { Number = "5", Character = "E", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh5", Position="ss",Email="ss",Phone="ss" });
            members.Add(new Member { Number = "6", Character = "G", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh6", Position="sss",Email="ss",Phone="ss" });
            members.Add(new Member { Number = "7", Character = "H", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh7", Position="s",Email="ss",Phone="ss" });
            members.Add(new Member { Number = "8", Character = "I", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh8", Position="s",Email="ss",Phone="ss" });
            members.Add(new Member { Number = "9", Character = "K", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh9", Position="sss",Email="ss",Phone="ss" });

            members.Add(new Member { Number = "1", Character = "A", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh1", Position = "s", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "2", Character = "B", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Huy anh2", Position = "ss", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "3", Character = "C", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh3", Position = "sss", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "4", Character = "D", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh4", Position = "s", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "5", Character = "E", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh5", Position = "ss", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "6", Character = "G", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh6", Position = "sss", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "7", Character = "H", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh7", Position = "s", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "8", Character = "I", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh8", Position = "s", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "9", Character = "K", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh9", Position = "sss", Email = "ss", Phone = "ss" });

            members.Add(new Member { Number = "1", Character = "A", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh1", Position = "s", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "2", Character = "B", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Huy anh2", Position = "ss", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "3", Character = "C", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh3", Position = "sss", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "4", Character = "D", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh4", Position = "s", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "5", Character = "E", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh5", Position = "ss", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "6", Character = "G", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh6", Position = "sss", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "7", Character = "H", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh7", Position = "s", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "8", Character = "I", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh8", Position = "s", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "9", Character = "K", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh9", Position = "sss", Email = "ss", Phone = "ss" });

            members.Add(new Member { Number = "1", Character = "A", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh1", Position = "s", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "2", Character = "B", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Huy anh2", Position = "ss", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "3", Character = "C", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh3", Position = "sss", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "4", Character = "D", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh4", Position = "s", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "5", Character = "E", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh5", Position = "ss", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "6", Character = "G", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh6", Position = "sss", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "7", Character = "H", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh7", Position = "s", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "8", Character = "I", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh8", Position = "s", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "9", Character = "K", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh9", Position = "sss", Email = "ss", Phone = "ss" });

            members.Add(new Member { Number = "1", Character = "A", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh1", Position = "s", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "2", Character = "B", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Huy anh2", Position = "ss", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "3", Character = "C", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh3", Position = "sss", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "4", Character = "D", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh4", Position = "s", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "5", Character = "E", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh5", Position = "ss", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "6", Character = "G", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh6", Position = "sss", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "7", Character = "H", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh7", Position = "s", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "8", Character = "I", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh8", Position = "s", Email = "ss", Phone = "ss" });
            members.Add(new Member { Number = "9", Character = "K", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Huy anh9", Position = "sss", Email = "ss", Phone = "ss" });


            membersDataGrid.ItemsSource = members;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton ==MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;
                    IsMaximized= false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaximized= true;
                }
            }
        }
    }
}
