using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// InternalParams is a class that saves game settings and values as key-value pairs.
/// It can store string, integer, float, boolean and UnityEngine.Vector3 values in the special file in the project folder.
/// </summary>
public static class InternalParams
{
    #region Variables

    private static string fileName = (UnityEngine.Application.platform == UnityEngine.RuntimePlatform.Android) ? $"{UnityEngine.Application.persistentDataPath}/InternalParams.enfity" : "InternalParams.enfity";
    private const string separator = "|~-~|";

    #endregion


    #region String

    /// <summary>
    /// Sets a string value identified by the given key.
    /// </summary>
    public static void SetString(string key, string value) => SetValue(key, value);

    /// <summary>
    /// Returns the string value corresponding to key if it exists. 
    /// If it does not exist, it creates key-value pair and returns empty string.
    /// </summary>
    public static string GetString(string key) => (string)GetValue(key, "System.String");

    /// <summary>
    /// Returns true if the given key with string value exists, otherwise returns false.
    /// </summary>
    public static bool HasKeyString(string key) => HasKeyByType(key, "System.String");

    /// <summary>
    /// Removes the given key with string value. 
    /// If no such key exists, DeleteKeyString has no impact.
    /// </summary>
    public static void DeleteKeyString(string key) => DeleteKeyByType(key, "System.String");

    #endregion


    #region Int

    /// <summary>
    /// Sets an integer value identified by the given key.
    /// </summary>
    public static void SetInt(string key, int value) => SetValue(key, value);

    /// <summary>
    /// Returns the integer value corresponding to key if it exists. 
    /// If it does not exist, it creates key-value pair and returns 0.
    /// </summary>
    public static int GetInt(string key) => (int)GetValue(key, "System.Int32");

    /// <summary>
    /// Returns true if the given key with integer value exists, otherwise returns false.
    /// </summary>
    public static bool HasKeyInt(string key) => HasKeyByType(key, "System.Int32");

    /// <summary>
    /// Removes the given key with integer value. 
    /// If no such key exists, DeleteKeyInt has no impact.
    /// </summary>
    public static void DeleteKeyInt(string key) => DeleteKeyByType(key, "System.Int32");

    #endregion


    #region Float

    /// <summary>
    /// Sets a float value identified by the given key.
    /// </summary>
    public static void SetFloat(string key, float value) => SetValue(key, value);

    /// <summary>
    /// Returns the float value corresponding to key if it exists. 
    /// If it does not exist, it creates key-value pair and returns 0.0f.
    /// </summary>
    public static float GetFloat(string key) => (float)GetValue(key, "System.Single");

    /// <summary>
    /// Returns true if the given key with float value exists, otherwise returns false.
    /// </summary>
    public static bool HasKeyFloat(string key) => HasKeyByType(key, "System.Single");

    /// <summary>
    /// Removes the given key with float value. 
    /// If no such key exists, DeleteKeyFloat has no impact.
    /// </summary>
    public static void DeleteKeyFloat(string key) => DeleteKeyByType(key, "System.Single");

    #endregion


    #region Bool

    /// <summary>
    /// Sets a boolean value identified by the given key.
    /// </summary>
    public static void SetBool(string key, bool value) => SetValue(key, value);

    /// <summary>
    /// Returns the boolean value corresponding to key if it exists. 
    /// If it does not exist, it creates key-value pair and returns false.
    /// </summary>
    public static bool GetBool(string key) => (bool)GetValue(key, "System.Boolean");

    /// <summary>
    /// Returns true if the given key with boolean value exists, otherwise returns false.
    /// </summary>
    public static bool HasKeyBool(string key) => HasKeyByType(key, "System.Boolean");

    /// <summary>
    /// Removes the given key with boolean value. 
    /// If no such key exists, DeleteKeyBool has no impact.
    /// </summary>
    public static void DeleteKeyBool(string key) => DeleteKeyByType(key, "System.Boolean");

    #endregion


    #region UnityEngine.Vector3

    /// <summary>
    /// Sets a UnityEngine.Vector3 value identified by the given key.
    /// </summary>
    public static void SetVector3(string key, UnityEngine.Vector3 value) => SetValue(key, value);

    /// <summary>
    /// Returns the UnityEngine.Vector3 value corresponding to key if it exists. 
    /// If it does not exist, it creates key-value pair and returns UnityEngine.Vector3.zero.
    /// </summary>
    public static UnityEngine.Vector3 GetVector3(string key) => (UnityEngine.Vector3)GetValue(key, "UnityEngine.Vector3");

    /// <summary>
    /// Returns true if the given key with UnityEngine.Vector3 value exists, otherwise returns false.
    /// </summary>
    public static bool HasKeyVector3(string key) => HasKeyByType(key, "UnityEngine.Vector3");

    /// <summary>
    /// Removes the given key with UnityEngine.Vector3 value.
    /// If no such key exists, DeleteKeyVector3 has no impact.
    /// </summary>
    public static void DeleteKeyVector3(string key) => DeleteKeyByType(key, "UnityEngine.Vector3");

    #endregion


    #region Public

    /// <summary>
    /// Deletes all existing keys and values. 
    /// If there are no key-value pairs, then DeleteAll will has no impact.
    /// </summary>
    public static void DeleteAll()
    {
        using (FileStream file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
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
            List<string> lines = File.ReadAllLines(fileName).ToList();

            for (int i = lines.Count - 1; i >= 0; i--)
            {
                if (lines[i].Split(separator)[1] == key)
                    lines.RemoveAt(i);
            }

            File.WriteAllLines(fileName, lines);
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
            List<string> lines = File.ReadAllLines(fileName).ToList();

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

        return File.ReadAllLines(fileName).ToList().Count;
    }

    /// <summary>
    /// Sets the name of the file in which the key-value pairs will be saved
    /// (Note: the default filename is InternalParams.enfity).
    /// </summary>
    public static void SetFileName(string newFileName)
    {
        fileName = (UnityEngine.Application.platform == UnityEngine.RuntimePlatform.Android) ? $"{UnityEngine.Application.persistentDataPath}/{newFileName}" : newFileName;
    }

    #endregion


    #region Private

    /// <summary>
    /// Sets a given value identified by the given key.
    /// </summary>
    private static void SetValue(string key, object value)
    {
        int lineIndex = FindLineIndex(key, $"{value.GetType()}");

        if (lineIndex == -1)
        {
            Write(key, value);
        }
        else
        {
            List<string> lines = File.ReadAllLines(fileName).ToList();

            lines.Remove(lines[lineIndex]);
            lines.Add(separator + key + separator + $"{value}" + separator + $"{value.GetType()}" + separator);

            File.WriteAllLines(fileName, lines);
        }
    }

    /// <summary>
    /// Returns the value corresponding to key if it exists.
    /// If it does not exist, it creates key-value pair with corresponding data type and returns default value for this data type.
    /// </summary>
    private static object GetValue(string key, string type)
    {
        object value = null;
        int lineIndex = FindLineIndex(key, type);

        if (lineIndex == -1)
        {
            switch (type)
            {
                case "System.String":
                    value = string.Empty;
                    break;
                case "System.Int32":
                    value = 0;
                    break;
                case "System.Single":
                    value = 0.0f;
                    break;
                case "System.Boolean":
                    value = false;
                    break;
                case "UnityEngine.Vector3":
                    value = UnityEngine.Vector3.zero;
                    break;
            }

            Write(key, value);
        }
        else
        {
            List<string> lines = File.ReadAllLines(fileName).ToList();
            string[] necessaryLine = lines[lineIndex].Split(separator);

            switch (type)
            {
                case "System.String":
                    value = necessaryLine[2];
                    break;
                case "System.Int32":
                    {
                        try
                        {
                            value = Convert.ToInt32(necessaryLine[2]);
                        }
                        catch (FormatException)
                        {
                            value = 0;

                            DeleteKeyByType(key, type);
                            Write(key, value);
                        }

                        break;
                    }
                case "System.Single":
                    {
                        try
                        {
                            value = (float)Convert.ToDouble(necessaryLine[2]);
                        }
                        catch (FormatException)
                        {
                            value = 0.0f;

                            DeleteKeyByType(key, type);
                            Write(key, value);
                        }

                        break;
                    }
                case "System.Boolean":
                    value = ((necessaryLine[2] == "True") || (necessaryLine[2] == "true")) ? true : false;
                    break;
                case "UnityEngine.Vector3":
                    {
                        try
                        {
                            string[] vectorLine = necessaryLine[2].Substring(1, necessaryLine[2].Length - 2).Split(", ");

                            value = new UnityEngine.Vector3((float)Convert.ToDouble(vectorLine[0].Replace('.', ',')),
                                (float)Convert.ToDouble(vectorLine[1].Replace('.', ',')),
                                (float)Convert.ToDouble(vectorLine[2].Replace('.', ',')));
                        }
                        catch (FormatException)
                        {
                            value = UnityEngine.Vector3.zero;

                            DeleteKeyByType(key, type);
                            Write(key, value);
                        }

                        break;
                    }
            }
        }

        return value;
    }

    /// <summary>
    /// Returns true if the given key with value of given data type exists, otherwise returns false.
    /// </summary>
    private static bool HasKeyByType(string key, string type)
    {
        CheckOrCreateSaveFile();

        try
        {
            List<string> lines = File.ReadAllLines(fileName).ToList();

            foreach (string line in lines)
            {
                if ((line.Split(separator)[1] == key) && (line.Split(separator)[3] == type))
                    return true;
            }
        }
        catch (IndexOutOfRangeException) { }

        return false;
    }

    /// <summary>
    /// Removes the given key with value of given data type. 
    /// If no such key exists, DeleteKeyByType has no impact.
    /// </summary>
    private static void DeleteKeyByType(string key, string type)
    {
        int lineIndex = FindLineIndex(key, type);

        if (lineIndex != -1)
        {
            List<string> lines = File.ReadAllLines(fileName).ToList();
            lines.Remove(lines[lineIndex]);

            File.WriteAllLines(fileName, lines);
        }
    }

    /// <summary>
    /// Returns key-value pair index if the given key with value of given data type exists, otherwise returns -1.
    /// </summary>
    private static int FindLineIndex(string key, string type)
    {
        CheckOrCreateSaveFile();

        try
        {
            List<string> lines = File.ReadAllLines(fileName).ToList();

            foreach (string line in lines)
            {
                if ((line.Split(separator)[1] == key) && (line.Split(separator)[3] == type))
                    return lines.IndexOf(line);
            }
        }
        catch (IndexOutOfRangeException) { }

        return -1;
    }

    /// <summary>
    /// It opens and closes the FileStream and creates a save file if it does not exist.
    /// If the save file already exists, CheckOrCreateSaveFile has no impact.
    /// </summary>
    private static void CheckOrCreateSaveFile()
    {
        if (File.Exists(fileName))
            return;

        FileStream file = new FileStream(fileName, FileMode.OpenOrCreate);
        file.Close();
    }

    /// <summary>
    /// Creates a key-value pair with a given value identified by the given key and writes it to a safe file.
    /// </summary>
    private static void Write(string key, object value)
    {
        FileStream file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);

        byte[] keyArray = Encoding.Default.GetBytes(separator + key + separator);
        byte[] valueArray = Encoding.Default.GetBytes($"{value}" + separator + $"{value.GetType()}" + separator + "\n");

        file.Seek(0, SeekOrigin.End);
        file.Write(keyArray, 0, keyArray.Length);
        file.Write(valueArray, 0, valueArray.Length);

        file.Close();
    }

    #endregion
}



/*

Version 6 (The latest version is as of January 30, 2026)

Note: it is recommended not to damage the save file contents manually to avoid losing the saved data.

*/