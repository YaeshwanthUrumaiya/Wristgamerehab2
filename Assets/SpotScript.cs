using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotScript : MonoBehaviour
{
    public bool SwitchedOn = true;
    public Color OntargetColor;
    public Color OfftargetColor;
    private SpriteRenderer spriteRenderer;
    public UserMoveScript user;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(SwitchedOn){
            spriteRenderer.color = OntargetColor;
        }
        else{
            spriteRenderer.color = OfftargetColor;
        }
    }
    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        // Check if the collided object has the tag "Fruits" or "Bomb"
        if (collision.gameObject.CompareTag("Fruit") && SwitchedOn)
        {
            user.Score += 1;
           // Here you can add any additional logic you need to handle the detected item
        }
        else if(collision.gameObject.CompareTag("Bomb") && SwitchedOn){
            user.lives -= 1;
            Debug.Log("A bomb dropped, you only have X number of tries. X = " + user.lives);
            if(user.lives == 0){
                user.isGameOver = true;
            }
        }
    }
}
