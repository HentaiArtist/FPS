using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    int CurrentItemIndex;
    public List<Item> items;
    
    void Start()
    {
     
        items = new List<Item>();
    }

    public void ChangeItem()
    {
        if (items.Count == 0)
        {
            return;
        }

        items[CurrentItemIndex].HideItem();
        CurrentItemIndex++;
        if (CurrentItemIndex >= items.Count)
        {
            CurrentItemIndex = 0;
        }
        items[CurrentItemIndex].ShowItem();
    }

    public void Use()
    {
        if (items[CurrentItemIndex].tag == "Gun")
        {
            Shooting sht = items[CurrentItemIndex].GetComponent<Shooting>();
            sht.Shoot();
        }
    }

    public void Reload()
    {
        if (items[CurrentItemIndex].tag == "Gun")
        {
            Shooting sht = items[CurrentItemIndex].GetComponent<Shooting>();
            sht.Reload();
        }
    }

    public void Aim()
    {
        if(items[CurrentItemIndex].tag == "Gun")
        {
            Shooting sht = items[CurrentItemIndex].GetComponent<Shooting>();
            sht.Aiming();
        }
    }

    public void Notaim()
    {
        if (items[CurrentItemIndex].tag == "Gun")
        {
            Shooting sht = items[CurrentItemIndex].GetComponent<Shooting>();
            sht.Notaiming();
        }
    }

    public void Add(GameObject Ytem)
    {
        Item item = Ytem.GetComponent<Item>();
        items.Add(item);

    }
}























