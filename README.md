# The Save/Load File System For Unity Games "InternalParams", Made By Enfity

> [!NOTE]
> - **InternalParams** is a class that saves game settings and values as key-value pairs. 
> - It can store **string**, **integer**, **float**, **boolean** and **Vector3** values in the special file in the project folder. 

## InternalParams public properties:
- **SaveFileName** - the name of the save file in which the key-value pairs are stored. 

## InternalParams public methods:
- **The "Set" type methods** - sets a value identified by the given key for certain data type. 
- **The "Get" type methods** - returns the value of a specific data type corresponding to key if it exists. If it does not exist, it creates key-value pair with corresponding data type and returns default value for this data type. 
- **The "HasKey" type methods** - returns true if the given key with a value of a certain data type exists, otherwise returns false. 
- **The "DeleteKey" type methods** - removes the given key with a value of a certain data type. If no such key exists, this method has no impact. 
- **DeleteAll** - deletes all existing keys and values. If there are no key-value pairs, then DeleteAll will has no impact. 
- **DeleteAllKeys** - deletes all existing key-value pairs with the given key. If there are no such keys it has no impact. 
- **HasKey** - returns true if the given key exists, otherwise returns false. 
- **PairsCount** - returns the number of all existing key-value pairs. 
- **SetSaveFileName** - sets the save file name in which the key-value pairs will be saved. Sets the name only for subsequent calls, useful when working with multiple save files. 

## InternalParams features:
- Can save data with the **same key name**, but in **different data types**. 
- Guaranteed to work on **PC** and **Android** (including Meta Quest 2/3). 
- Has protection against the save file corruption: 
  - a **completely corrupted save file** without separators causes **bugs** in the system operation; 
  - a **corrupted key-value pair** is perceived as missing from the save file and **ignored** by the system; 
  - in the case of a **duplicated key-value pair**, the **first** such pair is used in the methods operation; 
  - if there is a **corrupted value** in the key-value pair, then this pair is **replaced** with a pair with the **default value** for the data type of this pair; 
  - a **corrupted data type** in a key-value pair is perceived as missing from the save file and **ignored** by the system. 

## Latest version:
Version **7** (February 18, 2026)

## Contact me:
- enfity.games@gmail.com 
- [YouTube](https://www.youtube.com/@enfity) 
- [Telegram Channel](https://t.me/enfity_games) 
- [Donation](https://dalink.to/enfity) 
- [Itch.io](https://enfity.itch.io/) 
- [GitHub](https://github.com/EnfityBro) 