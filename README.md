# Internal Params - The Save/Load File System For Unity Games Made By Enfity

> [!NOTE]
> - **InternalParams** is a class that saves game settings and values as key-value pairs. 
> - It can store **string**, **integer**, **float**, **boolean** and **Vector3** values in the special save file in the project folder. 
> - The class is located in the Enfity.SaveAndLoad namespace. 

## InternalParams features
- Can save data with the **same key name**, but in **different data types**. 
- Guaranteed to work on **PC** and **Android** (including Meta Quest 2/3). 
- Has a **protection** system **against manual corruption** of the save file. 
  <details>
    <summary>Click to see details about this system</summary>
    
    - a **completely corrupted save file** without separators **does not causes bugs** in the InternalParams operation; 
    - **extraneous lines** are **ignored** by the InternalParams; 
    - **a corrupted key-value pair** is perceived as missing from the save file and **ignored** by the InternalParams; 
    - in the case of a **duplicated key-value pair**, the **first** such pair is used in the methods operation; 
    - if there is a **corrupted value** in the key-value pair, then this pair is **replaced** with a pair with the **default value** for the data type of this pair; 
    - a key-value pair with **a corrupted data type** is perceived as missing from the save file and **ignored** by the InternalParams; 
    - when **null values** are passed to methods, their operation **has no effect** and stops prematurely (it also **returns the default value or false** in the case of **non-void methods**). 
  </details>
- The **protection** system **against manual corruption** of the save file **has logging** with 'Debug.LogWarning()'. 
- The **protection** system **against manual corruption** of the save file** has an impact only** if the save file **content is intentionally manually corrupted**. 

## InternalParams recommendations
- It is recommended **not to damage the save file contents manually** to avoid possible loss of saved data. 
- It is recommended **not to touch the separators in the save file**, and also not to copy key-value pairs because: 
  - InternalParams uses special system control characters which are not displayed in the clipboard; 
  - if you try to manually copy one pair and paste it into the save file, InternalParams will ignore it. 

## InternalParams public properties
- **SaveFileName** - the name of the save file in which the key-value pairs are stored. Default save file name is 'InternalParams.enfity'. 

## InternalParams public methods
<details>
  <summary>String Methods</summary>
  
  - **void SetString(string key, string value)** - sets a string value identified by the given key. 
  - **string GetString(string key)** - returns the string value corresponding to key if it exists. If it does not exist, it returns empty string. 
  - **string GetString(string key, bool createIfMissing)** - returns the string value corresponding to key if it exists. If it does not exist, it creates a key-value pair if createIfMissing parameter is true, and returns empty string. 
  - **bool HasKeyString(string key)** - returns true if the given key with string value exists, otherwise returns false. 
  - **void DeleteKeyString(string key)** - removes the given key with string value. If no such key exists, DeleteKeyString has no impact. 
</details>
<details>
  <summary>Int Methods</summary>
  
  - **void SetInt(string key, int value)** - sets an integer value identified by the given key. 
  - **int GetInt(string key)** - returns the integer value corresponding to key if it exists. If it does not exist, it returns 0. 
  - **int GetInt(string key, bool createIfMissing)** - returns the integer value corresponding to key if it exists. If it does not exist, it creates a key-value pair if createIfMissing parameter is true, and returns 0. 
  - **bool HasKeyInt(string key)** - returns true if the given key with integer value exists, otherwise returns false. 
  - **void DeleteKeyInt(string key)** - removes the given key with integer value. If no such key exists, DeleteKeyInt has no impact. 
</details>
<details>
  <summary>Float Methods</summary>
  
  - **void SetFloat(string key, float value)** - sets a float value identified by the given key. 
  - **float GetFloat(string key)** - returns the float value corresponding to key if it exists. If it does not exist, it returns 0.0f. 
  - **float GetFloat(string key, bool createIfMissing)** - returns the float value corresponding to key if it exists. If it does not exist, it creates a key-value pair if createIfMissing parameter is true, and returns 0.0f. 
  - **bool HasKeyFloat(string key)** - returns true if the given key with float value exists, otherwise returns false. 
  - **void DeleteKeyFloat(string key)** - removes the given key with float value. If no such key exists, DeleteKeyFloat has no impact. 
</details>
<details>
  <summary>Bool Methods</summary>
  
  - **void SetBool(string key, bool value)** - sets a boolean value identified by the given key. 
  - **bool GetBool(string key)** - returns the boolean value corresponding to key if it exists. If it does not exist, it returns false. 
  - **bool GetBool(string key, bool createIfMissing)** - returns the boolean value corresponding to key if it exists. If it does not exist, it creates a key-value pair if createIfMissing parameter is true, and returns false. 
  - **bool HasKeyBool(string key)** - returns true if the given key with boolean value exists, otherwise returns false. 
  - **void DeleteKeyBool(string key)** - removes the given key with boolean value. If no such key exists, DeleteKeyBool has no impact. 
</details>
<details>
  <summary>Vector3 Methods</summary>
  
  - **void SetVector3(string key, Vector3 value)** - sets a Vector3 value identified by the given key. 
  - **Vector3 GetVector3(string key)** - returns the Vector3 value corresponding to key if it exists. If it does not exist, it returns Vector3.zero. 
  - **Vector3 GetVector3(string key, bool createIfMissing)** - returns the Vector3 value corresponding to key if it exists. If it does not exist, it creates a key-value pair if createIfMissing parameter is true, and returns Vector3.zero. 
  - **bool HasKeyVector3(string key)** - returns true if the given key with Vector3 value exists, otherwise returns false. 
  - **void DeleteKeyVector3(string key)**- removes the given key with Vector3 value. If no such key exists, DeleteKeyVector3 has no impact. 
</details>
<details>
  <summary>Other Methods</summary>
  
  - **void DeleteAll()** - deletes all existing keys and values. If there are no key-value pairs, then DeleteAll will has no impact. 
  - **void DeleteAllKeys(string key)** - deletes all existing key-value pairs with the given key. If there are no such keys it has no impact. 
  - **bool HasKey(string key)** - returns true if the given key exists, otherwise returns false. 
  - **int PairsCount()** - returns the number of all existing key-value pairs. 
  - **void SetSaveFileName(string newSaveFileName)** - sets (for subsequent calls) the save file name in which the key-value pairs will be saved. Sets the name only for subsequent calls, useful when working with multiple save files. Default save file name is 'InternalParams.enfity'. 
  - **List<KeyValuePair<string, object>> GetAllKeyValuePairs()** - returns a list (with elements that consist of a KeyValuePair with a string key and a value with object data type) with all key-value pairs stored in the save file. If there are no key-value pairs, it returns an empty list. 
</details>

## Latest version
Version **9** (April 12, 2026)

## Contact me
- [Telegram Channel](https://t.me/enfity_games) 
- [Donation](https://dalink.to/enfity) 
- [YouTube](https://www.youtube.com/@enfity) 
- [Itch.io](https://enfity.itch.io/)
- enfity.games@gmail.com 
- [GitHub](https://github.com/EnfityBro) 