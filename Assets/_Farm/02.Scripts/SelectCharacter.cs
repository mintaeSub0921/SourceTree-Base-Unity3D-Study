using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Farm
{

    public class SelectCharacter : MonoBehaviour
    {
        [SerializeField] private Transform centerPivot;
        
        [SerializeField] private Animator[] characterAnims;

        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;
        [SerializeField] private Button selectButton;

        private int characterIndex;
        
        private bool isTurn; // 캐릭터가 회전 중일 때 돌아가지 않게 막으려는 의도

        private void Start()
        {
            leftButton.onClick.AddListener(TurnLeft);
            rightButton.onClick.AddListener(TurnRight);
            selectButton.onClick.AddListener(Select);
        }

        private void TurnLeft()
        {
            if (isTurn)
                return;

            characterIndex--;
            if (characterIndex < 0)
                characterIndex = 3;

            var targetRot = centerPivot.rotation * Quaternion.Euler(0, -90, 0);
            StartCoroutine(TurnRoutine(targetRot));
        }

        private void TurnRight()
        {
            if (isTurn)
                return;

            characterIndex++;
            if (characterIndex > 3)
                characterIndex = 0;

            var targetRot = centerPivot.rotation * Quaternion.Euler(0, 90, 0);
            StartCoroutine(TurnRoutine(targetRot));


        }

        IEnumerator TurnRoutine(Quaternion targetRot)
        {
            isTurn = true;

            while (isTurn)
            {
                centerPivot.rotation = Quaternion.Slerp(centerPivot.rotation, targetRot, 10f * Time.deltaTime);
                yield return null;

                var angle = Quaternion.Angle(centerPivot.rotation, targetRot);
                if (angle <= 0.1f)
                {
                    isTurn = false;
                    centerPivot.rotation = targetRot;
                    Debug.Log($"{characterIndex}번 캐릭터 회전 완료");
                }
            }
        }

        private void Select()
        {
            DataManager.Instance.SelectCharacterIndex = characterIndex; // 현재 선택한 캐릭터 인덱스 저장
            
            StartCoroutine(SelectRoutine());
        }

        IEnumerator SelectRoutine()
        {
            
            characterAnims[characterIndex].SetTrigger("Dance");
            yield return new WaitForSeconds(5f);

            FadeEvent.fadeAction?.Invoke(3f, Color.black, true);
            yield return new WaitForSeconds(3f);

            Debug.Log("씬 전환");


        }


    }

}