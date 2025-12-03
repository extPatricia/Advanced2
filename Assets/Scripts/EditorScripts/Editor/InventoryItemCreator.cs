using UnityEngine;
using System;
using UnityEditor;

public class InventoryItemCreator : EditorWindow
{
    private string itemName = "NewItem";
    private Sprite itemIcon;
    private int itemQuantity = 1;
    private bool isStackable;

    [MenuItem("Window/Inventory Item Creator")]
    public static void ShowWindow()
    {
        GetWindow<InventoryItemCreator>("Inventory Item Creator");
    }

    private void OnGUI()
    {
        GUILayout.Label("Create a new Inventory Item", EditorStyles.boldLabel);

        itemName = EditorGUILayout.TextField("Item Name", itemName);
        itemIcon = (Sprite)EditorGUILayout.ObjectField("Item Icon", itemIcon, typeof(Sprite), false);
        itemQuantity = EditorGUILayout.IntField("Item Quantity", itemQuantity);
        isStackable = EditorGUILayout.Toggle("Is Stackable", isStackable);

        if (GUILayout.Button("Create Item"))
        {
            CreateInventoryItem();
        }

    }

    private void CreateInventoryItem()
    {
        InventoryItem newItem = ScriptableObject.CreateInstance<InventoryItem>();
        newItem.itemName = itemName;
        newItem.itemIcon = itemIcon;
        newItem.itemQuantity = itemQuantity;
        newItem.isStackable = isStackable;
        string assetPath = $"Assets/InventoryItems/{itemName}.asset";

        AssetDatabase.CreateAsset(newItem, assetPath);
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();
        Selection.activeObject = newItem;
        Debug.Log($"Inventory Item '{itemName}' created at {assetPath}");
    }

}