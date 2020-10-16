using dotCell.Views.Sheets;
using NetworkAPIViewer.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace dotCell.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        private Grid _cellGrid;
        public Grid CellGrid
        {
            get { return _cellGrid; }
            set 
            {
                _cellGrid = value;
                RaisePropertyChanged(nameof(CellGrid));
            }
        }

        private CellView[,] _cells;
        public CellView[,] Cells
        {
            get { return _cells; }
            set 
            {
                _cells = value;
                RaisePropertyChanged(nameof(Cells));
            }
        }


        public MainWindowViewModel()
        {
            Debug.WriteLine("MainWindowViewModel Created...");

            CellGrid = new Grid();
            Cells = new CellView[10, 10];

            int gridHeight = 0;
            int gridWidth = 0;

            GridLengthConverter gridLengthConverter = new GridLengthConverter();
            GridLength rowHeight = (GridLength)gridLengthConverter.ConvertFrom(20);
            GridLength columnWidth = (GridLength)gridLengthConverter.ConvertFrom(64);
            RowDefinition rowDefinition;
            ColumnDefinition columnDefinition;

            for (int row=0; row < 10; ++row)
            {
                rowDefinition = new RowDefinition();
                rowDefinition.Height = rowHeight;
                gridHeight += 20;
                CellGrid.RowDefinitions.Add(rowDefinition);                
            }
            for (int column = 0; column < 10; ++column)
            {
                columnDefinition = new ColumnDefinition();
                columnDefinition.Width = columnWidth;
                gridWidth += 64;
                CellGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int row = 0; row < 10; ++row)
            {
                for (int column = 0; column < 10; ++column)
                {
                    Cells[row, column] = new CellView();
                    Cells[row, column].Height = 20;
                    Cells[row, column].Width = 64;

                    Grid.SetRow(Cells[row, column], row);
                    Grid.SetColumn(Cells[row, column], column);
                    CellGrid.Children.Add(Cells[row, column]);
                }
            }

            CellGrid.Height = (double)gridHeight;
            CellGrid.Width = (double)gridWidth;
        }
    }
}
