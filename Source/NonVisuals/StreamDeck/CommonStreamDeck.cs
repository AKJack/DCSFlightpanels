﻿using System;
using System.Drawing;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ClassLibraryCommon;

namespace NonVisuals.StreamDeck
{
    public static class CommonStreamDeck
    {
        public static BitmapImage ConvertBitMap(Bitmap bitmap)
        {
            try
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                    memory.Position = 0;
                    BitmapImage bitmapimage = new BitmapImage();
                    bitmapimage.BeginInit();
                    bitmapimage.StreamSource = memory;
                    bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapimage.EndInit();

                    return bitmapimage;
                }
            }
            catch (Exception e)
            {
                Common.LogError(e, "Failed to convert bitmap to bitmapimage.");
            }
            return null;
        }


        public static EnumComparator ComparatorValue(string text)
        {
            if (text == "==")
            {
                return EnumComparator.Equals;
            }
            if (text == "!=")
            {
                return EnumComparator.NotEquals;
            }
            if (text == "<")
            {
                return EnumComparator.LessThan;
            }
            if (text == "<=")
            {
                return EnumComparator.LessThanEqual;
            }
            if (text == ">")
            {
                return EnumComparator.GreaterThan;
            }
            if (text == ">=")
            {
                return EnumComparator.GreaterThanEqual;
            }
            if (text == "Always")
            {
                return EnumComparator.Always;
            }
            throw new Exception("Failed to decode comparison type.");
        }

        public static void SetComparatorValue(ComboBox comboBox, EnumComparator comparator)
        {
            switch (comparator)
            {
                case EnumComparator.Equals:
                    {
                        comboBox.Text = "==";
                        break;
                    }
                case EnumComparator.NotEquals:
                    {
                        comboBox.Text = "!=";
                        break;
                    }
                case EnumComparator.LessThan:
                    {
                        comboBox.Text = "<";
                        break;
                    }
                case EnumComparator.LessThanEqual:
                    {
                        comboBox.Text = "<=";
                        break;
                    }
                case EnumComparator.GreaterThan:
                    {
                        comboBox.Text = ">";
                        break;
                    }
                case EnumComparator.GreaterThanEqual:
                    {
                        comboBox.Text = ">=";
                        break;
                    }
                case EnumComparator.Always:
                    {
                        comboBox.Text = "Always";
                        break;
                    }
                default:
                    {
                        throw new Exception("Failed to decode comparison type.");
                    }
            }
        }

    }
}
