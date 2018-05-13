using UnityEngine;

public class Block : MonoBehaviour
{
    //public bool IsDestroy = false;
    public Sprite[] HitSprites;

    [SerializeField]
    private int timesHit;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool isBreakable = this.CompareTag("Breakable");
        if(isBreakable)
        {
            HandleHits();
        }
    }

    private void HandleHits()
    {
        var maxHit = HitSprites.Length + 1;
        timesHit++;
        if (timesHit >= maxHit)
        {
            Destroy(gameObject);
        }
        else
        {
            LoadSprite();
        }
    }

    private void LoadSprite()
    {
        var spriteIndex = timesHit - 1;
        spriteRenderer.sprite = HitSprites[spriteIndex];
    }

}
