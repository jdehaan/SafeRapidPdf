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
using SafeRapidPdf.File;
using SafeRapidPdf.Document;

namespace PdfStructureViewer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow ()
		{
			InitializeComponent ();
		}

		private void ParseFile (String filePath)
		{
			var file = PdfFile.Parse(filePath);
			fileView.FileStructure = file;
			documentView.DocumentStructure = new PdfDocument (file);
		}

		private void Button_Click (object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();          
 
			dlg.DefaultExt = ".pdf";
			dlg.Filter = "PDF documents (.pdf)|*.pdf";
 
			Nullable<bool> result = dlg.ShowDialog();
			if (result == true)
			{
				string fullPath = dlg.FileName;
				ParseFile(fullPath);
			 }
		}

	}
}
