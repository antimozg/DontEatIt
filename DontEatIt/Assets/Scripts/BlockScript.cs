using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BlockScript : MonoBehaviour
{
    public int hits;
    public float meatChance = 0.2f;
    public GameObject meat;
    private int countdown = 0;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int blocksCount = GameObject.FindGameObjectsWithTag("Block").Length;
        Debug.Log(blocksCount);
        Vector3 pos = this.gameObject.transform.position;
        if (collision.gameObject.tag == "Ball")
        {
            hits--;
            if (hits == 0)
            {
                if (source != null)
                {
                    source.enabled = true;
                    source.PlayOneShot(source.clip);
                }
                Destroy(this.gameObject);
            }
        }


        if (countdown == 0)
        {
            float min = 0;
            float max = 10000;
            float mid = (max - min) / 2;
            float range = max - min;
            float left = mid - range * meatChance / 2;
            float right = mid + range * meatChance / 2;
            float gen = Random.Range(min, max);
            if (gen >= left && gen <= right)
            {
                Instantiate(meat, pos, Quaternion.identity);
            }
            countdown = 1000;
        }
        countdown--;
    }
}
