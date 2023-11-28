using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ScreenShot : MonoBehaviour
    {
        [SerializeField] private Button screenshotButton;

        private void Awake()
        {
            screenshotButton.onClick.AddListener(CaptureScreenshot);
        }

        static void CaptureScreenshot()
        {
            string timestamp = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            string fileName = "Screenshot_" + timestamp + ".png";
            ScreenCapture.CaptureScreenshot(fileName);

#if PLATFORM_ANDROID
            string filePath = Application.persistentDataPath + "/" + fileName;
            string destinationPath = "/sdcard/Download/" + fileName;
            
            System.IO.File.Move(filePath, destinationPath);
#endif
        }
    }
}
