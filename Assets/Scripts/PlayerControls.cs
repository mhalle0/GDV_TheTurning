using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 5f;
    private float humanity = 100;   // how much humanity you start w/
    private float zombificationRate = 1f; // rate that you turn into a zombie

    [SerializeField] private TurningMechanic turning;


    // Start is called before the first frame update
    void Start()
    {
        turning.SetSize((float)(humanity * 0.01));
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, verticalInput * speed * Time.deltaTime, 0);

        turning.SetSize((float)(humanity * 0.01));

        humanity -= zombificationRate * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if ("Teleport".Equals(collision.gameObject.tag))
        {
            DoorBehavior door = collision.gameObject.GetComponent<DoorBehavior>();
            transform.position = door.getNewLocation();
        }
        //else if ("Pill".Equals(collision.gameObject.tag))
        //{
        //    PillBehavior pill = collision.gameObject.GetComponent<DoorBehavior>();
        //    Debug.Log("Got an inventory item");
        //}
        else if ("InvItem".Equals(collision.gameObject.tag))
        {
            InvItemBehavior item = collision.gameObject.GetComponent<InvItemBehavior>();
            if(collision.gameObject.name == "PillBottle") item.pickUp("pillBottle");
            else if(collision.gameObject.name == "CureList") item.pickUp("cureList");
            else if(collision.gameObject.name == "Ingredient1") item.pickUp("ingredient1");
            else if(collision.gameObject.name == "Ingredient2") item.pickUp("ingredient2");
            else if(collision.gameObject.name == "Ingredient3") item.pickUp("ingredient3");
            else if(collision.gameObject.name == "Ingredient4") item.pickUp("ingredient4");
            Debug.Log("Got an inventory item");
        }
        else {
            Debug.Log("(PLAYER): Warning, collided with untagged object");
        }
    }

    public void TakePill()
    {
        humanity += 5;
        if (humanity > 100)
            humanity = 100;
    }
}
