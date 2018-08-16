﻿using System.Collections.Generic;

using SafeRapidPdf.Objects;

namespace SafeRapidPdf.Document
{
    public sealed class PdfCatalog : PdfBaseObject
    {
        private readonly List<IPdfObject> _items = new List<IPdfObject>();

        public PdfCatalog(PdfDictionary catalog)
            : base(PdfObjectType.Catalog)
        {
            IsContainer = true;
            catalog.ExpectsType("Catalog");

            foreach (PdfKeyValuePair pair in catalog.Items)
            {
                switch (pair.Key.Text)
                {
                    case "Type": // skip Type Catalog
                        break;
                    case "Pages":
                        Pages = new PdfPageTree(catalog["Pages"] as PdfIndirectReference);
                        break;
                    default:
                        _items.Add(pair);
                        break;
                }
            }
        }

        public PdfPageTree Pages { get; }

        public override IReadOnlyList<IPdfObject> Items
        {
            get
            {
                var list = new List<IPdfObject>(_items.Count + 1);
                list.AddRange(_items);
                list.Add(Pages);
                return list;
            }
        }

        public override string ToString() => "/";
    }
}