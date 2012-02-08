﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SafeRapidPdf.File
{
	public class PdfTrailer : PdfDictionary
	{
		private PdfTrailer(PdfDictionary dictionary)
			: base(dictionary, PdfObjectType.Trailer)
		{
		}

		public new static PdfTrailer Parse(Lexical.ILexer lexer)
		{
			lexer.Expects("trailer");
			var dictionary = PdfDictionary.Parse(lexer);
			return new PdfTrailer(dictionary);
		}

		public override string ToString()
		{
			return "trailer";
		}
	}
}
