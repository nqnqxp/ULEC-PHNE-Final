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

    private float mirrorX;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        characterSprite = GetComponent<SpriteRenderer>();

        mirrorX = characterSprite.transform.localScale.x;
    }

    private void Start()
    {
        Vector3 scale = characterSprite.transform.localScale;
        scale.x = -mirrorX;
        characterSprite.transform.localScale = scale;
    }

    public void ChangeSprite(string spriteName)
    {
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
        }
    }
}
