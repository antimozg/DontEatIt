using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public int hits;
    public float meatChance = 0.1f; //Вероятность появления мяса
    public Transform meat;
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
        Vector3 pos = new Vector3(this.gameObject.transform.position.x,
            this.gameObject.transform.position.y,
            this.gameObject.transform.position.z);
        if (collision.gameObject.tag == "Ball")
        {
            hits--;
            if (hits == 0)
            {
                Destroy(this.gameObject);
            }
            float min = 0;
            float max = 100000;
            float mid = (max - min) / 2;
            float range = max - min;
            float generated = Random.Range(min, max);
            if (generated >= mid-range*meatChance/2 && generated <= mid + range * meatChance / 2)
            {
                Instantiate(meat, pos, Quaternion.identity);
            }
        }
    }
}
