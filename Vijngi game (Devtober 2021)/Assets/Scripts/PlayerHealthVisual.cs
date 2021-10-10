using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthVisual : MonoBehaviour
{
    [SerializeField] private Sprite heartSprite;

    private void Start()
    {
        CreateHeartImage(new Vector2(0, 0));
        CreateHeartImage(new Vector2(50, 0));
        CreateHeartImage(new Vector2(100, 0));
    }

    // Create a single heart image
    private Image CreateHeartImage(Vector2 anchoredPosition)
    {
        // Create the Game Object
        GameObject heartGameObject = new GameObject("Heart", typeof(Image));
        // Set as child of this transform
        heartGameObject.transform.parent = transform;
        heartGameObject.transform.localPosition = Vector3.zero;

        // Locate and Size the heart
        heartGameObject.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        heartGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(40, 40);

        // Set the sprite of the heart
        Image heartImage = heartGameObject.GetComponent<Image>();
        heartImage.sprite = heartSprite;

        return heartImage;
    }

    // Represents a single heart
    public class HeartImage
    {
        private Image heartImage;

        public HeartImage(Image heartImage)
        {
            this.heartImage = heartImage;
        }
    }
}
