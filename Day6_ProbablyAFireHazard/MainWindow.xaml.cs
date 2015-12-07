#region Information

// AdventOfCode: Day6_ProbablyAFireHazard
// Created: 2015-12-07
// Modified: 2015-12-07 1:16 PM
// Last modified by: MOORE Jason (jasonmo)
#endregion

#region Using Directives
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Day6_ProbablyAFireHazard.ValueConverters;
using libChristmasLightsGrid.ViewModel;

#endregion

namespace Day6_ProbablyAFireHazard
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructors
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        private void GenerateGrid_Click(object sender, RoutedEventArgs e)
        {
            ChristmasLightsGrid dc = (ChristmasLightsGrid) DataContext;

            dc.GenerateGridCommand.Execute(null);
            for (int y = 0; y < dc.Rows; y++)
            {
                LightGrid.RowDefinitions.Add(new RowDefinition {Height = new GridLength(2)});
            }
            for (int x = 0; x < dc.Columns; x++)
            {
                LightGrid.ColumnDefinitions.Add(new ColumnDefinition {Width = new GridLength(2)});
            }
            for (int x = 0; x < dc.Columns; x++)
            {
                for (int y = 0; y < dc.Rows; y++)
                {
                    Border cell = new Border();
                    cell.SetBinding(Border.BackgroundProperty,
                                    new Binding
                                    {
                                        Path =
                                            new PropertyPath(
                                            $"Lights[{dc.Lights.FindIndex(l => l.PosX == x && l.PosY == y)}].Lit"),
                                        Source = dc,
                                        Converter = new BoolToBrushConverter(),
                                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                                        IsAsync = true
                                    });
                    Grid.SetColumn(cell, x);
                    Grid.SetRow(cell, y);
                    LightGrid.Children.Add(cell);
                }
            }
        }
    }
}