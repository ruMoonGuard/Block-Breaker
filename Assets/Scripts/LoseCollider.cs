using UnityEngine;

public class LoseCollider : MonoBehaviour {

    public LevelManager LevelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LevelManager == null) return;

        LevelManager.LoadLevel("Win Screen");
    }
}
