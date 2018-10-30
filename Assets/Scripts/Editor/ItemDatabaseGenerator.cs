using UnityEditor;
using UnityEngine;

public class ItemDatabaseGenerator : MonoBehaviour
{
    private static readonly string assetPath = "Assets/ItemDatabase.asset";

    [MenuItem("Databases/ Create Item Database")]
    public static void CreateItemDatabase()
    {
        ItemDatabase newDatabase = ScriptableObject.CreateInstance<ItemDatabase>();
        AssetDatabase.CreateAsset(newDatabase, assetPath);
        AssetDatabase.Refresh();
    }
}
