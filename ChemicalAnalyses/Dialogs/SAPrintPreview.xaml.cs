﻿using System.Windows;
using System.Windows.Documents;

namespace ChemicalAnalyses.Dialogs
{
    public partial class SAPrintPreview : Window
    {
        public SAPrintPreview()
        {
            InitializeComponent();
            fdSA.DocumentPaginator.PageSize = new Size(1056, 816);
        }

        public IDocumentPaginatorSource Document
        {
            get { return dvSAView.Document; }
            set { dvSAView.Document = value; }
        }
    }
}