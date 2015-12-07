#region Information

// AdventOfCode: Day6_ProbablyAFireHazard
// Created: 2015-12-07
// Modified: 2015-12-07 1:02 PM
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
                LightGrid.RowDefinitions.Add(new RowDefinition());
            }
            for (int x = 0; x < dc.Columns; x++)
            {
                LightGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int x = 0; x < dc.Columns; x++)
            {
                for (int y = 0; y < dc.Rows; y++)
                {
                    TextBlock cell = new TextBlock();
                    cell.SetBinding(TextBlock.TextProperty,
                                    new Binding
                                    {
                                        Path =
                                            new PropertyPath(
                                            $"Lights[{dc.Lights.FindIndex(l => l.PosX == x && l.PosY == y)}].Lit"),
                                        Source = dc,
                                        Converter = new BoolToStringConverter(),
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