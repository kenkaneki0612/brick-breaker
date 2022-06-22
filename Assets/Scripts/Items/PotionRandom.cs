using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionRandom : MonoBehaviour
{

    [SerializeField] List<GameObject> listPotion;
    private List<GameObject> blocks;
    private int randomPotion = 10;

    private bool ok;
    // Start is called before the first frame update
    void Start()
    {
        blocks = new List<GameObject>(GameObject.FindGameObjectsWithTag("Breakable"));

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void RandomPotion()
    {
        int number = Random.Range(0, 10);

        for (int i = 0; i < blocks.Count; i++)
        {
            if (blocks[i].gameObject.activeInHierarchy == false)
            {
                if (number < randomPotion)
                {
                    int index = Random.Range(0, 4);

                    switch (index)
                    {
                        case 0:
                            Instantiate(listPotion[index], blocks[i].transform.position, Quaternion.identity);
                            break;
                        case 1:
                            Instantiate(listPotion[index], blocks[i].transform.position, Quaternion.identity);
                            break;
                        case 2:
                            Instantiate(listPotion[index], blocks[i].transform.position, Quaternion.identity);
                            break;
                        case 3:
                            Instantiate(listPotion[index], blocks[i].transform.position, Quaternion.identity);
                            break;
                    }
                }

                ok = true;
            }

            if (ok == true)
            {
                blocks.Remove(blocks[i]);
                ok = false;
            }
        }
    }
}
