using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ImageButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler  //鼠标移入，鼠标移出，鼠标按下，鼠标松开，鼠标点击（松开时触发
{
    private Vector3 originalScale;//记录初始缩放
    public string targetScene;

    private void Start()
    {
        originalScale = transform.localScale;// 启动时记录初始缩放比例
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = originalScale * 1.1f; // 放大
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalScale; // 恢复
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = originalScale * 0.9f; // 缩小
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = originalScale * 1.1f; // 回到悬停状态
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(targetScene);
    }
}


