using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public int checkpoints = 0;
    private int alleCheckpoints = 5;
    public int Lapcounter = 0;

    // ai variabelen 
    public int aicheckpoints = 0;
    private int aialleCheckpoints = 5;
    public int aiLapcounter = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Lapcounter == 1)
        {
            print("You finished first");
            if (CompareTag("Player"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
            }
            if (CompareTag("Player2"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }

        }

        if (aiLapcounter == 1)
        {
            if (CompareTag("Ai"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
            }
            if (CompareTag("Ai2"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        {

            // hier wordt een functie aangeroepen
            if (other.CompareTag("Checkpointsvis") && this.CompareTag("Player"))
            {
                playerCheckpointCounter();
            }
            if (other.CompareTag("Checkpointsvis") && this.CompareTag("Player2"))
            {
                playerCheckpointCounter();
            }

            // hier wordt een functie aangeroepen
            if (other.CompareTag("Checkpointsvis") && this.CompareTag("Ai"))
            {
                AiCheckpointCounter();
            }
            if (other.CompareTag("Checkpointsvis") && this.CompareTag("Ai2"))
            {
                AiCheckpointCounter();
            }
        }
    }
    // hier checkt de code of de ai door alle checkpoints is gereden, als het zo is heb je een rode gereden
    private void AiCheckpointCounter()
    {
        {
            aicheckpoints++;
            if (aicheckpoints == aialleCheckpoints)
            {
                if (aicheckpoints == 5)
                {
                    aiLapcounter++;
                    if (aiLapcounter > 0)
                    {
                        aicheckpoints = 0;
                    }
                }
            }
        }
    }
    // hier checkt de code of de player door alle checkpoints is gereden, als het zo is heb je een rode gereden
    private void playerCheckpointCounter()
    {
        {
            checkpoints++;
            if (checkpoints == alleCheckpoints)
            {
                if (checkpoints == 5)
                {
                    Lapcounter++;
                    if (Lapcounter > 0)
                    {
                        checkpoints = 0;
                    }
                }
            }
        }
    }
}