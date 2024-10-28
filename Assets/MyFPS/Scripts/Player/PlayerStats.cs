using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFPS
{
    // ���� ������ ȹ�濩��
    public enum ItemType
    {
        Room01_Key,
        Room02_Key,
        Room03_Key,
        LeftEye,
        RightEye,
        Max_Key         // ���� ������ ����
    }


    // �÷��̾��� �Ӽ� ���� �����ϴ� (�̱���, ) Ŭ����
    public class PlayerStats : PersistentSingleton<PlayerStats>    
    {
        // ���� ���� ������ Ű
        private List<bool> puzzleKeys = new List<bool>();


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

            for(int i = 0; i < (int)ItemType.Max_Key; i++)
            {
                puzzleKeys.Add(false);
            }
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

        // ���� ������ ȹ��
        public void GetPuzzleObject(ItemType key)
        {
            puzzleKeys[(int)key] = true;
        }

        // ���� ������ ���� ����
        public bool HasPuzzleObject(ItemType key)
        {
            return puzzleKeys[(int)key];
        }


    }

}
