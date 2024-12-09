using UnityEngine;

public class BoxView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite Box;
    [SerializeField] private Sprite PlacedBox;

    public void ChangeImage(bool IsPlaced)
    {
        if (spriteRenderer == null) spriteRenderer = gameObject.AddComponent<SpriteRenderer>();

        switch (IsPlaced)
        {
            case false: spriteRenderer.sprite = Box; break;
            case true: spriteRenderer.sprite = PlacedBox; break;

        }
    }
}
