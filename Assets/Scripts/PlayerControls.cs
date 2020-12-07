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
    public SpriteRenderer sprite;
    public Sprite idleSprite;

    public DialogueBehavior DialogueBox;

    public float humanity = 100;   // how much humanity you start w/
    public float zombificationRate = 1f; // rate that you turn into a zombie
    
    public int pillCount;
    private bool learnedPills;

    [SerializeField] private TurningMechanic turningBar;
    [SerializeField] private TurningMechanic turningTop;
    [SerializeField] private LabBenchBehavior bench;
    [SerializeField] private SceneMan SceneMan;

    GameObject[] pauseObjects;

    // Start is called before the first frame update
    void Start()
    {
        animator.enabled = true;

        sprite = GetComponent<SpriteRenderer>();

        turningBar.SetSize((float)(humanity * 0.01));
        turningTop.SetSize((float)(humanity * 0.01));
        pillCount = 30;
        learnedPills = false;

        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("PauseMenu");
        showPauseMenu();
        hidePauseMenu();

        CureManager.Instance.circuitIsWon = false;
        CureManager.Instance.sliderIsWon = false;
        CureManager.Instance.codebreakingIsWon = false;
        CureManager.Instance.mazeIsWon = false;
        CureManager.Instance.playerHasCure = false;
        
        FreezePlayer.Instance.puzzleIsOpen = false;

        DialogueBox = GameObject.Find("DialogueBox").GetComponent<DialogueBehavior>();

        DialogueBox.DialogueMessage("Ugh…what happened yesterday ? Where is everyone?");
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
        
        if(FreezePlayer.Instance.puzzleIsOpen == true) 
        {
            sprite.sprite = idleSprite;
            animator.enabled = false;
        }
        else if(animator.enabled == false)
        {
            animator.enabled = true;
        }
        else
        {
            rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
        }

        turningBar.SetSize((float)(humanity * 0.01));
        turningTop.SetSize((float)(humanity * 0.01));

        humanity -= zombificationRate * Time.deltaTime;
        if(humanity <= 0)
        {
            SceneManager.LoadScene("DeathMenu");
        }

        if(!learnedPills && humanity <= 60)
        {
            DialogueBox.DialogueMessage("Ugh... I don't feel so good. Maybe taking some of these pills will help?");
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
            if (collision.gameObject.name == "MapPillBottle")
            {
                item.pickUp("pillBottle");
                DialogueBox.DialogueMessage("What’s this ? A pill bottle ? Prescription from fairview hospital…take as needed for the Turning. I can’t make out the rest of this label.");
            }
            else if (collision.gameObject.name == "CureList") item.pickUp("cureList");
            else if (item.puzzle != null)
            {
                SceneMan.ActivatePuzzle(item.puzzle);
            }

            if(collision.gameObject.name == "Ingredient1")
            {
                FreezePlayer.Instance.puzzleIsOpen = true;
                item.pickUp("ingredient1"); 
            }
            else if(collision.gameObject.name == "Ingredient2")
            {
                FreezePlayer.Instance.puzzleIsOpen = true;
                item.pickUp("ingredient2");
            } 
            else if(collision.gameObject.name == "Ingredient3") 
            {
                FreezePlayer.Instance.puzzleIsOpen = true;
                item.pickUp("ingredient3");
            }
            else if(collision.gameObject.name == "Ingredient4") item.pickUp("ingredient4");
            //Debug.Log("Got an inventory item");
        }
        else if("LabBench".Equals(collision.gameObject.tag)) {
            bench.makeCure();
        } else if ("Exit".Equals(collision.gameObject.tag)) {
            ExitDoorBehavior door = collision.gameObject.GetComponent<ExitDoorBehavior>();
            if (!door.isLocked) {
                SceneManager.LoadScene("WinMenu");
            }
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
        if (!learnedPills)
        {
            learnedPills = true;
        }
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
