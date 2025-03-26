using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  public AudioClip DamageSound;

    public InputAction leftAction;
    public InputAction moveAction;
    public InputAction talkAction;
    public int maxHealth = 5; //Creats integer "maxHealth" and sets it equal to 5.
    public int currentHealth;
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float damageCooldown;
    public int health { get { return currentHealth; }}
    public GameObject projectilePrefab;

    Rigidbody2D rigidbody2d;
    Vector2 move;
    Animator animator;
    Vector2 moveDirection = new Vector2(1,0);
    public float speed = 7.0f;

    AudioSource audioSource;
    // Start is called before the first frame update

    void Start()
    {
     leftAction.Enable();
     moveAction.Enable();
     talkAction.Enable();
     rigidbody2d = GetComponent<Rigidbody2D>();
     animator = GetComponent<Animator>();
     currentHealth = maxHealth;
     audioSource = GetComponent<AudioSource>();
     //QualitySettings.vSyncCount = 0;
     //Application.targetFrameRate = 120;
    }

    // Update is called once per frame
 void Update()
  {

    if (Input.GetKeyDown(KeyCode.Return) || (Input.GetKeyDown(KeyCode.X)) )
        {
           FindFriend();
        }
        
     if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y,0.0f))
     {
        moveDirection.Set(move.x, move.y);
        moveDirection.Normalize();
     }

     animator.SetFloat("Look X", moveDirection.x);
     animator.SetFloat("Look Y", moveDirection.y);
     animator.SetFloat("Speed", move.magnitude);

  
      //Stores vector 2 value for movement.
       move = moveAction.ReadValue<Vector2>();
        //display in console
        //Debug.Log(move);
        if (isInvincible)
{
    damageCooldown -= Time.deltaTime; // subtract from current time
    if (damageCooldown < 0)
    {
       isInvincible = false;
    }
}
     if(Input.GetKeyDown(KeyCode.C))
       {
          Launch();
       }


    }

    void FixedUpdate()
   {
       Vector2 position = (Vector2)rigidbody2d.position + move * speed * Time.deltaTime;
       rigidbody2d.MovePosition(position);
   }


   public void PlaySound(AudioClip clip)
  {
     audioSource.PlayOneShot(clip);
  }

   public void ChangeHealth (int amount)
   {
      
        if (amount < 0)
        {
            if (isInvincible)
            {
                return;
            }
            PlaySound(DamageSound);
            isInvincible = true;
            damageCooldown = timeInvincible;
            animator.SetTrigger("Hit");
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
   }

void Launch()
  {
    GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
    Projectile projectile = projectileObject.GetComponent<Projectile>();
    projectile.Launch(moveDirection, 300);
    animator.SetTrigger("Launch");
  }

  void FindFriend()
{
RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f,  moveDirection, 1.5f, LayerMask.GetMask("NPC"));

if (hit.collider != null)
{
     Debug.Log("Raycast has hit the object " + hit.collider.gameObject);
     NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();

   if (character != null)
   {
       UIHandler.instance.DisplayDialogue(character.npcDialogue);
   }
}

}
}
