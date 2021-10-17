using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
        switch(other.gameObject.tag)
        {
            case "Friendly":
                print("This is friendly");
                break;
            case "Finish":
                print("Congrates! You Won");
                break;
            case "Fuel":
                print("You got Fuel");
                break;
            default:
                
                print("Sorry, you blew up");
                break;
        }
    }

}
