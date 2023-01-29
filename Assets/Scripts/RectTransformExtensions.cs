using UnityEngine;
using DG.Tweening;
 public static class RectTransformExtensions
 {
     public static void SetLeft(RectTransform rt, float left,float duration)
     {
         DOTween.To(()=>rt.offsetMax,x=> rt.offsetMax=x, new Vector2(left, rt.offsetMin.y),duration);
     }
 
     public static void SetRight( RectTransform rt, float right,float duration)
     {
        DOTween.To(()=>rt.offsetMax,x=> rt.offsetMax=x, new Vector2(-right, rt.offsetMax.y),duration);
     }
 
     public static void SetTop( RectTransform rt, float top,float duration)
     {
         DOTween.To(()=>rt.offsetMax,x=> rt.offsetMax=x, new Vector2(rt.offsetMax.x, -top),duration);
     }
 
     public static void SetBottom( RectTransform rt, float bottom,float duration)
     {
         DOTween.To(()=>rt.offsetMax,x=> rt.offsetMax=x, new Vector2(rt.offsetMin.x, bottom),duration);
     }
 }