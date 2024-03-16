using Photon.Pun;
using UnityEngine;

public class TriggerQuestionsScript : MonoBehaviour
{
    public GameObject questionPanel; 

    private void Start()
    {
        questionPanel.SetActive(false); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            if (other.GetComponent<PhotonView>().IsMine)
            {
                questionPanel.SetActive(true); 
            }
        }
        gameObject.SetActive(false);
    }
}
