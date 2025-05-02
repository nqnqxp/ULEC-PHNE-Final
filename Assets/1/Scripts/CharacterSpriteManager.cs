using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSpriteManager : MonoBehaviour
{
    public static CharacterSpriteManager instance;

    private SpriteRenderer characterSprite;
    public Sprite idleSprite;
    public Sprite oneSprite;
    public Sprite twoSprite;
    public Sprite threeSprite;
    public Sprite fourSprite;
    public Sprite fiveSprite;

    private float mirrorX;

    private void Awake()
    {
        characterSprite = GetComponent<SpriteRenderer>();

        if (characterSprite != null)
        {
            mirrorX = characterSprite.transform.localScale.x;
        }
    }

    private void Start()
    {
        Vector3 scale = characterSprite.transform.localScale;
        scale.x = -mirrorX;
        characterSprite.transform.localScale = scale;
    }

    public void ChangeSprite(string spriteName)
    {
        if (characterSprite == null) return;

        switch (spriteName)
        {
            case "idle":
                characterSprite.sprite = idleSprite;
                break;
            case "one":
                characterSprite.sprite = oneSprite;
                break;
            case "two":
                characterSprite.sprite = twoSprite;
                break;
            case "three":
                characterSprite.sprite = threeSprite;
                break;
            case "four":
                characterSprite.sprite = fourSprite;
                break;
            case "five":
                characterSprite.sprite = fiveSprite;
                break;
            default:
                Debug.LogWarning($"Sprite name '{spriteName}' not recognized on {gameObject.name}.");
                break;
        }
    }
}
