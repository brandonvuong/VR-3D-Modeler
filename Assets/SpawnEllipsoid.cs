using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEllipsoid : MonoBehaviour
{
    [SerializeField] private GameObject ellipsoid; // drag the dominant hand into this blank in the inspector
    [SerializeField] private GameObject pov;

    // Start is called before the first frame update
    /*    private void Start()
        {
            Vector3 cylinderSpawnPos = new Vector3(pov.transform.position.x, pov.transform.position.y, pov.transform.position.z + 0.5f);
            Instantiate(cylinder, cylinderSpawnPos, Quaternion.identity);
        }*/
    // Update is called once per frame
    public void SpawnTheEllipsoid()
    {
        Vector3 ellipsoidSpawnPos = new Vector3(pov.transform.position.x, pov.transform.position.y + 0.7f, pov.transform.position.z + 0.07f);
        Instantiate(ellipsoid, ellipsoidSpawnPos, Quaternion.identity);
    }
}
