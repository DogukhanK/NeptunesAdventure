using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Vector3 up = Vector3.zero;
    Vector3 down = new Vector3(0, 180, 0);
    Vector3 right = new Vector3(0, 90, 0);
    Vector3 left = new Vector3(0, -90, 0);

    Vector3 currentdirection = Vector3.zero;

    Vector3 destination;
    Vector3 nextposition;
    Vector3 direction;

    float speed = 1.0f;
    bool move;
    float range = 1.0f;
    bool isPlaying;

    public int MaxHealth;
    public int CurrentHealth;

    Animator walk;

    public HealthBar bar;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;

        bar.SetMaxHealth(MaxHealth);

        destination = transform.position;
        nextposition = Vector3.forward;
        currentdirection = up;

        walk = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(movement());

        if (Input.GetKeyDown(KeyCode.P))
        {
            Damage(10);
        }
    }

    IEnumerator movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        walk.SetBool("walk", false);

        if (Input.GetKeyDown(KeyCode.W))
        {
            nextposition = Vector3.forward;
            currentdirection = up;
            walk.SetBool("walk", true);
            move = true;
            isPlaying = true;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            nextposition = Vector3.left;
            currentdirection = left;
            walk.SetBool("walk", true);
            move = true;
            isPlaying = true;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            nextposition = Vector3.back;
            currentdirection = down;
            walk.SetBool("walk", true);
            move = true;
            isPlaying = true;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            nextposition = Vector3.right;
            currentdirection = right;
            walk.SetBool("walk", true);
            move = true;
            isPlaying = true;
        }

        if (Vector3.Distance(destination, transform.position) <= 0.00001f)
        {
            transform.localEulerAngles = currentdirection;
            if (move)
            {
                if (blocked())
                {
                    destination = transform.position + nextposition;
                    direction = nextposition;
                    move = false;
                }
            }
        }
        if (isPlaying == true)
        {
            move = false;
            yield return new WaitForSeconds(5.5f);
        }
    }

    bool blocked()
    {
        Ray checker = new Ray(transform.position + new Vector3(0, 0.5f, 0), transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(checker, out hit, range))
        {
            if (hit.collider.tag == "Obstacle")
            {
                return false;
            }
        }

        return true;
    }

    void Damage(int damage)
    {
        CurrentHealth -= damage;

        bar.SetHealth(CurrentHealth);
    }
}
