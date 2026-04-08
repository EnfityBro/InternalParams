using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

/// <summary>
/// InternalParams is a class that saves game settings and values as key-value pairs.
/// It can store string, integer, float, boolean and Vector3 values in the special file in the project folder.
/// </summary>
public static class InternalParams
{
    #region Properties, Fields And Enumerations

    /// <summary>
    /// The name of the save file in which the key-value pairs are stored.
    /// </summary>
    public static string SaveFileName { get; private set; } =
        (Application.platform == RuntimePlatform.Android)
        ? $"{Application.persistentDataPath}/InternalParams.enfity"
        : "InternalParams.enfity";

    /// <summary>
    /// The separator that separates the data in the key-value pairs in the save file.
    /// </summary>
    private const string separator = "|~-~|";

    /// <summary>
    /// Contains the data types for private methods parameters.
    /// </summary>
    private enum DataTypes
    {
        String,
        Int,
        Float,
        Bool,
        Vector3
    }

    #endregion


    #region String Methods

    /// <summary>
    /// Sets a string value identified by the given key.
    /// </summary>
    public static void SetString(string key, string value) => SetValue(key, value);

    /// <summary>
    /// Returns the string value corresponding to key if it exists. 
    /// If it does not exist, it creates key-value pair and returns empty string.
    /// </summary>
    public static string GetString(string key) => (string)GetValue(key, DataTypes.String);

    /// <summary>
    /// Returns true if the given key with string value exists, otherwise returns false.
    /// </summary>
    public static bool HasKeyString(string key) => HasKeyByType(key, DataTypes.String);

    /// <summary>
    /// Removes the given key with string value. 
    /// If no such key exists, DeleteKeyString has no impact.
    /// </summary>
    public static void DeleteKeyString(string key) => DeleteKeyByType(key, DataTypes.String);

    #endregion


    #region Int Methods

    /// <summary>
    /// Sets an integer value identified by the given key.
    /// </summary>
    public static void SetInt(string key, int value) => SetValue(key, value);

    /// <summary>
    /// Returns the integer value corresponding to key if it exists. 
    /// If it does not exist, it creates key-value pair and returns 0.
    /// </summary>
    public static int GetInt(string key) => (int)GetValue(key, DataTypes.Int);

    /// <summary>
    /// Returns true if the given key with integer value exists, otherwise returns false.
    /// </summary>
    public static bool HasKeyInt(string key) => HasKeyByType(key, DataTypes.Int);

    /// <summary>
    /// Removes the given key with integer value. 
    /// If no such key exists, DeleteKeyInt has no impact.
    /// </summary>
    public static void DeleteKeyInt(string key) => DeleteKeyByType(key, DataTypes.Int);

    #endregion


    #region Float Methods

    /// <summary>
    /// Sets a float value identified by the given key.
    /// </summary>
    public static void SetFloat(string key, float value) => SetValue(key, value);

    /// <summary>
    /// Returns the float value corresponding to key if it exists. 
    /// If it does not exist, it creates key-value pair and returns 0.0f.
    /// </summary>
    public static float GetFloat(string key) => (float)GetValue(key, DataTypes.Float);

    /// <summary>
    /// Returns true if the given key with float value exists, otherwise returns false.
    /// </summary>
    public static bool HasKeyFloat(string key) => HasKeyByType(key, DataTypes.Float);

    /// <summary>
    /// Removes the given key with float value. 
    /// If no such key exists, DeleteKeyFloat has no impact.
    /// </summary>
    public static void DeleteKeyFloat(string key) => DeleteKeyByType(key, DataTypes.Float);

    #endregion


    #region Bool Methods

    /// <summary>
    /// Sets a boolean value identified by the given key.
    /// </summary>
    public static void SetBool(string key, bool value) => SetValue(key, value);

    /// <summary>
    /// Returns the boolean value corresponding to key if it exists. 
    /// If it does not exist, it creates key-value pair and returns false.
    /// </summary>
    public static bool GetBool(string key) => (bool)GetValue(key, DataTypes.Bool);

    /// <summary>
    /// Returns true if the given key with boolean value exists, otherwise returns false.
    /// </summary>
    public static bool HasKeyBool(string key) => HasKeyByType(key, DataTypes.Bool);

    /// <summary>
    /// Removes the given key with boolean value. 
    /// If no such key exists, DeleteKeyBool has no impact.
    /// </summary>
    public static void DeleteKeyBool(string key) => DeleteKeyByType(key, DataTypes.Bool);

    #endregion


    #region Vector3 Methods

    /// <summary>
    /// Sets a Vector3 value identified by the given key.
    /// </summary>
    public static void SetVector3(string key, Vector3 value) => SetValue(key, value);

    /// <summary>
    /// Returns the Vector3 value corresponding to key if it exists. 
    /// If it does not exist, it creates key-value pair and returns Vector3.zero.
    /// </summary>
    public static Vector3 GetVector3(string key) => (Vector3)GetValue(key, DataTypes.Vector3);

    /// <summary>
    /// Returns true if the given key with Vector3 value exists, otherwise returns false.
    /// </summary>
    public static bool HasKeyVector3(string key) => HasKeyByType(key, DataTypes.Vector3);

    /// <summary>
    /// Removes the given key with Vector3 value.
    /// If no such key exists, DeleteKeyVector3 has no impact.
    /// </summary>
    public static void DeleteKeyVector3(string key) => DeleteKeyByType(key, DataTypes.Vector3);

    #endregion


    #region Public Methods

    /// <summary>
    /// Deletes all existing keys and values. 
    /// If there are no key-value pairs, then DeleteAll will has no impact.
    /// </summary>
    public static void DeleteAll()
    {
        using (FileStream file = new FileStream(SaveFileName, FileMode.OpenOrCreate, FileAccess.Write))
        {
            file.SetLength(0);
        }
    }

    /// <summary>
    /// Deletes all existing key-value pairs with the given key. 
    /// If there are no such keys it has no impact.
    /// </summary>
    public static void DeleteAllKeys(string key)
    {
        CheckOrCreateSaveFile();

        try
        {
            List<string> lines = File.ReadAllLines(SaveFileName).ToList();

            for (int i = lines.Count - 1; i >= 0; i--)
            {
                if (lines[i].Split(separator)[1] == key)
                    lines.RemoveAt(i);
            }

            File.WriteAllLines(SaveFileName, lines);
        }
        catch (IndexOutOfRangeException) { }
    }

    /// <summary>
    /// Returns true if the given key exists, otherwise returns false.
    /// </summary>
    public static bool HasKey(string key)
    {
        CheckOrCreateSaveFile();

        try
        {
            List<string> lines = File.ReadAllLines(SaveFileName).ToList();

            foreach (string line in lines)
            {
                if (line.Split(separator)[1] == key)
                    return true;
            }
        }
        catch (IndexOutOfRangeException) { }

        return false;
    }

    /// <summary>
    /// Returns the number of all existing key-value pairs.
    /// </summary>
    public static int PairsCount()
    {
        CheckOrCreateSaveFile();

        int count = 0;

        try
        {
            List<string> lines = File.ReadAllLines(SaveFileName).ToList();

            foreach (string line in lines)
            {
                if (!IsPairCorrupted(line.Split(separator)))
                    count++;
            }
        }
        catch (IndexOutOfRangeException) { }

        return count;
    }

    /// <summary>
    /// Sets the save file name in which the key-value pairs will be saved.
    /// Sets the name only for subsequent calls, useful when working with multiple save files.
    /// Default save file name is InternalParams.enfity.
    /// </summary>
    public static void SetSaveFileName(string newSaveFileName)
    {
        SaveFileName = (Application.platform == RuntimePlatform.Android)
            ? $"{Application.persistentDataPath}/{newSaveFileName}"
            : newSaveFileName;
    }

    /// <summary>
    /// Returns a list with all key-value pairs stored in the save file.
    /// If there are no key-value pairs, it returns an empty list.
    /// </summary>
    /// <returns>A List with elements that consist of a Dictionary with a string key and a value with object data type.</returns>
    public static List<Dictionary<string, object>> GetAllKeyValuePairs()
    {
        CheckOrCreateSaveFile();

        List<Dictionary<string, object>> keyValuePairs = new List<Dictionary<string, object>>();

        if (PairsCount() == 0)
            return keyValuePairs;

        List<string> lines = File.ReadAllLines(SaveFileName).ToList();

        foreach (string line in lines)
        {
            if (!IsPairCorrupted(line.Split(separator)))
            {
                string key = line.Split(separator)[1];
                object value = null;
                DataTypes type = (DataTypes)Enum.Parse(typeof(DataTypes), line.Split(separator)[3]);

                TryGetValue(key, ref value, type, line.Split(separator)[2]);
                keyValuePairs.Add(
                    new Dictionary<string, object>()
                    {
                        { key, value }
                    });
            }
        }

        return keyValuePairs;
    }

    #endregion


    #region Private Methods

    /// <summary>
    /// Sets a given value identified by the given key.
    /// </summary>
    private static void SetValue(string key, object value)
    {
        int? lineIndex = FindLineIndex(key, GetDataType(value));

        if (lineIndex == null)
        {
            Write(key, value);
        }
        else
        {
            List<string> lines = File.ReadAllLines(SaveFileName).ToList();
            DataTypes type = GetDataType(value);

            lines.Remove(lines[(int)lineIndex]);

            if (type == DataTypes.Float)
                lines.Add(separator + key + separator + ((float)value).ToString(CultureInfo.InvariantCulture) + separator + GetDataType(value).ToString() + separator);
            else if (type == DataTypes.Vector3)
                lines.Add(separator + key + separator + ((Vector3)value).ToString("F7", CultureInfo.InvariantCulture) + separator + GetDataType(value).ToString() + separator);
            else
                lines.Add(separator + key + separator + $"{value}" + separator + GetDataType(value).ToString() + separator);

            File.WriteAllLines(SaveFileName, lines);
        }
    }

    /// <summary>
    /// Returns the value of a specific data type corresponding to key if it exists.
    /// If it does not exist, it creates key-value pair with corresponding data type and returns default value for this data type.
    /// </summary>
    private static object GetValue(string key, DataTypes type)
    {
        object value = null;
        int? lineIndex = FindLineIndex(key, type);

        if (lineIndex == null)
        {
            switch (type)
            {
                case DataTypes.String:
                    value = "";
                    break;
                case DataTypes.Int:
                    value = 0;
                    break;
                case DataTypes.Float:
                    value = 0.0f;
                    break;
                case DataTypes.Bool:
                    value = false;
                    break;
                case DataTypes.Vector3:
                    value = Vector3.zero;
                    break;
            }

            Write(key, value);
        }
        else
        {
            List<string> lines = File.ReadAllLines(SaveFileName).ToList();
            string[] necessaryLine = lines[(int)lineIndex].Split(separator);

            TryGetValue(key, ref value, type, necessaryLine[2]);
        }

        return value;
    }

    /// <summary>
    /// Returns true if the given key with a value of given data type exists, otherwise returns false.
    /// </summary>
    private static bool HasKeyByType(string key, DataTypes type)
    {
        CheckOrCreateSaveFile();

        try
        {
            List<string> lines = File.ReadAllLines(SaveFileName).ToList();

            foreach (string line in lines)
            {
                if ((line.Split(separator)[1] == key) && (line.Split(separator)[3] == type.ToString()))
                    return true;
            }
        }
        catch (IndexOutOfRangeException) { }

        return false;
    }

    /// <summary>
    /// Removes the given key with a value of given data type. 
    /// If no such key exists, DeleteKeyByType has no impact.
    /// </summary>
    private static void DeleteKeyByType(string key, DataTypes type)
    {
        int? lineIndex = FindLineIndex(key, type);

        if (lineIndex != null)
        {
            List<string> lines = File.ReadAllLines(SaveFileName).ToList();
            lines.Remove(lines[(int)lineIndex]);

            File.WriteAllLines(SaveFileName, lines);
        }
    }

    /// <summary>
    /// Returns key-value pair index if the given key with value of given data type exists, otherwise returns null.
    /// </summary>
    private static int? FindLineIndex(string key, DataTypes type)
    {
        CheckOrCreateSaveFile();

        try
        {
            List<string> lines = File.ReadAllLines(SaveFileName).ToList();

            foreach (string line in lines)
            {
                string[] pair = line.Split(separator);

                if (!IsPairCorrupted(pair))
                {
                    if ((pair[1] == key) && (pair[3] == type.ToString()))
                        return lines.IndexOf(line);
                }
            }
        }
        catch (IndexOutOfRangeException) { }

        return null;
    }

    /// <summary>
    /// Opens and closes the FileStream and creates a save file if it does not exist.
    /// If the save file already exists, CheckOrCreateSaveFile has no impact.
    /// </summary>
    private static void CheckOrCreateSaveFile()
    {
        if (File.Exists(SaveFileName))
            return;

        FileStream file = new FileStream(SaveFileName, FileMode.OpenOrCreate);
        file.Close();
    }

    /// <summary>
    /// Creates a key-value pair with a given value identified by the given key and writes it to a safe file.
    /// </summary>
    private static void Write(string key, object value)
    {
        FileStream file = new FileStream(SaveFileName, FileMode.OpenOrCreate, FileAccess.Write);

        DataTypes type = GetDataType(value);
        byte[] keyArray = Encoding.Default.GetBytes(separator + key + separator);
        byte[] valueArray;

        if (type == DataTypes.Float)
            valueArray = Encoding.Default.GetBytes(((float)value).ToString(CultureInfo.InvariantCulture) + separator + type.ToString() + separator + "\n");
        else if (type == DataTypes.Vector3)
            valueArray = Encoding.Default.GetBytes(((Vector3)value).ToString("F7", CultureInfo.InvariantCulture) + separator + type.ToString() + separator + "\n");
        else
            valueArray = Encoding.Default.GetBytes($"{value}" + separator + type.ToString() + separator + "\n");

        file.Seek(0, SeekOrigin.End);
        file.Write(keyArray, 0, keyArray.Length);
        file.Write(valueArray, 0, valueArray.Length);

        file.Close();
    }

    /// <summary>
    /// Returns the data type corresponding to the DataTypes enumeration for the given value.
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    private static DataTypes GetDataType(object value)
    {
        switch (value)
        {
            case string:
                return DataTypes.String;
            case int:
                return DataTypes.Int;
            case Single:
                return DataTypes.Float;
            case bool:
                return DataTypes.Bool;
            case Vector3:
                return DataTypes.Vector3;
            default:
                throw new ArgumentException($"Unsupported type: {value.GetType()}");
        }
    }

    /// <summary>
    /// Returns true if the given key-value pair is corrupted, otherwise returns false.
    /// Ensures that the key-value pair length is correct and that the data type is found in the pair.
    /// </summary>
    private static bool IsPairCorrupted(string[] pair)
    {
        List<string> types = new List<string>()
        {
            DataTypes.String.ToString(),
            DataTypes.Int.ToString(),
            DataTypes.Float.ToString(),
            DataTypes.Bool.ToString(),
            DataTypes.Vector3.ToString(),
        };

        if ((pair.Length == 5) && types.Contains(pair[3]))
            return false;
        else
            return true;
    }

    /// <summary>
    /// Returns the value of a specific data type corresponding to key.
    /// If the value is corrupted, then the pair with this value is replaced with a pair with the default value for the data type of this pair.
    /// </summary>
    private static void TryGetValue(string key, ref object value, DataTypes type, string inputValue)
    {
        switch (type)
        {
            case DataTypes.String:
                {
                    value = inputValue;
                    break;
                }
            case DataTypes.Int:
                {
                    try
                    {
                        value = Convert.ToInt32(inputValue);
                    }
                    catch (FormatException)
                    {
                        value = 0;

                        DeleteKeyByType(key, type);
                        Write(key, value);
                    }

                    break;
                }
            case DataTypes.Float:
                {
                    try
                    {
                        value = float.Parse(inputValue, CultureInfo.InvariantCulture);
                    }
                    catch (Exception)
                    {
                        value = 0.0f;

                        DeleteKeyByType(key, type);
                        Write(key, value);
                    }

                    break;
                }
            case DataTypes.Bool:
                {
                    if ((inputValue == "True") || (inputValue == "true"))
                        value = true;
                    else if ((inputValue == "False") || (inputValue == "false"))
                        value = false;
                    else
                    {
                        value = false;

                        DeleteKeyByType(key, type);
                        Write(key, value);
                    }

                    break;
                }
            case DataTypes.Vector3:
                {
                    try
                    {
                        string[] vectorLine = inputValue.Substring(1, inputValue.Length - 2).Split(", ");

                        value = new Vector3(
                            float.Parse(vectorLine[0], CultureInfo.InvariantCulture),
                            float.Parse(vectorLine[1], CultureInfo.InvariantCulture),
                            float.Parse(vectorLine[2], CultureInfo.InvariantCulture));
                    }
                    catch (Exception)
                    {
                        value = Vector3.zero;

                        DeleteKeyByType(key, type);
                        Write(key, value);
                    }

                    break;
                }
        }
    }

    #endregion
}



/*

Version 8 (Latest version as of April 8, 2026)
GitHub: https://github.com/EnfityBro/InternalParams

Note: it is recommended not to damage the save file contents manually to avoid possible loss of saved data.

*/