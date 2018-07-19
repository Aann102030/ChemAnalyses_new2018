﻿using System;
using System.Globalization;
using System.Windows.Data;
using SA_EF;
using System.Windows;
using System.Linq;

namespace ChemicalAnalyses.Alumni
{
    public class StringToBooleanConverter : IValueConverter
    {
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Backward conversion is not possible");
        }

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if ((string)value == "Not filtered") return false;
            return true;
        }
    }

    public class SampleAvConverter : IMultiValueConverter
    {
        object IMultiValueConverter.Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string labnm;
            string descr;
            DateTime smplDate;
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            
            try
            {
                labnm = values[0].ToString().Trim();
                smplDate = DateTime.Parse(values[1].ToString());
                descr = values[2].ToString().Trim();
                Sample smpl = new Sample
                {
                    IDSample =1, //Dummy just to test the other fields
                    LabNumber = labnm,
                    SamplingDate = smplDate,
                    Description = descr
                };
                return true;
            }
            catch { return false; }
        }

        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Обратная конвертация невозможна!");
        }
    }

    [ValueConversion(typeof(string), typeof(double?))]
    public class StringToNullableDoubleConverter : IValueConverter
    {
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            double d;
            object o;
            string sep = culture.NumberFormat.NumberDecimalSeparator;
            if (value.ToString().Trim() == "") return null;
            try
            {
                d = double.Parse(value.ToString());
                return o = d;
            }
            catch
            {
                return null;
            }
        }

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value == null) return "";
            return value.ToString();
        }
    }

    [ValueConversion(typeof(decimal), typeof(decimal))]
    public class DoubleToPercentageConverter : IValueConverter
    {
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Backward conversion is not possible");
        }

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value is null) return null;
            return (decimal)value * 100;
        }
    }

    public class DecimalsToSumConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null) return null;
            decimal res = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] != null)
                {
                    try
                    {
                        res += (decimal)values[i];
                    }
                    catch { }
                }
            }
            return res * 100;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Backward conversion is not possible");
        }
    }

    /// <summary>
    /// Check if all arguments are of the same value
    /// first stands for the current scheme and the following represent
    /// those schemes where the column shall be visible
    /// </summary>
    public class SchemeTypeToVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null) return Visibility.Hidden;
            if (values.Any(p => p.GetType() != typeof(SaltCalculationSchemes))) return Visibility.Hidden;
            if (values.All(p => ((SaltCalculationSchemes)values.First())
                .Equals((SaltCalculationSchemes)p))) return Visibility.Visible;
            else return Visibility.Hidden;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Backward conversion is not possible");
        }
    }

    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value != null && (Visibility)value == Visibility.Visible) return true;
            else return false;
        }

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value is null) return Visibility.Hidden;
            return ((bool)value) ? (Visibility.Visible) : (Visibility.Collapsed);
        }
    }

    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BooleanToVisibilityNegativeConverter : IValueConverter
    {
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value == null || (Visibility)value != Visibility.Visible) return true;
            else return false;
        }

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value is null || !(bool)value) return Visibility.Visible;
            else return Visibility.Collapsed;
        }
    }
}