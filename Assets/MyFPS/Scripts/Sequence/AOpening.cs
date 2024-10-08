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
            //0.플레이 캐릭터 비 활성화
            //1.페이드인 연출(1초 대기후 페인드인 효과)
            //2.화면 하단에 시나리오 텍스트 화면 출력(3초)
            //  (I need get out of here)
            //3. 3초후에 시나리오 텍스트 없어진다
            //4.플레이 캐릭터 활성화

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