using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUpWeapon : MonoBehaviour
{

 //   public AudioSource FailAudio;
    public Transform HandsSlot;
      void Update()
    {
               
    }

    public GameObject PickItem()
    {

        Vector3 forward = Camera.main.transform.position;
        Ray ray = new Ray(Camera.main.transform.position,
        Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3.0f, 1 << 8))
        {
            GameObject Ytem = hit.collider.gameObject;

            Item ii = Ytem.GetComponent<Item>();
            Rigidbody Rbg = Ytem.GetComponent<Rigidbody>();


            if (ii != null)
            {
               // Rbg.isKinematic = true;
                //Rbg.useGravity = false;
                Ytem.transform.parent = HandsSlot.transform;
                Ytem.transform.localPosition = Vector3.zero;
                Ytem.transform.localRotation = Quaternion.identity;

                return Ytem;
            }
            else
            {
              //  FailAudio.Play();
                return null;
            }
        }
        else
        {
           // FailAudio.Play();
            return null;
        }
    }
}
