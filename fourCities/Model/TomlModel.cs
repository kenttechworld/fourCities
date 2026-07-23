using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Tommy;
using System.Text;
using System.Xml;

namespace fourCities.Model
{
    internal class TomlModel
    {
        private static TomlTable? toml;
        private static string tomlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "Config.toml");

        public static void MakeTOMLFile()
        {
            //  the root TOML table
            TomlTable toml = new TomlTable
            {
                // Simple key-value pairs
                ["LableSize"] = 18,
                ["TextSize"] = 50,
                ["ClockLabel"] = 50,
                ["ComboboxTextSize"] = 18,
            };

            string filePath = tomlPath;

            // Write the TOML table to a file
            using (StreamWriter writer = File.CreateText(filePath))
            {
                toml.WriteTo(writer);
                writer.Flush();
            }

            //Debug.WriteLine($"TOML file successfully created");
        }

        

        public static bool CheckIfTOMLFileExist()
        {
            return Path.Exists(tomlPath);
        }

        public static T ReadTOMLfiels<T>(string TOMLFieldToGetDataFrom)
        {
            if (!CheckIfTOMLFileExist())
            {
                throw new FileNotFoundException("TOML configuration file not found.");
            }

            LoadeConfigFile();

            if (!toml.HasKey(TOMLFieldToGetDataFrom))
            {
                throw new KeyNotFoundException($"The key '{TOMLFieldToGetDataFrom}' was not found.");
            }

            TomlNode node = toml[TOMLFieldToGetDataFrom];

            if (typeof(T) == typeof(string))
            {
                return (T)(object)node.AsString.Value;
            }
            if (typeof(T) == typeof(int))
            {
                return (T)(object)(int)node.AsInteger.Value;
            }
            if (typeof(T) == typeof(bool))
            {
                return (T)(object)node.AsBoolean.Value;
            }

            throw new NotSupportedException($"The type {typeof(T).Name} is not supported by this method.");
        }

        private static void LoadeConfigFile()
        {
            // 1. Read the flat TOML file
            using StreamReader reader = File.OpenText(tomlPath);
            toml = TOML.Parse(reader);
        }
    }
}

