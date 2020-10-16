using NetworkAPIViewer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotCell.ViewModels.Sheets
{
    class CellViewModel : BaseViewModel
    {
		private object _cellContent;
		public object CellContent
		{
			get { return _cellContent; }
			set 
			{ 
				_cellContent = value;
				RaisePropertyChanged(nameof(CellContent));
			}
		}

	}
}
