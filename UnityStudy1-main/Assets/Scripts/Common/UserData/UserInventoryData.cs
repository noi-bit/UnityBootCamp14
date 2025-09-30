using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.LightingExplorerTableColumn;

[Serializable]
public class UserItemData
{
    public long SerialNumber; // ���� �ѹ�
    public int ItemId;

    public UserItemData(long serialNumber, int itemId)
    {
        SerialNumber = serialNumber;
        ItemId = itemId;
    }
}

[Serializable]
public class UserInventoryItemDataListWrapper  // ���� �뵵 �� JSON ��ȯ �뵵
{
    public List<UserItemData> InventoryItemDataList;
}

public class UserInventoryData : IUserData
{
    public List<UserItemData> InventoryItemDataList { get; set; } = new List<UserItemData>(); // ��¥ �츮�� ���ӿ��� ����� �뵵

    public void SetDefaultData()
    {
        Logger.Log($"{GetType()}::SetDefaultData");

        //���߿� ��Ʈ��ũ�� ���ؼ� ���� ������ ����� ������ �����ͼ� ����ϱ�

        //serealNumber => DateTime.Now.ToString("yyyyMMddHHmmss") + Random.Range(0, 9999).ToString("D4")
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 11001));
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 11002));
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 21001));
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 21002));
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 31001));
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 41002));
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 41001));
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 41002));
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 51001));
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 51002));
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 61001));
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 61002));
    }

    public bool LoadData()
    {
        Logger.Log($"{GetType()}::LoadData");

        bool result = false; // �÷���

        try
        {
            string inventoryItemDataListJson = PlayerPrefs.GetString("InventoryItemDataList");
            if (string.IsNullOrEmpty(inventoryItemDataListJson) == false)
            {
                UserInventoryItemDataListWrapper itemDataListWrapper = JsonUtility.FromJson<UserInventoryItemDataListWrapper>(inventoryItemDataListJson);
                InventoryItemDataList = itemDataListWrapper.InventoryItemDataList;

                Logger.Log("InventoryItemDataList Lode");
                foreach (var item in InventoryItemDataList)
                {
                    Logger.Log($"serialNumber : {item.SerialNumber}, itemId : {item.ItemId}");
                }
            }

            result = true;
        }
        catch (Exception e)
        {
            Logger.LogError($"Load failed ({e.Message})");
        }

        return result;
    }

    public bool SaveData()
    {
        Logger.Log($"{GetType()}::SaveData");

        bool result = false; // �÷���

        try
        {
            UserInventoryItemDataListWrapper itemDataListWrapper = new UserInventoryItemDataListWrapper();
            itemDataListWrapper.InventoryItemDataList = InventoryItemDataList;
            string inventoryItemDataListJson = JsonUtility.ToJson(itemDataListWrapper);
            PlayerPrefs.SetString("InventoryItemDataList", inventoryItemDataListJson);

            Logger.Log("InventoryItemDataList Save");
            foreach (var item in InventoryItemDataList)
            {
                Logger.Log($"serialNumber : {item.SerialNumber}, itemId : {item.ItemId}");
            }

            result = true;
        }
        catch (Exception e)
        {
            Logger.LogError($"Save failed ({e.Message})");
        }

        return result;
    }
}
