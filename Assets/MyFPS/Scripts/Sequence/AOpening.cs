using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFPS
{
    public class AOpening : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private TMP_Text openingText;
        [SerializeField] private string opening_text = "I need get out of here";

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Opening());
        }

        IEnumerator Opening()
        {
            //0.�÷��� ĳ���� �� Ȱ��ȭ
            //1.���̵��� ����(1�� ����� ���ε��� ȿ��)
            //2.ȭ�� �ϴܿ� �ó����� �ؽ�Ʈ ȭ�� ���(3��)
            //  (I need get out of here)
            //3. 3���Ŀ� �ó����� �ؽ�Ʈ ��������
            //4.�÷��� ĳ���� Ȱ��ȭ

            player.SetActive(false);
            openingText.text = opening_text;
            openingText.gameObject.SetActive(true);
            SceneFade.instance.FadeIn(null, 1f);

            yield return new WaitForSeconds(3f);

            openingText.gameObject.SetActive(false);
            player.SetActive(true);
        }
    }
}