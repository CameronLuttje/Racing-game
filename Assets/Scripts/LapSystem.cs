using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LapSystem : MonoBehaviour
{
    [SerializeField]
    List<GameObject> checkpoints = new List<GameObject>();
    [SerializeField]
    GameObject finish;
    public bool finished = false;
    public int currentcheckpoint = 0;

    private void OnTriggerEnter(Collider checkpointchecker)
    {
        if(checkpointchecker.gameObject.CompareTag("checkpoints"))
        {
            currentcheckpoint++;
        }
    }

    private void Update()
    {
        if(currentcheckpoint == checkpoints.Count)
        {
            finished = true;
        }

        if(finished == true)
        {
            SceneManager.LoadScene(2);
        }
    }
}
