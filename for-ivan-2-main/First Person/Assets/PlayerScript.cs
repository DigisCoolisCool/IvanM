using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Camera playerCamera;
    Ray rayFromPlayer;
    RaycastHit hit;
    public GameObject sparkles;
    public int ammo = 10;
    public AudioSource lasersound;
   // public AudioSource ammoPickup;
    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        rayFromPlayer = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Debug.DrawRay(rayFromPlayer.origin, rayFromPlayer.direction * 100, Color.red);

        if (Input.GetKeyDown(KeyCode.F) && ammo>0)
        {
            if(Physics.Raycast(rayFromPlayer,out hit, 100))
            {
                print("The objectc is " + hit.collider.gameObject.name + "in front of player!");
                Vector3 positionofImpact;
                positionofImpact = hit.point;
                Instantiate(sparkles,positionofImpact,Quaternion.identity);
                GameObject objectTargeted;
                if (hit.collider.gameObject.tag == "target")
                {
                    objectTargeted = hit.collider.gameObject;
                    objectTargeted.GetComponent<ManageNPC>().GotHit();
                }



            }
            ammo--;
            lasersound.Play();
            print("You have " + ammo + "ammo left!");
        }

    }



}
