using MainProject.Builders;
using MainProject.Strategies;
using MainProject.TankAttributes.Armors;
using MainProject.TankAttributes.Healths;
using MainProject.Tanks;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MainProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Team AlphaTeam;
        public Team BetaTeam;
        private Gunplay gunplay;
        public int IterationsCount { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            
            
        }
        public void ConnectItems(int ListView1ItemIndex, int ListView2ItemIndex, Brush brush, bool isLV1)
        {
            ListViewItem item1Container;
            ListViewItem item2Container;
            if (isLV1)
            {
                item1Container = LV.ItemContainerGenerator.ContainerFromIndex(ListView1ItemIndex) as ListViewItem;
                item2Container = LV2.ItemContainerGenerator.ContainerFromIndex(ListView2ItemIndex) as ListViewItem;
            }
            else
            {
                item1Container = LV2.ItemContainerGenerator.ContainerFromIndex(ListView1ItemIndex) as ListViewItem;
                item2Container = LV.ItemContainerGenerator.ContainerFromIndex(ListView2ItemIndex) as ListViewItem;

            }
            if (item1Container != null && item2Container != null)
            {
                if (!item1Container.IsLoaded)
                {
                    item1Container.Loaded += (s, e) => { DrawLine(item1Container, item2Container, brush, isLV1); };
                }

                if (!item2Container.IsLoaded)
                {
                    item2Container.Loaded += (s, e) => { DrawLine(item1Container, item2Container, brush, isLV1); };
                }

                if (item1Container.IsLoaded && item2Container.IsLoaded)
                {
                    DrawLine(item1Container, item2Container, brush, isLV1);
                }
            }
        }

        private void DrawLine(ListViewItem item1, ListViewItem item2, Brush brush, bool isLV1)
        {
            //var rootCanvas = GetRootCanvas(item1);
            if (CV != null)
            {
                double mod;
                Point item1Pos;
                Point item2Pos;
                if (isLV1)
                {
                    mod = 2;
                    item1Pos = item1.PointToScreen(new Point(item1.ActualWidth / 2, item1.ActualHeight / 2));
                    item2Pos = item2.PointToScreen(new Point(item2.ActualWidth / 2, item2.ActualHeight / 2));

                }
                else
                {
                    mod = -2;
                    item1Pos = item2.PointToScreen(new Point(item2.ActualWidth / 2, item2.ActualHeight / 2));
                    item2Pos = item1.PointToScreen(new Point(item1.ActualWidth / 2, item1.ActualHeight / 2));
                }
                Line line = new Line
                {
                    X1 = item1Pos.X+mod,// + item1.ActualWidth, // Конец первого элемента ListView1 для X1
                    Y1 = item1Pos.Y,

                    X2 = item2Pos.X+mod, // Начало второго элемента ListView2 для X2
                    Y2 = item2Pos.Y,

                    Stroke = brush,
                    StrokeThickness = 2
                };

                // Вот тут мы добавляем линию на Canvas
                CV.Children.Add(line);
            }
        }


        void DrawLines()
        {
            CV.Children.Clear();
            if (IterationsCount > 0 && AlphaTeam.Tanks.Count > 0 && BetaTeam.Tanks.Count > 0)
            {
                for (int i = 0; i < AlphaTeam.Tanks.Count; i++) //Alpha shooting
                {
                    ConnectItems(i, BetaTeam.Tanks.IndexOf(AlphaTeam.Tanks[i].SelectedTarget), new SolidColorBrush(AlphaTeam.TeamColor), true);
                }

                for (int i = 0; i < BetaTeam.Tanks.Count; i++) // Beta shooting
                {
                    ConnectItems(i, AlphaTeam.Tanks.IndexOf(BetaTeam.Tanks[i].SelectedTarget), new SolidColorBrush(BetaTeam.TeamColor), false);
                }
            }


        }
        public void FirstActions(int tankCount, int warehouseItemCount)
        {
            IterationsCount = 0;
            Warehouse warehouse = Warehouse.GetInstance();
            warehouse.Fill(warehouseItemCount);

            FillTeam(ref AlphaTeam, tankCount);
            FillTeam(ref BetaTeam, tankCount);
            AlphaTeam.TeamColor = Colors.Blue;
            BetaTeam.TeamColor = Colors.Red;
            AlphaTeam.Name = "Alpha";
            BetaTeam.Name = "Beta";
            gunplay = new Gunplay(AlphaTeam, BetaTeam);
            DisplayStrategies();
            UpdateLVs();

        }
        private void Iterate(object sender, RoutedEventArgs e)
        {
            RemoveDeads();
            Regen();
            if(AlphaTeam.Tanks.Count > 0 && BetaTeam.Tanks.Count > 0)
            {
                ShellExchange();
                IterationsCount++;
                IterationLBL.Content = IterationsCount.ToString();
                WinCheck();
            }
            UpdateLVs();
            DrawLines();

        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (TraceSwt.IsChecked == false)
            {
                //TraceSwt.Background = new SolidColorBrush(Colors.Red);
                CV.Visibility = Visibility.Collapsed;
            }
            else
            {
                //TraceSwt.Background = new SolidColorBrush(Colors.Green);
                CV.Visibility = Visibility.Visible;

            }
        }
    }
}