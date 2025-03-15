using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;

public class Pathfinding : MonoBehaviour
{
    public Tilemap tilemap;
    public Vector3Int position;

    public Transform target;
    private void Start()
    {
       Debug.Log( tilemap.GetTile(Vector3Int.zero));
        MoveToTile(new Vector3Int(1, 1, 0));
        StartCoroutine(walk());
        
    }
    
    private void Update()
    {
        
    }
    private IEnumerator walk()
    {
        while (true)
        {
            yield return MoveToTile(tilemap.WorldToCell(target.position));
        }
        
            
        
    }
    private IEnumerator MoveToTile(Vector3Int tilePos)
    {
        const float moveTime = 5;
        float startTime = Time.time;
        Vector3 origin = transform.position;
        Vector3 destination = tilemap.CellToWorld(tilePos);
        while (Time.time < startTime + moveTime)
        {
            transform.position = Vector3.Lerp(origin, destination, Mathf.InverseLerp(startTime,startTime+moveTime,Time.time));
            
            yield return new WaitForSeconds(0);

        }
        transform.position = destination;
    }
    
}
