using UnityEngine;

public class Block : MonoBehaviour {

    public int MaxHit;
    public bool IsDestroy = false;

    [SerializeField]
    private int timesHit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        timesHit++;
        if(timesHit >= MaxHit)
        {
            Destroy(gameObject);
        }
    }

}
