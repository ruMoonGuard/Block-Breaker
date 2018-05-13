using UnityEngine;

public class Block : MonoBehaviour
{
    public static int BreakableCount = 0;

    public AudioClip Crack;
    public GameObject Smoke;
    public Sprite[] HitSprites;

    [SerializeField]
    private int timesHit;
    private bool isBreakable;

    private SpriteRenderer spriteRenderer;
    private LevelManager levelManager;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        levelManager = FindObjectOfType<LevelManager>();

        isBreakable = this.CompareTag("Breakable");
        if(isBreakable)
        {
            BreakableCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(Crack, transform.position);
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
            BreakableCount--;
            levelManager.BlockDestroed();
            CreateSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprite();
        }
    }

    private void CreateSmoke()
    {
        var positionSmoke = new Vector3(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y + 0.5f, 0f);
        var smokeObject = Instantiate(Smoke, positionSmoke, Quaternion.identity);
        var colorBlock = spriteRenderer.color;
        var psMain = smokeObject.GetComponent<ParticleSystem>().main;
        psMain.startColor = new Color(colorBlock.r, colorBlock.g, colorBlock.b);
    }

    private void LoadSprite()
    {
        var spriteIndex = timesHit - 1;
        if(HitSprites[spriteIndex])
        {
            spriteRenderer.sprite = HitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block's sprite missing");
        }
    }

}
