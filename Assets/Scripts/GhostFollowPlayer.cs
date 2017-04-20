using UnityEngine;
using System.Collections;

public class GhostFollowPlayer : MonoBehaviour {

    public Transform target;//set target from inspector instead of looking in Update
    public float speed = 3f;
    public GameObject Light;
    private Animator anim;

    void Awake()
    {
        
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(GameObject.FindWithTag("Player") == null)
        {
            return;
        }
        else
        {
            target = GameObject.FindWithTag("Player").transform;
        }
        //rotate to look at the player
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, 90, 0), Space.Self);//correcting the original rotation


        //move towards the player
        if (Vector3.Distance(transform.position, target.position) > 0.5f)
        {//move if distance from target is greater than 1
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Light")
        {
            Debug.Log("AHH");
            anim.SetBool("HurtGhost", true);
        }

        if (collider.gameObject.tag == "Player")
        {
          
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Light")
        {
            anim.SetBool("HurtGhost", false);
        }
    }


}
