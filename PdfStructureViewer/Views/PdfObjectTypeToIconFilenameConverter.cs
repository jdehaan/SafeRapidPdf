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
	[ValueConversion(typeof(PdfObjectType), typeof(string))]
	public class PdfObjectTypeToIconFilenameConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return "/WPFApplication;component/Images/folder.png";
			//return "Images/folder.png";
			//return Enum.GetName(typeof(PdfObjectType), value) + ".png";
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
