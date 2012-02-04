using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SafeRapidPdf.Primitives
{

	/// <summary>
	/// Immutable type
	/// </summary>
    public class PdfIndirectReference : PdfObject
    {
        public PdfIndirectReference(int objectNumber, int generationNumber, IIndirectReferenceResolver resolver)
        {
			IsContainer = true;

			ObjectNumber = objectNumber;
			GenerationNumber = generationNumber;
			_resolver = resolver;
		}

		public static PdfIndirectReference Parse(Lexical.ILexer lexer, IIndirectReferenceResolver resolver)
        {
			int objectNumber = int.Parse(lexer.ReadToken());
			int generationNumber = int.Parse(lexer.ReadToken());
			lexer.Expects("R");
			return new PdfIndirectReference(objectNumber, generationNumber, resolver);
		}

		public int ObjectNumber { get; private set; }

        public int GenerationNumber { get; private set; }

		private IIndirectReferenceResolver _resolver;
		public PdfIndirectObject ReferencedObject
		{
			get
			{
				return _resolver.GetObject(ObjectNumber, GenerationNumber);
			}
		}

		public override ReadOnlyCollection<IPdfObject> Items
		{
			get
			{
				var list = new List<IPdfObject>();
				list.Add(ReferencedObject.Object);
				return list.AsReadOnly();
			}
		}

		public override string ToString()
		{
			return String.Format("{0} {1} R", ObjectNumber, GenerationNumber);
		}
	}
}
