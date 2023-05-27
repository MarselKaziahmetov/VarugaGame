using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSystem : MonoBehaviour
{
    [System.Serializable]
    private class DropItem
    {
        public GameObject itemPrefab;
        public float dropChance;
    }

    [SerializeField] private DropItem[] dropItems;
    [SerializeField] private GameObject spawnOrb;

    /*private void OnDestroy()
    {
        foreach (DropItem dropItem in dropItems)
        {
            if (Random.Range(0f,100f) <= dropItem.dropChance)
            {
                Instantiate(dropItem.itemPrefab, transform.position + Vector3.up/5, Quaternion.identity);
            }
        }

        Instantiate(spawnOrb, transform.position, transform.rotation);
    }
*/
    public void DropItems()
    {
        foreach (DropItem dropItem in dropItems)
        {
            if (Random.Range(0f, 100f) <= dropItem.dropChance)
            {
                Instantiate(dropItem.itemPrefab, transform.position + Vector3.up / 5, Quaternion.identity);
            }
        }

        Instantiate(spawnOrb, transform.position, transform.rotation);
    }
}
