using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFPS
{
    // 플레이어의 속성 값을 관리하는 (싱글톤, ) 클래스
    public class PlayerStats : PersistentSingleton<PlayerStats>    
    {
        [SerializeField] private TMP_Text ammoCount_Text;

        private int ammoCount;

        public int AmmoCount
        {
            get { return ammoCount; }
            set { ammoCount = value; }
        }

        // Start is called before the first frame update
        void Start()
        {
            AmmoCount = 0;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void GetAmmo(int count)
        {
            AmmoCount += count;
            ammoCount_Text.text = AmmoCount.ToString();

        }

        public bool UseAmmo(int count)
        {

            if(AmmoCount < count)
            {
                return false;
            }

            
            AmmoCount -= count;
            ammoCount_Text.text = AmmoCount.ToString();

            return true;
        }

        public int UseAmmo()
        {
            AmmoCount--;
            ammoCount_Text.text = AmmoCount.ToString();
            return AmmoCount;
        }


    }

}
