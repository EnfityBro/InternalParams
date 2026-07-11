# Internal Params - The Powerful Save/Load File System For Unity Games

> [!NOTE]
> - **InternalParams** is a class that saves game settings and values as key-value pairs. 
>   <br>It can store **string**, **integer**, **float**, **boolean** and **Vector3** values in the special save file in the project folder. 
> - The class is located in the 'Enfity.SaveAndLoad' namespace. 
> - **InternalParams** is an **advanced** and **improved** analog of Unity's PlayerPrefs. 

## Summary
- [Features](#features)
- [Public properties](#public-properties)
- [Public methods](#public-methods)
- [How to use](#how-to-use)
- [Recommendations for use](#recommendations-for-use)
- [Installation](#installation)
- [Compatibility](#compatibility)
- [Latest version](#latest-version)
- [Contact me](#contact-me)

## Features
- Can save data with the **same key name**, but in **different data types**. 
- Guaranteed to work on **PC** and **Android** (including Meta Quest 2/3). 
- Has a **protection** system **against manual corruption** of the save file. 
  <details>
    <summary>About this system</summary>
    
    - a **completely corrupted save file** without separators **does not causes bugs** in the InternalParams operation; 
    - **extraneous lines** are **ignored** by the InternalParams; 
    - **a corrupted key-value pair** is perceived as missing from the save file and **ignored** by the InternalParams; 
    - in the case of a **duplicated key-value pair**, the **first** such pair is used in the methods operation; 
    - if there is a **corrupted value** in the key-value pair, then this pair is **replaced** with a pair with the **default value** for the data type of this pair; 
    - a key-value pair with **a corrupted data type** is perceived as missing from the save file and **ignored** by the InternalParams; 
    - when **null values** are passed to methods, their operation **has no effect** and stops prematurely (it also **returns the default value or false** in the case of **non-void methods**); 
    - **has logging** with 'Debug.LogWarning()'; 
    - **has an impact only** if the save file **content is intentionally manually corrupted**. 
  </details>
- Has automatic **escaping** of passed **system control characters**. 
- Works with **float** values for **different regions**. 
- Supports working with **multiple save files**. 

## Public properties
<table>
  <tr>
    <td><b>SaveFileName</b></td>
    <td>the name of the save file in which the key-value pairs are stored. Default save file name is 'InternalParams.enfity'</td>
  </tr>
</table>

## Public methods
<details>
  <summary>String Methods</summary>

  <table>
    <tr>
      <td><b>void SetString(string key, string value)</b></td>
      <td>sets a string value identified by the given key</td>
    </tr>
    <tr>
      <td><b>string GetString(string key)</b></td>
      <td>returns the string value corresponding to key if it exists. If it does not exist, it returns empty string</td>
    </tr>
    <tr>
      <td><b>string GetString(string key, string defaultValue)</b></td>
      <td>returns the string value corresponding to key if it exists. If it does not exist, it returns the passed value of the 'defaultValue' parameter</td>
    </tr>
    <tr>
      <td><b>string GetString(string key, bool createIfMissing)</b></td>
      <td>returns the string value corresponding to key if it exists. If it does not exist, it creates a key-value pair with empty string value if createIfMissing parameter is true, and returns empty string</td>
    </tr>
    <tr>
      <td><b>string GetString(string key, string defaultValue, bool createIfMissing)</b></td>
      <td>returns the string value corresponding to key if it exists. If it does not exist, it creates a key-value pair with empty string value if createIfMissing parameter is true, and returns the passed value of the 'defaultValue' parameter</td>
    </tr>
    <tr>
      <td><b>bool HasKeyString(string key)</b></td>
      <td>returns true if the given key with string value exists, otherwise returns false</td>
    </tr>
    <tr>
      <td><b>void DeleteKeyString(string key)</b></td>
      <td>removes the given key with string value. If no such key exists, DeleteKeyString has no impact</td>
    </tr>
  </table>
</details>
<details>
  <summary>Int Methods</summary>

  <table>
    <tr>
      <td><b>void SetInt(string key, int value)</b></td>
      <td>sets an integer value identified by the given key</td>
    </tr>
    <tr>
      <td><b>int GetInt(string key)</b></td>
      <td>returns the integer value corresponding to key if it exists. If it does not exist, it returns 0</td>
    </tr>
    <tr>
      <td><b>int GetInt(string key, int defaultValue)</b></td>
      <td>returns the integer value corresponding to key if it exists. If it does not exist, it returns the passed value of the 'defaultValue' parameter</td>
    </tr>
    <tr>
      <td><b>int GetInt(string key, bool createIfMissing)</b></td>
      <td>returns the integer value corresponding to key if it exists. If it does not exist, it creates a key-value pair with 0 value if createIfMissing parameter is true, and returns 0</td>
    </tr>
    <tr>
      <td><b>int GetInt(string key, int defaultValue, bool createIfMissing)</b></td>
      <td>returns the integer value corresponding to key if it exists. If it does not exist, it creates a key-value pair with 0 value if createIfMissing parameter is true, and returns the passed value of the 'defaultValue' parameter</td>
    </tr>
    <tr>
      <td><b>bool HasKeyInt(string key)</b></td>
      <td>returns true if the given key with integer value exists, otherwise returns false</td>
    </tr>
    <tr>
      <td><b>void DeleteKeyInt(string key)</b></td>
      <td>removes the given key with integer value. If no such key exists, DeleteKeyInt has no impact</td>
    </tr>
  </table>
</details>
<details>
  <summary>Float Methods</summary>
  
  <table>
    <tr>
      <td><b>void SetFloat(string key, float value)</b></td>
      <td>sets a float value identified by the given key</td>
    </tr>
    <tr>
      <td><b>float GetFloat(string key)</b></td>
      <td>returns the float value corresponding to key if it exists. If it does not exist, it returns 0.0f</td>
    </tr>
    <tr>
      <td><b>float GetFloat(string key, float defaultValue)</b></td>
      <td>returns the float value corresponding to key if it exists. If it does not exist, it returns the passed value of the 'defaultValue' parameter</td>
    </tr>
    <tr>
      <td><b>float GetFloat(string key, bool createIfMissing)</b></td>
      <td>returns the float value corresponding to key if it exists. If it does not exist, it creates a key-value pair with 0.0f value if createIfMissing parameter is true, and returns 0.0f</td>
    </tr>
    <tr>
      <td><b>float GetFloat(string key, float defaultValue, bool createIfMissing)</b></td>
      <td>returns the float value corresponding to key if it exists. If it does not exist, it creates a key-value pair with 0.0f value if createIfMissing parameter is true, and returns the passed value of the 'defaultValue' parameter</td>
    </tr>
    <tr>
      <td><b>bool HasKeyFloat(string key)</b></td>
      <td>returns true if the given key with float value exists, otherwise returns false</td>
    </tr>
    <tr>
      <td><b>void DeleteKeyFloat(string key)</b></td>
      <td>removes the given key with float value. If no such key exists, DeleteKeyFloat has no impact</td>
    </tr>
  </table>
</details>
<details>
  <summary>Bool Methods</summary>

  <table>
    <tr>
      <td><b>void SetBool(string key, bool value)</b></td>
      <td>sets a boolean value identified by the given key</td>
    </tr>
    <tr>
      <td><b>bool GetBool(string key)</b></td>
      <td>returns the boolean value corresponding to key if it exists. If it does not exist, it returns false</td>
    </tr>
    <tr>
      <td><b>bool GetBoolWithDefault(string key, bool defaultValue)</b></td>
      <td>returns the boolean value corresponding to key if it exists. If it does not exist, it returns the passed value of the 'defaultValue' parameter</td>
    </tr>
    <tr>
      <td><b>bool GetBool(string key, bool createIfMissing)</b></td>
      <td>returns the boolean value corresponding to key if it exists. If it does not exist, it creates a key-value pair with false value if createIfMissing parameter is true, and returns false</td>
    </tr>
    <tr>
      <td><b>bool GetBoolWithDefault(string key, bool defaultValue, bool createIfMissing)</b></td>
      <td>returns the boolean value corresponding to key if it exists. If it does not exist, it creates a key-value pair with false value if createIfMissing parameter is true, and returns the passed value of the 'defaultValue' parameter</td>
    </tr>
    <tr>
      <td><b>bool HasKeyBool(string key)</b></td>
      <td>returns true if the given key with boolean value exists, otherwise returns false</td>
    </tr>
    <tr>
      <td><b>void DeleteKeyBool(string key)</b></td>
      <td>removes the given key with boolean value. If no such key exists, DeleteKeyBool has no impact</td>
    </tr>
  </table>
</details>
<details>
  <summary>Vector3 Methods</summary>

  <table>
    <tr>
      <td><b>void SetVector3(string key, Vector3 value)</b></td>
      <td>sets a Vector3 value identified by the given key</td>
    </tr>
    <tr>
      <td><b>Vector3 GetVector3(string key)</b></td>
      <td>returns the Vector3 value corresponding to key if it exists. If it does not exist, it returns Vector3.zero</td>
    </tr>
    <tr>
      <td><b>Vector3 GetVector3(string key, Vector3 defaultValue)</b></td>
      <td>returns the Vector3 value corresponding to key if it exists. If it does not exist, it returns the passed value of the 'defaultValue' parameter</td>
    </tr>
    <tr>
      <td><b>Vector3 GetVector3(string key, bool createIfMissing)</b></td>
      <td>returns the Vector3 value corresponding to key if it exists. If it does not exist, it creates a key-value pair with Vector3.zero value if createIfMissing parameter is true, and returns Vector3.zero</td>
    </tr>
    <tr>
      <td><b>Vector3 GetVector3(string key, Vector3 defaultValue, bool createIfMissing)</b></td>
      <td>returns the Vector3 value corresponding to key if it exists. If it does not exist, it creates a key-value pair with Vector3.zero value if createIfMissing parameter is true, and returns the passed value of the 'defaultValue' parameter</td>
    </tr>
    <tr>
      <td><b>bool HasKeyVector3(string key)</b></td>
      <td>returns true if the given key with Vector3 value exists, otherwise returns false</td>
    </tr>
    <tr>
      <td><b>void DeleteKeyVector3(string key)</b></td>
      <td>removes the given key with Vector3 value. If no such key exists, DeleteKeyVector3 has no impact</td>
    </tr>
  </table>
</details>
<details>
  <summary>General Methods</summary>

  <table>
    <tr>
      <td><b>void DeleteAll()</b></td>
      <td>deletes all existing keys and values. If there are no key-value pairs, then DeleteAll will has no impact</td>
    </tr>
    <tr>
      <td><b>void DeleteAllKeys(string key)</b></td>
      <td>deletes all existing key-value pairs with the given key. If there are no such keys it has no impact</td>
    </tr>
    <tr>
      <td><b>bool HasKey(string key)</b></td>
      <td>returns true if the given key exists, otherwise returns false</td>
    </tr>
    <tr>
      <td><b>int PairsCount()</b></td>
      <td>returns the number of all existing key-value pairs</td>
    </tr>
    <tr>
      <td><b>void SetSaveFileName(string newSaveFileName)</b></td>
      <td>sets (for subsequent calls) the save file name in which the key-value pairs will be saved. Sets the name only for subsequent calls, useful when working with multiple save files. Default save file name is 'InternalParams.enfity'</td>
    </tr>
    <tr>
      <td><b>List&lt;KeyValuePair&lt;string, object&gt;&gt; GetAllKeyValuePairs()</b></td>
      <td>returns a list (with elements that consist of a KeyValuePair with a string key and a value with object data type) with all key-value pairs stored in the save file. If there are no key-value pairs, it returns an empty list</td>
    </tr>
  </table>
</details>

## How to use
<details>
  <summary>Saving and retrieving values</summary>

  ```csharp
  InternalParams.SetFloat("PlayerHP", 100.0f);
  InternalParams.SetString("PlayerHP", InternalParams.GetFloat("PlayerHP").ToString());

  InternalParams.SetBool("IsAlive", true);

  InternalParams.SetVector3("PlayerPosition", transform.position);
  InternalParams.SetVector3("PlayerRotation", transform.rotation.eulerAngles);

  int currentLevelId = InternalParams.GetInt("CurrentLevelId", 1, true);
  float hp = InternalParams.GetFloat("PlayerHP");
  string currentName = InternalParams.GetString("Name", "DefaultName");
  ```
</details>
<details>
  <summary>Key-value pairs manipulations</summary>

  ```csharp
  InternalParams.DeleteAllKeys("PlayerHP");
  InternalParams.DeleteKeyBool("IsAlive");

  bool hasPosition = InternalParams.HasKey("PlayerPosition");
  bool hasRotation = InternalParams.HasKeyVector3("PlayerRotation");

  InternalParams.DeleteAll();
  ```
</details>
<details>
  <summary>Save file manipulations</summary>

  ```csharp
  InternalParams.SetSaveFileName("GameProgress.save");

  for (int i = 0; i < 10; i++)
  {
    InternalParams.SetInt($"GameStage_{i}", i);
  }

  int gameProgressPairsCount = InternalParams.PairsCount();

  InternalParams.SetSaveFileName("GameSettings.save");
  int gameSettingsPairsCount = InternalParams.PairsCount();
  ```
</details>

## Recommendations for use
- It is recommended **not to damage the save file contents manually** to avoid possible loss of saved data. 
- It is recommended **not to touch the separators in the save file**, and also not to copy key-value pairs because: 
  - InternalParams uses special system control characters which are not displayed in the clipboard; 
  - if you try to manually copy one pair and paste it into the save file, InternalParams will ignore it. 

## Installation
1. Download actual **InternalParams.cs file** from [releases](https://github.com/EnfityBro/InternalParams/releases).
2. Add the downloaded code to your Unity project.

## Compatibility
- InternalParams older than version 9 are not compatible with new versions. 
- InternalParams works on all Unity versions. 
- Unity's PlayerPrefs can be completely replaced by using InternalParams. 

## Latest version
Version **11** (July 11, 2026)

## Contact me
- [Telegram Channel](https://t.me/enfity_games) 
- [Donation](https://dalink.to/enfity) 
- [YouTube](https://www.youtube.com/@enfity) 
- [Itch.io](https://enfity.itch.io/)
- enfity.games@gmail.com 
- [GitHub](https://github.com/EnfityBro) 
