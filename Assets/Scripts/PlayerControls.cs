using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControls : MonoBehaviour
{
    public float speed = 5f;
    Vector2 movement;

    public Rigidbody2D rb;
    public Animator animator;

    private float humanity = 100;   // how much humanity you start w/
    private float zombificationRate = 1f; // rate that you turn into a zombie
    
    public int pillCount;

    public bool hasCure;

    [SerializeField] private TurningMechanic turning;
    [SerializeField] private LabBenchBehavior bench;

    // Start is called before the first frame update
    void Start()
    {
        turning.SetSize((float)(humanity * 0.01));
        pillCount = 30;
        hasCure = false;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        
        if(movement.sqrMagnitude == 0){
            animator.SetBool("isMoving", false);
        } else {
            animator.SetBool("isMoving", true);
        }


    }

    void FixedUpdate(){
        
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        turning.SetSize((float)(humanity * 0.01));

        humanity -= zombificationRate * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if ("Teleport".Equals(collision.gameObject.tag))
        {
            DoorBehavior door = collision.gameObject.GetComponent<DoorBehavior>();
            transform.position = door.getNewLocation();
        }
        else if ("InvItem".Equals(collision.gameObject.tag))
        {
            InvItemBehavior item = collision.gameObject.GetComponent<InvItemBehavior>();
            if(collision.gameObject.name == "MapPillBottle") item.pickUp("pillBottle");
            else if(collision.gameObject.name == "CureList") item.pickUp("cureList");
            else
            {
                // pull up puzzle attached to item -> scene change
                // result = win or lose
                // if (win)
                //    item.pickUp
                SceneManager.LoadScene(item.puzzle);
                Debug.Log("loading the scene, or trying to");
            }

            //else if(collision.gameObject.name == "Ingredient1") item.pickUp("ingredient1");
            //else if(collision.gameObject.name == "Ingredient2") item.pickUp("ingredient2");
            //else if(collision.gameObject.name == "Ingredient3") item.pickUp("ingredient3");
            //else if(collision.gameObject.name == "Ingredient4") item.pickUp("ingredient4");
            //Debug.Log("Got an inventory item");
        }
        else if("LabBench".Equals(collision.gameObject.tag)) {
            bench.makeCure();
        }
        else {
            Debug.Log("(PLAYER): Notice- Collided with object with unprocessed tag. Object Name: \"" + collision.gameObject.name + "\"   Object Tag: \"" + collision.gameObject.tag + "\"");
        }
    }

    public void TakePill()
    {
        pillCount -= 1;
        humanity += 5;
        if (humanity > 100)
            humanity = 100;
    }

    public void RefillPills(){
        pillCount += 30;
    }
}
