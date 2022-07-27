using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    internal KeyCode keyCode;
    private GameObject clone;
    private TextMesh textMesh;
    private float force=1f;
    private void Start()
    {
        if (keyCode.ToString()!="None")
        {
            textMesh = GameObject.FindGameObjectWithTag(keyCode.ToString()).GetComponentInChildren<TextMesh>();
        }
        else
        {
            textMesh = null;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            clone = Instantiate(gameObject);
            clone.transform.localScale = new Vector3(.8f, 0f, .8f);
            clone.transform.position = gameObject.transform.position + Vector3.up * 1f;
        }
        if (Input.GetKey(keyCode))
        {
            clone.transform.localScale += new Vector3(0, 1, 0) * Time.deltaTime;
            if (textMesh)
            {
                textMesh.text = keyCode.ToString();
            }
        }
        if (Input.GetKeyUp(keyCode))
        {
            clone.GetComponent<Rigidbody>().velocity = Vector3.up * force;
            textMesh.text = "";
        }
    }
    private void OnApplicationFocus(bool focus)
    {
        if (!focus&& textMesh!=null&&clone!=null)
        {
            clone.GetComponent<Rigidbody>().velocity = Vector3.up * force;
            textMesh.text = "";
        }
    }
}
