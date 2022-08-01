using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public Arrow arrowprefab;
    public float spawnSpeed = 1;
    public float spawnRadius = 20;
    List<Arrow> arrows;
    private int numArrows = 50;
    

    // Start is called before the first frame update
    void Start()
    {
        arrows = new List<Arrow>();
        for (int x = 0; x < numArrows; x++)
        {
            Arrow arrow = Instantiate(arrowprefab);
            arrow.gameObject.SetActive(false);
            arrows.Add(arrow);
        }

        StartCoroutine(Shoot());

    }

    IEnumerator Shoot()
    {
        //Shooting code
        //Spawn projectile, put it at a random position around the edge of the map, have it come inwards
        Arrow projectile = GetPooledObject();
        projectile.gameObject.SetActive(true);

        projectile.transform.position = new Vector3(Random.Range(78, 109) + transform.position.x, transform.position.y, transform.position.z);
        //projectile.transform.LookAt(transform.up);

        //projectile.gameObject.transform.position = RandomCircle(transform.position, 5.0f);
        //projectile.transform.LookAt(transform.position);
        
        yield return new WaitForSeconds(spawnSpeed);
        StartCoroutine(Shoot());
    }

    public Arrow GetPooledObject()
    {
        //1
        for (int i = 0; i < arrows.Count; i++)
        {
            //2
            if (!arrows[i].gameObject.activeInHierarchy)
            {
                return arrows[i];
            }
        }
        //3   
        return null;
    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad); 
        return pos;
    }


}
