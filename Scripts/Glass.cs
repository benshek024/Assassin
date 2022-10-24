using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    public bool isBroken = false;
    private bool isAssignedGlass = false;

    [Header("Normal Glass")]
    [Tooltip("Assign normal unbroken glass game object into here.")]
    [SerializeField] private GameObject glass;

    [Header("Broken Glass")]
    [Tooltip("A game object where it will be Instantiated on current glass position when a glass is being shot.")]
    [SerializeField] private GameObject brokenGlass;

    [Header("Object to Interact")]
    [Tooltip("Assign which enemy you want it to be triggered when the glass is destroyed.")]
    public GameObject enemy;
    private Level1Enemy level1Enemy;

    // Start is called before the first frame update
    private void Start()
    {
        if (enemy != null)
        {
            level1Enemy = enemy.GetComponent<Level1Enemy>();
            level1Enemy.brokenGlass = gameObject;   // Set glass to become the brokenGlass variable of Level1Enemy temporarily
            isAssignedGlass = true;
        }
        else
        {
            enemy = null;
            isAssignedGlass = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // Execute AssignedGlassBroke function
        if (isBroken && isAssignedGlass && enemy != null)
        {
            AssignedGlassBroke();
        }
        else if (isBroken) // Execute UnassignedGlassBroke function if the glass was not assigned to an enemy or the enemy is dead.
        {
            UnassignedGlassBroke();
        }
    }

    // Instantiate a broken glass clone and destroy previous glass game object, but it will trigger a UnassignedReferenceException error,
    // so we need to reassign brokenGlassClone as the brokenGlass variable for Level1Enemy to prevent this error from happening.
    public void AssignedGlassBroke()
    {
        GameObject brokenGlassClone =  Instantiate(brokenGlass, glass.transform.position, glass.transform.rotation);
        Destroy(glass);
        level1Enemy.brokenGlass = brokenGlassClone;
        level1Enemy.isWalk = true;                      // Set isWalk is true for enemy to make it walking
        level1Enemy.Curious();                          // Execute Curious function in Level1Enemy.
    }

    // Mostly function just like AssignedGlassBroken but for glasses that are not assigned with an enemy to trigger to.
    public void UnassignedGlassBroke()
    {
        GameObject brokenGlassClone = Instantiate(brokenGlass, glass.transform.position, glass.transform.rotation);
        Destroy(glass);
    }
}
