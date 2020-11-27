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

    public float humanity = 100;   // how much humanity you start w/
    public float zombificationRate = 1f; // rate that you turn into a zombie
    
    public int pillCount;

    public bool hasCure;

    [SerializeField] private TurningMechanic turningBar;
    [SerializeField] private TurningMechanic turningTop;
    [SerializeField] private LabBenchBehavior bench;
    [SerializeField] private SceneMan SceneMan;

    GameObject[] pauseObjects;

    // Start is called before the first frame update
    void Start()
    {
        turningBar.SetSize((float)(humanity * 0.01));
        turningTop.SetSize((float)(humanity * 0.01));
        pillCount = 30;
        hasCure = false;

        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("PauseMenu");
        hidePauseMenu();
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

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void FixedUpdate(){
        
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);

        turningBar.SetSize((float)(humanity * 0.01));
        turningTop.SetSize((float)(humanity * 0.01));

        humanity -= zombificationRate * Time.deltaTime;
        if(humanity <= 0)
        {
            SceneManager.LoadScene("DeathMenu");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if ("Teleport".Equals(collision.gameObject.tag))
        {
            DoorBehavior door = collision.gameObject.GetComponent<DoorBehavior>();
            if (!door.isLocked) transform.position = door.getNewLocation();
            else Debug.Log("The door is locked!");
            if (door.isUnlockTrigger) {
                door.unlockOtherDoor();
                Debug.Log("Unlocked Other Door(s)!");
            }
        }
        else if ("InvItem".Equals(collision.gameObject.tag))
        {
            InvItemBehavior item = collision.gameObject.GetComponent<InvItemBehavior>();
            if(collision.gameObject.name == "MapPillBottle") item.pickUp("pillBottle");
            else if(collision.gameObject.name == "CureList") item.pickUp("cureList");
            else if(item.puzzle != null)
            {
                SceneMan.ActivatePuzzle(item.puzzle);
            }

            if(collision.gameObject.name == "Ingredient1") item.pickUp("ingredient1");
            else if(collision.gameObject.name == "Ingredient2") item.pickUp("ingredient2");
            else if(collision.gameObject.name == "Ingredient3") item.pickUp("ingredient3");
            else if(collision.gameObject.name == "Ingredient4") item.pickUp("ingredient4");
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

    //Pause functions
    public void showPauseMenu()
    {
        foreach(GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    public void hidePauseMenu()
    {
        foreach(GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    public void TogglePause()
    {
        if(SceneManager.GetActiveScene().name == "Hospital")
        {
            if(Time.timeScale == 0)
            {
                Debug.Log("Game unpaused");
                Time.timeScale = 1;
                hidePauseMenu();
            } 
            else 
            {
                Debug.Log("Game paused");
                Time.timeScale = 0;
                showPauseMenu();
            }
        }
    }

}
