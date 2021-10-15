using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Visuals
{
	public class Version : MonoBehaviour
	{
		[RuntimeInitializeOnLoadMethod]
		private static void Show()
		{
			GameObject canvasVersion = new GameObject("CanvasVersion");
			Canvas canvas = canvasVersion.AddComponent<Canvas>();
			canvas.renderMode = RenderMode.ScreenSpaceOverlay; 
			canvas.sortingOrder = 32000;
			CanvasScaler canvasScaler = canvasVersion.AddComponent<CanvasScaler>();
			canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
			canvasScaler.referenceResolution = new Vector2(1920, 1080);
			canvasVersion.AddComponent<GraphicRaycaster>();

			GameObject textVersion = new GameObject("TextVersion");
			textVersion.transform.SetParent(canvasVersion.transform);

			Text version = textVersion.AddComponent<Text>();
			version.text = "Version: " + Application.version;
			version.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
			version.fontStyle = FontStyle.Normal;
			version.alignment = TextAnchor.LowerRight;
			version.color = Color.red;

			RectTransform rectTransformVersion = textVersion.GetComponent<RectTransform>();
			rectTransformVersion.sizeDelta = new Vector2(120, 30);
			rectTransformVersion.anchorMin = new Vector2(1, 0);
			rectTransformVersion.anchorMax = new Vector2(1, 0);
			rectTransformVersion.pivot = new Vector2(1, 0);
			rectTransformVersion.anchoredPosition = new Vector2(-50, 50);

			Object.Destroy(canvasVersion, 10);
		}
	}
}