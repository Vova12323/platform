using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class move : MonoBehaviour
{
    CharacterController character;
    static int score = 0;
    int lim = 100;
    [SerializeField] TextMeshProUGUI bullet_count_ui_text;
    public float speed = 12f;
    float jumpHeight = 5f;
    float gravityValue = -9.81f;
    public GameObject win;
    bool isGrounded = false;
    
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();       
    }

    // Update is called once per frame
    void Update()
    {
        character.Move(transform.up * gravityValue * Time.deltaTime);
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        character.Move(transform.forward * vertical * speed * Time.deltaTime);
        character.Move(transform.right * horizontal * speed * Time.deltaTime);

        if (score >= lim){
            win.SetActive(true);
        }
        if(Input.GetKeyDown("space") && isGrounded == true) { // если нажат пробел и мы на земле, то...
                character.Move(transform.up * jumpHeight); // ...двигаемся вверх на высотку прыжка
            }
        isGrounded = false;
    }
    void OnControllerColliderHit(ControllerColliderHit col) {
        if(col.gameObject.tag == "ground") {
            isGrounded = true; // если капсула касается коллайдера земли, то сохраняем это состояние в переменной isGrounded
        }
        if(col.gameObject.tag == "money")
        {
            score = score + 10;
            bullet_count_ui_text.text = score + "";
            print("ты заработал" + score + "$");
            Destroy(col.gameObject);
        }
    }
}
