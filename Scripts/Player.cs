using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Experimental.RestService;
using UnityEngine;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        float direction = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        while (Application.isPlaying)
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
                transform.position = Vector2.up;
            }
        }
    }

   
}

 public class MoveP
    {
        public float x;
        public float y;
        public float PlayerD;


    }