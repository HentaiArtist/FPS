using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public KeyCode JumpButton;
    public KeyCode ReloadKey;
    public KeyCode ItemChangeKey;
    public KeyCode PickItemKey;
    public Transform Hands;
    Inventory inventory;
    // Item itemscript ;
    PickingUpWeapon handsscript;
    Shooting Sht;
    DamageSystem Dsystem;
    JumpBoost Jump;

    private void Awake()
    {
        // itemscript = GetComponent<Item>();
        Jump = GetComponent<JumpBoost>();
        handsscript = GetComponent<PickingUpWeapon>();
        Sht = GetComponent<Shooting>();
        Dsystem = GetComponent<DamageSystem>();
        inventory = GetComponent<Inventory>();
        
    
    }




    private void Update()
    {



        if (Input.GetKeyDown(PickItemKey))
        {
            GameObject go = handsscript.PickItem();
            inventory.Add(go);


        }
        if (Input.GetKeyDown(JumpButton))
        {
            Jump.Jumpo();
        }
        if (Input.GetMouseButtonDown(0))
        {
            inventory.Use();
        }

        if (Input.GetMouseButtonUp(0))
        {
            inventory.Enduse();
        }

        if (Input.GetKeyDown(ReloadKey))
        {
            inventory.Reload();
        }

        if (Input.GetKeyDown(ItemChangeKey))

        {
            inventory.ChangeItem();
        }
    }
}
       /* if (Input.GetMouseButton(1) )
        {
            inventory.Aim();
        }

        if (Input.GetMouseButtonUp(1))
        {
            inventory.Notaim();
        }
        */
    

    