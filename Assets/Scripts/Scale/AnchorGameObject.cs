using UnityEngine;
using System.Collections;

// ȭ����ȯ �ÿ��� �� ��ġ�� ����
[ExecuteInEditMode]
public class AnchorGameObject : MonoBehaviour
{
    // ���� ��ġ
    public enum AnchorType
    {
        BottomLeft,
        BottomCenter,
        BottomRight,
        MiddleLeft,
        MiddleCenter,
        MiddleRight,
        TopLeft,
        TopCenter,
        TopRight,
    };

    public bool executeInUpdate; // Update ���� ����

    public AnchorType anchorType; // ���� ��ġ ����
    public Vector3 anchorOffset; // ���� ��ġ

    //�ڷ�ƾ �ڵ��� ����ϹǷ� �̹� ���� ���� ��� �������� �ʽ��ϴ�.
    IEnumerator updateAnchorRoutine; // �ڷ�ƾ �ڵ鷯

    // �ʱ�ȭ
    void Start()
    {
        updateAnchorRoutine = UpdateAnchorAsync();
        StartCoroutine(updateAnchorRoutine);
    }

    /// <summary>
    /// CameraFit.Instance�� null�� �ƴ� ������ ���� ��ġ�� ������Ʈ�ϴ� Coroutine
    /// </summary>
    IEnumerator UpdateAnchorAsync()
    {

        uint cameraWaitCycles = 0;

        // CameraFit.Instance�� null�̸� ���
        while (CameraViewportHandler.Instance == null)
        {
            ++cameraWaitCycles;
            yield return new WaitForEndOfFrame();
        }

        // ��� �Ŀ� CameraFit �ν��Ͻ� ã�� ���
        if (cameraWaitCycles > 0)
        {
            print(string.Format("CameraAnchor found CameraFit instance after waiting {0} frame(s). " +
                "You might want to check that CameraFit has an earlie execution order.", cameraWaitCycles));
        }

        // ���� ��ġ ������Ʈ
        UpdateAnchor();
        updateAnchorRoutine = null;

    }

    // ������ġ ������Ʈ
    void UpdateAnchor()
    {
        switch (anchorType)
        {
            case AnchorType.BottomLeft:
                SetAnchor(CameraViewportHandler.Instance.BottomLeft);
                break;
            case AnchorType.BottomCenter:
                SetAnchor(CameraViewportHandler.Instance.BottomCenter);
                break;
            case AnchorType.BottomRight:
                SetAnchor(CameraViewportHandler.Instance.BottomRight);
                break;
            case AnchorType.MiddleLeft:
                SetAnchor(CameraViewportHandler.Instance.MiddleLeft);
                break;
            case AnchorType.MiddleCenter:
                SetAnchor(CameraViewportHandler.Instance.MiddleCenter);
                break;
            case AnchorType.MiddleRight:
                SetAnchor(CameraViewportHandler.Instance.MiddleRight);
                break;
            case AnchorType.TopLeft:
                SetAnchor(CameraViewportHandler.Instance.TopLeft);
                break;
            case AnchorType.TopCenter:
                SetAnchor(CameraViewportHandler.Instance.TopCenter);
                break;
            case AnchorType.TopRight:
                SetAnchor(CameraViewportHandler.Instance.TopRight);
                break;
        }
    }

    // ���� ��ġ ����
    void SetAnchor(Vector3 anchor)
    {
        Vector3 newPos = anchor + anchorOffset;
        // ���� ��ġ�� ���ο� ��ġ�� �ٸ� ���� ��ġ�� ����
        if (!transform.position.Equals(newPos))
        {
            transform.position = newPos;
        }
    }

#if UNITY_EDITOR
    // ������Ʈ�� �����Ӵ� �� �� ȣ��
    void Update()
    {
        // updateAnchorRoutine�� null�̰� executeInUpdate�� true�� �� �ڷ�ƾ ����
        if (updateAnchorRoutine == null && executeInUpdate)
        {
            updateAnchorRoutine = UpdateAnchorAsync();
            StartCoroutine(updateAnchorRoutine);
        }
    }
#endif
}