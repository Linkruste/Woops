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

namespace Woops
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            GC.KeepAlive(this);
            GC.SuppressFinalize(this);
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            InitializeComponent();
            Random rd = new Random();
            Label lbl1 = new Label();
            Grid grid = new Grid();

            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            lbl1.Content = "Woops, guess you're an idiot";
            lbl1.PreviewMouseRightButtonDown += (sender, e) => {
                System.Diagnostics.Process thisproc = System.Diagnostics.Process.GetCurrentProcess(); ;
                thisproc.Kill();
            };
            lbl1.FontSize = 25;

            Grid.SetRow(lbl1, 0);

            grid.Children.Add(lbl1);
            int _case = rd.Next(0,10);
            if (_case==9)
            {
                System.Diagnostics.Process p = System.Diagnostics.Process.GetCurrentProcess();
                Label lbl = new Label();
                if (rd.Next(0,5)==4)
                {
                    Button btn = new Button();
                    btn.Content = "Auto crash boiii !";
                    btn.Click += (sender, e) => {
                        for (int i = 0; i < 50; i++) //Adds 50 other windows
                        {
                            MainWindow win = new MainWindow();
                            win.Show();
                            win.Activate();
                            btn.IsEnabled = false;
                        }
                    };
                    Grid.SetRow(btn, 2);
                    grid.Children.Add(btn);
                }
                lbl.Content = $"Ram consumed: {p.PrivateMemorySize64}.  Hold on !";
                Grid.SetRow(lbl, 1);
                grid.Children.Add(lbl);
                
            }
            this.AddChild(grid);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            MainWindow win = new MainWindow();
            win.Show();
            win.Activate();
        }
    }
}
