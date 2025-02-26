using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data.SqlTypes;

public class piggy : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreoutput;
    public GameObject image;
    static int score = 0;
    Transform transf;
    CharacterController contr;
    public float speed = 12f;
    private float gravity = 10f;
    private float velocity;
    bool isDeaded = false;
    // Start is called before the first frame update
    void Start()
    {
        image.SetActive(false);
        transf = GetComponent<Transform>();
        contr = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float ver = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");
        float msX = Input.GetAxis("Mouse X");
        contr.Move(transf.forward*ver*speed*Time.deltaTime);
        contr.Move(transf.right*hor*speed*Time.deltaTime);
        transf.Rotate(0, msX, 0);
        velocity -= gravity*Time.deltaTime;
        contr.Move(transf.up*velocity*Time.deltaTime);
        if(score == 5){
            image.SetActive(true);
        }
        isDeaded = false;
    }
    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if(col.gameObject.tag == "Pig" && isDeaded == false){
            Destroy(col.gameObject);
            score = score + 1;
            scoreoutput.text = "Score:" + score;
            isDeaded = true;
        }
    }
}
