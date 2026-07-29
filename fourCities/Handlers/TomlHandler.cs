using fourCities.Model;

namespace fourCities.Handlers
{
    internal class TomlHandler
    {
        public static int GetLabelSize()
        {
            int labeledSize = TomlModel.ReadTOMLfields<int>("LableSize");
            return labeledSize;
        }

        public static int GetTextSize()
        {
            int labeledSize = TomlModel.ReadTOMLfields<int>("TextSize");
            return labeledSize;
        }

        public static int GetClockLabelSize()
        {
            int labeledSize = TomlModel.ReadTOMLfields<int>("ClockLabel");
            return labeledSize;
        }

        public static int GetComboboxTextSizeSize()
        {
            int labeledSize = TomlModel.ReadTOMLfields<int>("ComboboxTextSize");
            return labeledSize;
        }

        public static void UpdateTomlField(string fieldToUpdate, int value)
        {
            TomlModel.UpdateTOMLFileFieldInt(fieldToUpdate, value);
        }

        public static void UpdateTomlField(string fieldToUpdate, string value)
        {
            TomlModel.UpdateTOMLFileFieldString(fieldToUpdate, value);
        }

        public static string ReadTomlField(string tomlFieldToRead)
        {
            return TomlModel.ReadTOMLfields<string>(tomlFieldToRead);
        }
    }
}
