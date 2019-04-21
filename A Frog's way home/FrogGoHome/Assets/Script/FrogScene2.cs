﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FrogScene2 : MonoBehaviour
{
    private bool mMoveTo;
    private Vector2 mFore;
    //  [SerializeField] private Vector2 mFore;
    private Rigidbody2D mRigid;
    // Start is called before the first frame update
    void Start()
    {
        mMoveTo = Random.Range(0, 2) == 0 ? true : false;
        mFore = new Vector2(2, 3);
        mRigid = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//tiep dat true
        {
            mRigid.velocity = Vector2.zero;
            if (mMoveTo)
            {
                mRigid.AddForce(mFore * new Vector2(-2, 2), ForceMode2D.Impulse);
            }
            else
            {
                mRigid.AddForce(mFore * new Vector2(2, 2), ForceMode2D.Impulse);
            }
            mMoveTo = !mMoveTo;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("trap"))
        {
            Debug.Log("!!!!!!!!! GAME OVER !!!!!!!!!!");
            SceneManager.LoadScene("Scene2");
            
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("victory"))
        {
            Debug.Log("Win");
            SceneManager.LoadScene("Scene3");
        }
    }
}
