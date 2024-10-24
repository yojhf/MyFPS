using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class PickUpKey : Interactive
    {

        protected override void Action()
        {
            base.Action();

            PlayerStats.Instance.GetPuzzleObject(ItemType.Room01_Key);

            Destroy(gameObject);
        }
    }
}