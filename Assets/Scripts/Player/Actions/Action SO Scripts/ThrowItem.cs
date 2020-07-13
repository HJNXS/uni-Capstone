///<summary>
///need to be fixed with new code. Scriptables??
///</summary>


using UnityEngine;

namespace HardlightAnvil.RunWithIt.Actions
{
    [CreateAssetMenu(menuName = "Actions/Throw")]
    public class ThrowItem : OldAction

    {
        public GameEvent throwEvent;

      
        public override void Execute(GameObject player, GameObject target, bool isAllowed) //TODO: Apply noise when the object hits the ground. Gonna need to implement the observer pattern
        {
            //player.GetComponent<Animator>().SetBool("throw", true);
            GameObject tar = target;
            tar.transform.GetComponentInChildren<SpriteRenderer>().enabled = false;
                    tar.GetComponent<parabolaController>().FollowParabola();
                    tar.transform.parent = null;
            //tar.GetComponent<parabolaController>().stopFollow = true;
            if(throwEvent!=null)
                    throwEvent.Invoke();
        }
    }
}