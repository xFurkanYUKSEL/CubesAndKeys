using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cubes : MonoBehaviour
{
    Color[] colors = new Color[] { Color.red, Color.green, Color.blue, Color.yellow, Color.black, Color.magenta, Color.cyan, Color.white };
    KeyCode[] keys = new KeyCode[] { KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L };
    [SerializeField]
    private GameObject cube;

    [Range(4, 8)]
    [SerializeField]
    private byte amount = 4;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            cube.tag = keys[i].ToString();// Defined a tag for find on Keys script
            GameObject clone = Instantiate(cube, gameObject.transform.position + Vector3.down * 4, Quaternion.identity);
            clone.transform.Translate(new Vector3(i + (float)(1 - amount) / 2, 0, 0));
            clone.gameObject.GetComponentInChildren<MeshRenderer>().material.color = colors[i];
            clone.GetComponent<Keys>().keyCode=keys[i];
        }
    }
    private void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<MeshRenderer>().material.color = other.gameObject.GetComponent<MeshRenderer>().material.color;
        Destroy(other.transform.parent.gameObject);
    }
}
