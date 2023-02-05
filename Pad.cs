using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    [SerializeField] float speed; 
    float height;
    string inpt;
    public bool isRightPad;
    void Start() 
    { 
        height = transform.localScale.y;
        
    } 
    public void Init(bool isRight) 
    {

        isRightPad = isRight; 
        Vector2 pos = Vector2.zero; 
        if (isRight)
        { 
            pos = new Vector2(GameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x;
            inpt = "PadRight"; 
        } 
        else 
        { 
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x; 
            inpt = "PadLeft";
        } 
        transform.position = pos;
        transform.name = inpt; 
    } 
    void Update() 
    { 

        float move = Input.GetAxis(inpt) * Time.deltaTime * speed; 
        if(transform.position.y < GameManager.bottomLeft.y + height/2 && move < 0)
            move = 0; 
        if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0)
        {
            move = 0;
            
        }
        transform.Translate(move * Vector2.up);

    }
}
