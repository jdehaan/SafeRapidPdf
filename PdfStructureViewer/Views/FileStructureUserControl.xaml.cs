﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using SafeRapidPdf;
using SafeRapidPdf.Pdf;

namespace PdfStructureViewer.Views
{
	/// <summary>
	/// Interaction logic for FileStructureUserControl.xaml
	/// </summary>
	public partial class FileStructureUserControl : UserControl
	{
		public FileStructureUserControl()
		{
			InitializeComponent();
		}

		private PdfFile _file;
		public PdfFile FileStructure 
		{
			get { return _file; }
			set { _file = value; RefreshControl(); }
		}

		private void RefreshControl()
		{
			treeView.ItemsSource = _file.Items;
		}
	}
}