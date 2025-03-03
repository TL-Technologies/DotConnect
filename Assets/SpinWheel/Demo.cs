using UnityEngine;
using EasyUI.PickerWheelUI;
using UnityEngine.UI;
using GameBug;

public class Demo : MonoBehaviour
{
    [SerializeField] private Button uiSpinButton;
    [SerializeField] private GameObject SpinWheelScreenReward;
    [SerializeField] private GameObject SpinWheelScreen;
    [SerializeField] private Text uiSpinButtonText;

    [SerializeField] private PickerWheel pickerWheel;

    [Header("Main Canvas")]
    [SerializeField] public Canvas mainCanvas;

    [Header("Win Particles")]
    [SerializeField] public GameObject Particles;
    private void Start()
    {
        uiSpinButton.onClick.AddListener(() =>
        {

            uiSpinButton.interactable = false;
            uiSpinButtonText.text = "SPINING";

            pickerWheel.OnSpinEnd(wheelPiece =>
            {
                Debug.Log(
                   @" <b>Index:</b> " + wheelPiece.Index + "           <b>Label:</b> " + wheelPiece.Label
                   + "\n <b>Amount:</b> " + wheelPiece.Amount + "      <b>Chance:</b> " + wheelPiece.Chance + "%"
                );

                GameBug.DotConnect.GameManager.Instance.GiveHints(wheelPiece.Amount);
                SoundManager.Instance.Play("level-completed");
                SpinWheelScreenReward.SetActive(true);
                mainCanvas.renderMode = RenderMode.ScreenSpaceCamera;
                Particles.SetActive(true);
                uiSpinButton.interactable = true;
                uiSpinButtonText.text = "SPIN";

            });

            pickerWheel.Spin();

        });

    }

    public void ChangeCanvasRenderMode()
    {
        mainCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        Particles.SetActive(false);
        LeanTween.moveLocalX(SpinWheelScreen, 2000, 0.35f).setEaseOutElastic();
    }

}
