using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teddy : MonoBehaviour
{
    public GameObject Player;
    private NavMeshAgent agent;
    private float walkingVal;
    private Animator animator;
    private bool walkingStarted = false;
    private bool stoppingStarted = true;
    private StoryCanvas storyCanvas;
    public bool ShouldWave;

    private string ch1_1_path = "event:/ch1_1";
    // Start is called before the first frame update
    void Start()
    {
        storyCanvas = StoryCanvas.Instance;

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        Ch1AudioManager.Instance.PlayOneTimeSound(ch1_1_path);
        storyCanvas.ChangeText();
    }

    // Update is called once per frame
    void Update()
    {
        //functionality for waving at player. should add logic with hands here
        if(ShouldWave)
        {
            ShouldWave= false;
            animator.SetBool("shouldWave", true);
            StartCoroutine(waveFor1Second());
        }

        //follow player 
        float dist = Vector3.Distance(transform.position, Player.transform.position);
        if(dist > 4.5f)
        {
            if (!walkingStarted)
            {
                walkingStarted= true;
                stoppingStarted = false;
                StopAllCoroutines();
                StartCoroutine(startWalking());
            }
            agent.SetDestination(Player.transform.position + Player.transform.forward *1.5f);    
        }
        else
        {
            if (!stoppingStarted)
            {
                stoppingStarted= true;
                walkingStarted = false;
                StopAllCoroutines();
                StartCoroutine(stopWalking());
                Debug.Log("stopped walking");

                //teddy should rotate toward player. not working

                //transform.LookAt(Player.transform.position);
                //transform.position = new Vector3(transform.position.x, transform.position.y - playerTeddyOffset.y, transform.position.z);
            }
        }
    }
    private IEnumerator waveFor1Second()
    {
        yield return new WaitForSeconds(1);
        animator.SetBool("shouldWave", false);
    }
    private IEnumerator startWalking()
    {
        walkingVal = animator.GetFloat("Walk");
        while (walkingVal < 1)
        {
            walkingVal += Time.deltaTime;
            walkingVal = walkingVal > 1 ? 1 : walkingVal;
            animator.SetFloat("Walk", walkingVal);
            yield return null;
        }
    }
    private IEnumerator stopWalking()
    {
        walkingVal = animator.GetFloat("Walk");
        while (walkingVal > 0 )
        {
            walkingVal -= Time.deltaTime;
            walkingVal = walkingVal < 0 ? 0 : walkingVal;
            animator.SetFloat("Walk", walkingVal);
            yield return null;
        }
    }
}
