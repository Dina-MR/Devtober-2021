using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthVisual : MonoBehaviour
{
    // Variables representing a full/empty/half-full heart
    [SerializeField] private Sprite heartSpriteFull;
    [SerializeField] private Sprite heartSpriteEmpty;
    [SerializeField] private Sprite heartSpriteHalf;

    private List<HeartImage> heartImageList;
    private PlayerHealthSystem playerHealthSystem;

    private void Awake() 
    {
        heartImageList = new List<HeartImage>();
    }

    private void Start()
    {
        PlayerHealthSystem playerHealthSystem = new PlayerHealthSystem(3);
        SetPlayerHealthSystem(playerHealthSystem);
    }

    public void SetPlayerHealthSystem(PlayerHealthSystem playerHealthSystem)
    {
        this.playerHealthSystem = playerHealthSystem;
        SetHeartImageList(playerHealthSystem);
    }

    // Set the hearts image in the list, based on the player's number of hearts
    public void SetHeartImageList(PlayerHealthSystem playerHealthSystem)
    {
        List<PlayerHealthSystem.Heart> heartList = playerHealthSystem.GetHeartList();
        Vector2 heartAnchoredPosition = new Vector2(0,0); //position of the heart
        for(int i = 0; i < heartList.Count; i++)
        {
            PlayerHealthSystem.Heart heart = heartList[i];
            CreateHeartImage(heartAnchoredPosition).SetHeartFragments(heart.GetFragmentAmount());
            heartAnchoredPosition += new Vector2(60, 0);
        }
    }

    // Create a single heart image
    private HeartImage CreateHeartImage(Vector2 anchoredPosition)
    {
        // Create the Game Object
        GameObject heartGameObject = new GameObject("Heart", typeof(Image));

        // Set as child of this transform
        heartGameObject.transform.parent = transform;
        heartGameObject.transform.localPosition = Vector3.zero;

        // Locate and Size the heart
        heartGameObject.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        heartGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(35, 35);

        // Set the sprite of the heart
        Image heartImageUI = heartGameObject.GetComponent<Image>();
        heartImageUI.sprite = heartSpriteFull;

        HeartImage heartImage = new HeartImage(this, heartImageUI);
        heartImageList.Add(heartImage);

        return heartImage;
    }

    // Represents a single heart
    public class HeartImage
    {
        private Image heartImage;
        private PlayerHealthVisual playerHealthVisual;

        public HeartImage(PlayerHealthVisual playerHealthVisual, Image heartImage)
        {
            this.playerHealthVisual = playerHealthVisual;
            this.heartImage = heartImage;
        }

        public void SetHeartFragments(int fragments)
        {
            switch(fragments)
            {
                case 0:
                    heartImage.sprite = playerHealthVisual.heartSpriteEmpty;
                    break;
                case 1:
                    heartImage.sprite = playerHealthVisual.heartSpriteHalf;
                    break;
                default:
                    heartImage.sprite = playerHealthVisual.heartSpriteFull;
                    break;
            }
        }
    }

    
}
