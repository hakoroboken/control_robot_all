using UnityEngine;
using TMPro;
using System.Globalization;

public class MoveText : MonoBehaviour
{
    [SerializeField] private Gradient gradientColor;
    private TMP_Text textComponent;
    private TMP_TextInfo textInfo;
    public TextMeshProUGUI movetext;

    private void Update()
    {
        if (this.textComponent == null)
            this.textComponent = GetComponent<TMP_Text>();

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        // �@ ���b�V�����Đ�������i���Z�b�g�j
        this.textComponent.ForceMeshUpdate(true);
        this.textInfo = textComponent.textInfo;

        // �A���_�f�[�^��ҏW�����z��̍쐬
        var count = Mathf.Min(this.textInfo.characterCount, this.textInfo.characterInfo.Length);
        for (int i = 0; i < count; i++)
        {
            var charInfo = this.textInfo.characterInfo[i];
            if (!charInfo.isVisible)
                continue;

            int materialIndex = charInfo.materialReferenceIndex;
            int vertexIndex = charInfo.vertexIndex;

            // Wave
            Vector3[] verts = textInfo.meshInfo[materialIndex].vertices;

            float sinWaveOffset = 0.5f * i;
            float sinWave = Mathf.Sin(sinWaveOffset + Time.realtimeSinceStartup * Mathf.PI);
            verts[vertexIndex + 0].y += sinWave;
            verts[vertexIndex + 1].y += sinWave;
            verts[vertexIndex + 2].y += sinWave;
            verts[vertexIndex + 3].y += sinWave;
        }

        // �B ���b�V�����X�V
        for (int i = 0; i < this.textInfo.materialCount; i++)
        {
            if (this.textInfo.meshInfo[i].mesh == null) { continue; }

            textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
            textComponent.UpdateGeometry(this.textInfo.meshInfo[i].mesh, i);
        }
    }
}