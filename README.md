<b>The Save/Load File System For Unity Games "InternalParams", Made By Enfity</b>



InternalParams is a class that saves game settings and values. It can store string, integer, float, boolean and UnityEngine.Vector3 values in the special file in the project folder.

InternalParams public methods:
- The "Set" type methods - sets a value identified by the given key for certain data type.
- The "Get" type methods - returns a value of a certain data type corresponding to key if it exists. If it does not exist, it creates key-value pair and returns default value for it's data type.
- The "HasKey" type methods - returns true if the given key with a value of a certain data type exists, otherwise returns false.
- The "DeleteKey" type methods - removes the given key with a value of a certain data type. If no such key exists, this method has no impact.
- DeleteAll - deletes all existing keys and values. If there are no key-value pairs, then DeleteAll will has no impact.
- DeleteAllKeys - deletes all existing key-value pairs with the given key. If there are no such keys, it has no impact.
- HasKey - returns true if the given key exists, otherwise returns false.
- PairsCount - returns the number of all existing key-value pairs.
- ChangeFileName - sets the name of the file in which the key-value pairs will be saved (Note: the default filename is InternalParams.enfity).



Contact me: enfity.games@gmail.com<br>
YouTube: https://www.youtube.com/@enfity<br>
Telegram: https://t.me/enfity_games<br>
Donation: https://www.donationalerts.com/r/enfity<br>
Itch.io: https://enfity.itch.io/<br>
GitHub: https://github.com/EnfityBro
