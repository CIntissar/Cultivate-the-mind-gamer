using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FakeBirdBehaviour : MonoBehaviour
{
    //[SerializeField] List<GameObject> fakeBirds = new List<GameObject>();
    [SerializeField] SpriteRenderer[] birdsSprite;
    [SerializeField] Transform[] birdsPosition;
    [SerializeField] List<Transform> waypoints = new List<Transform>();
    int nbr;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void FadeIn()
    {
        foreach (SpriteRenderer item in birdsSprite)
        {
            item.DOFade(1, 0.1f);
        }
    }
    public void FollowWaypoint()
    {
        for (int i = 0; i < birdsPosition.Length; i++) //for each bird
        {
            nbr = Random.Range(0, waypoints.Count); //choose a random index from the waypoint list
            birdsPosition[i].DOMove(new Vector3 (waypoints[nbr].position.x, waypoints[nbr].position.y, 0), 1.8f);
            //birdsPosition[i].position = waypoints[nbr].position; //go to that waypoint
        }
    }
    //put this script in levelmanager
    //reference it in ball script
    //make a function here to make them fade in
}
