using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    Sprite TailImage;
    // Start is called before the first frame update

    SpriteRenderer spriteRender;
    void Start()
    {
        spriteRender = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Thrust") > 0)
        {
            spriteRender.sprite = TailImage;
        }
        else
        {
            spriteRender.sprite = null;
        }
    }


}
