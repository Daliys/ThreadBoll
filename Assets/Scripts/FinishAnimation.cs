using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishAnimation : MonoBehaviour
{
    public GameObject nodeStart;    
    public GameObject nodeFinish;
    public GameObject splineYarn;
    public GameObject player; 
    public GameObject followingCamera; 
    public GameObject confetti; 
    public UI UIObj; 

    private bool isFollowing = false;
    private bool isFirstTime = true;
    void Start()
    {
        
    }

    void Update()
    {
        if (player.transform.localScale == Vector3.zero && isFirstTime)
        {
            isFollowing = false;
            isFirstTime = false;
            StartCoroutine(WaiterForTimeAndShowPanel(1f));
        }

        if (isFollowing)
        {
            nodeFinish.transform.position = new Vector3(player.transform.position.x, nodeStart.transform.position.y, player.transform.position.z);
        }
    }

    IEnumerator WaiterForTimeAndShowPanel(float time)
    {
        yield return new WaitForSeconds(time);
        Game.SaveCoins((int)(player.GetComponent<PlayerController>().size * 100));
        UIObj.ShowWinPanel((int)(player.GetComponent<PlayerController>().size * 100));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            nodeStart.transform.position = new Vector3(player.transform.position.x, nodeStart.transform.position.y, player.transform.position.z);
            nodeStart.SetActive(true);
            nodeFinish.transform.position = new Vector3(player.transform.position.x, nodeStart.transform.position.y, player.transform.position.z);
            nodeFinish.SetActive(true);
            splineYarn.SetActive(true);
            isFollowing = true;
            followingCamera.SetActive(true);
            player.transform.GetComponent<PlayerController>().SetReachFinish();
            confetti.SetActive(true);
        }
    }
}
