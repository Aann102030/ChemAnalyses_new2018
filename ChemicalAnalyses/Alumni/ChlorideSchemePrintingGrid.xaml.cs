﻿using System.Collections.Generic;
using System.Windows.Controls;
using SaltAnalysisDatas;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace ChemicalAnalyses.Alumni
{
    public partial class ChlorideSchemePrintingGrid : UserControl, INotifyPropertyChanged
    {
        public List<SaltAnalysisData> lSA { get; set; }
       
        public ChlorideSchemePrintingGrid(List<SaltAnalysisData> lsa)
        {
            InitializeComponent();
            lSA = lsa;
            DataContext = this;
        }
        //Autonumbering
        private void dgrdMain_LoadingRow(object sender, DataGridRowEventArgs e)
        {e.Row.Header = (e.Row.GetIndex() + 1).ToString();}

        private bool _showHygroscopicWaterFroAll = true;
        public bool ShowHygroscopicWaterFroAll
        {
            get { return _showHygroscopicWaterFroAll; }
            set { _showHygroscopicWaterFroAll = value;
                OnPropertyChanged(nameof(ShowHygroscopicWaterFroAll));
            }}

        private bool _useBKRespresentationVariant = true;
        public bool UseBKRespresentationVariant
        {
            get { return _useBKRespresentationVariant; }
            set { _useBKRespresentationVariant = value;
                OnPropertyChanged(nameof(UseBKRespresentationVariant));
            }}
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}