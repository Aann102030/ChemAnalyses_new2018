//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SA_EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class CalibrationDataView
    {
        public int IDCalibration { get; set; }
        public int IDCalibrationData { get; set; }
        public int Diapason { get; set; }
        public decimal Concentration { get; set; }
        public decimal Value { get; set; }
        public System.DateTime Date { get; set; }
        public string Comment { get; set; }
        public string CalibrationType { get; set; }
    }
}
