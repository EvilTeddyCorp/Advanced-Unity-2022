using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class MeshVision : MonoBehaviour
{
    private Mesh mesh;
    public Material material;
    public GameObject enemy;
    private Vector3 origin;
    enemy Enemy;
    public float fov = 360;
    public float haluttufov = 45;   // se kartio
    private float StartingAngle;
    
    public int raycount = 400;
    public float viewdistance = 20f;
    public float smallviewdistance = 2f;

    // Start is called before the first frame update
    void Start()
    {

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        Enemy = enemy.GetComponent<enemy>();
        origin = enemy.transform.position;
                                   
        
      
    }
    private void Update()
    {

            origin = enemy.transform.position;
            Setaimdirection(-enemy.transform.up);


            /* 
             * Tää script tekee kartio meshin jonka muoto ottaa huomioon
             * objectit jotka tulevat tielle (raycast)
             * Tän idea on simuloida vihollisen näkökenttää, eli jos 
             * pelaaja menee sen sisälle, niin vihollinen alkaa jahtaamaan 
             * pelaajaa
             */

            float angle = StartingAngle;
            float angleincrease = fov / raycount;
            float jakaja = fov / haluttufov;  // 360 / 45 = 8 eli 45 astetta on se kartio 



            Vector3[] vertices = new Vector3[raycount + 1 + 1];
            Vector2[] uv = new Vector2[vertices.Length];
            int[] triangles = new int[raycount * 3];

            vertices[0] = origin; // origin
            int vertexindex = 1;
            int triangelindex = 0;
            for (int i = 0; i <= raycount; i++)
            {

                LayerMask mask = LayerMask.GetMask("Wall", "player", "IgnoreAstarpath");
                Vector3 vertex = new Vector3();
            
                if (i <= ((raycount - (raycount / jakaja)) / 2))
                {
                    RaycastHit2D raycastH = Physics2D.Raycast(origin, new Vector3(Mathf.Cos(angle * (Mathf.PI / 180f)), Mathf.Sin(angle * (Mathf.PI / 180f))), smallviewdistance, mask);


                    if (raycastH.collider == null)
                    {

                        vertex = origin + new Vector3(Mathf.Cos(angle * (Mathf.PI / 180f)), Mathf.Sin(angle * (Mathf.PI / 180f))) * smallviewdistance;

                    }
                    else
                    {

                        vertex = origin + new Vector3(Mathf.Cos(angle * (Mathf.PI / 180f)), Mathf.Sin(angle * (Mathf.PI / 180f))) * raycastH.distance;

                    }
                    if (Enemy.VisionHu == true && raycastH.collider?.gameObject.layer == LayerMask.NameToLayer("player")) // että pelaaja huomataan
                    {
                        Enemy.VisionFound(true);
                    }
     

                }
                else if (i <= (raycount / jakaja + ((raycount - (raycount/jakaja))/2)))
                {
                    RaycastHit2D raycastH = Physics2D.Raycast(origin, new Vector3(Mathf.Cos(angle * (Mathf.PI / 180f)), Mathf.Sin(angle * (Mathf.PI / 180f))), viewdistance, mask);
                   

                    if (raycastH.collider == null)
                    {

                        vertex = origin + new Vector3(Mathf.Cos(angle * (Mathf.PI / 180f)), Mathf.Sin(angle * (Mathf.PI / 180f))) * viewdistance;

                    }
                    else
                    {

                        vertex = origin + new Vector3(Mathf.Cos(angle * (Mathf.PI / 180f)), Mathf.Sin(angle * (Mathf.PI / 180f))) * raycastH.distance;

                    }
                    if (Enemy.VisionHu == true && raycastH.collider?.gameObject.layer == LayerMask.NameToLayer("player")) // että pelaaja huomataan
                    {
                        Enemy.VisionFound(true);
                    }

                }
                else if (i <= (raycount))
                {
                    RaycastHit2D raycastH = Physics2D.Raycast(origin, new Vector3(Mathf.Cos(angle * (Mathf.PI / 180f)), Mathf.Sin(angle * (Mathf.PI / 180f))), smallviewdistance, mask);


                    if (raycastH.collider == null)
                    {

                        vertex = origin + new Vector3(Mathf.Cos(angle * (Mathf.PI / 180f)), Mathf.Sin(angle * (Mathf.PI / 180f))) * smallviewdistance;

                    }
                    else
                    {

                        vertex = origin + new Vector3(Mathf.Cos(angle * (Mathf.PI / 180f)), Mathf.Sin(angle * (Mathf.PI / 180f))) * raycastH.distance;

                    }
                    if (Enemy.VisionHu == true && raycastH.collider?.gameObject.layer == LayerMask.NameToLayer("player")) // että pelaaja huomataan
                    {
                        Enemy.VisionFound(true);
                    }
                }

                vertices[vertexindex] = vertex;

                if (i > 0)
                {
                    triangles[triangelindex + 0] = 0;
                    triangles[triangelindex + 1] = vertexindex - 1;
                    triangles[triangelindex + 2] = vertexindex;

                    triangelindex += 3;
                }




                vertexindex++;
                angle -= angleincrease;

            }




            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles;
            mesh.RecalculateBounds();
        
        
     


    }

    public void Setaimdirection(Vector3 aimDirection)                    // että mesh osottaa sinne mihin vihollinen osoittaa
    {
        StartingAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
      //  if (StartingAngle < 0) {StartingAngle += 360; }
        StartingAngle -= (360 - fov) / 2;
    }

    




}
