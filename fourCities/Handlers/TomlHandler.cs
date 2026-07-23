using fourCities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace fourCities.Handlers
{
    internal class TomlHandler
    {
        public static int GetLabelSize()
        {
            int labeledSize = TomlModel.ReadTOMLfiels<int>("LableSize");
            return labeledSize;
        }

        public static int GetTextSize()
        {
            int labeledSize = TomlModel.ReadTOMLfiels<int>("TextSize");
            return labeledSize;
        }

        public static int GetClockLabelSize()
        {
            int labeledSize = TomlModel.ReadTOMLfiels<int>("ClockLabel");
            return labeledSize;
        }

        public static int GetComboboxTextSizeSize()
        {
            int labeledSize = TomlModel.ReadTOMLfiels<int>("ComboboxTextSize");
            return labeledSize;
        }
    }
}
