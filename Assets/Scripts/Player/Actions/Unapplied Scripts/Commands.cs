/*
* Author: Daniel Newman
* Last Edited: 15/04/18
* Summary: Commands framework to allow us to quickly remap contols using a UI panel,
* maximises flexibility and modular approach
* 
* TODO: Implement the remaining features
* TODO: Could also be refactored much like the actions
*/

using HardlightAnvil.RunWithIt.Actions;
using UnityEngine;

namespace HardlightAnvil.RunWithIt.Commands
{
    public abstract class Commands
    {

        public abstract bool Execute(GameObject player, GameObject target);
        public abstract bool Execute(GameObject player);

    }

    public class Pickup : Commands //High Priority 
    {
        public override bool Execute(GameObject player, GameObject target)
        {
            OldAction todo = ScriptableObject.CreateInstance<PickUpItem>();
            todo.Execute(player, target, true);
            return true;

            /*
            AvailableActions temp;
            temp = target.GetComponent<AvailableActions>();
            //Action toBeExecuted = temp.FindAction(PlayerActions.PickUp); //TODO: Figure out a better way to do this
            //if (toBeExecuted != null)
            //{
                //toBeExecuted.Execute(player, target);
                //return true;
            //}
            return false;
            */
        }


        public override bool Execute(GameObject player)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Throw : Commands //High Priority 
    {
        public override bool Execute(GameObject player, GameObject target)
        {
            OldAction todo = ScriptableObject.CreateInstance<ThrowItem>();
            todo.Execute(player, target, true);
            return true;

           /* AvailableActions temp;
            temp = target.GetComponent<AvailableActions>();
            /*Action toBeExecuted = temp.FindAction(PlayerActions.Throw);
            if (toBeExecuted != null)
            {
                toBeExecuted.Execute(player, target);
                return true;
            }
            return false;*/
        }


        public override bool Execute(GameObject player)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Hide : Commands //High Priority 
    {
        public override bool Execute(GameObject player, GameObject target)
        {
            OldAction todo = new HideAction();
            todo.Execute(player, target, true);
            return true;
            /*
            AvailableActions temp;
            if (target.GetComponent<AvailableActions>() != null)
            {
                temp = target.GetComponent<AvailableActions>();
                /*Action toBeExecuted = temp.FindAction(PlayerActions.Hide);
                if (toBeExecuted != null)
                {
                    toBeExecuted.Execute(player, target);
                    return true;
                }
            }
            return false;
            */
        }



        public override bool Execute(GameObject player)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Run : Commands
    {
        public override bool Execute(GameObject player)
        {
            //TODO: Implement run code
            return false;
        }

        public override bool Execute(GameObject player, GameObject target)
        {
            throw new System.NotImplementedException();
        }

    }

    public class Walk : Commands
    {
        public override bool Execute(GameObject player)
        {
            //TODO: Implement walk code
            return false;
        }

        public override bool Execute(GameObject player, GameObject target)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Vault : Commands
    {
        public override bool Execute(GameObject player)
        {
            throw new System.NotImplementedException();
        }

        public override bool Execute(GameObject player, GameObject target)
        {
            //TODO: Implement vault code
            return false;
        }


    }

    public class Swim : Commands
    {
        public override bool Execute(GameObject player)
        {
            //TODO: Implement swim code
            return false;
        }

        public override bool Execute(GameObject player, GameObject target)
        {
            throw new System.NotImplementedException();
        }

    }

    public class Use : Commands
    {
        public override bool Execute(GameObject player)
        {
            throw new System.NotImplementedException();
        }

        public override bool Execute(GameObject player, GameObject target)
        {
            //TODO: Implement use obj in environment
            //TODO: Implement use obj in inventory
            return false;
        }


    }


    public class Peek : Commands
    {
        public override bool Execute(GameObject player)
        {
            //TODO: Implement peek code
            return false;
        }

        public override bool Execute(GameObject player, GameObject target)
        {
            throw new System.NotImplementedException();
        }
    }
}