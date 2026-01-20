using Cysharp.Threading.Tasks;
using UnityEngine;

public class StudyUniTask : MonoBehaviour
{
    async void Start()
    {
        await UniTask.Yield();

        await UniTask.WaitForSeconds(1f);
    }
}
