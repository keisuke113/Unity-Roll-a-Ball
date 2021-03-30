using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20; // 動く速さ

    public Text scoreText; // スコアのUI

    public Text winText; // リザルトのUI


    private Rigidbody rb; // Rigidbody

    private int score; // スコア


    // Start is called before the first frame update
    void Start()
    {
        // Rigidbodyを取得
        rb = GetComponent<Rigidbody>();

        // UIを初期化
        score = 0;
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");

        var moveVertical = Input.GetAxis("Vertical");

        // カーソルキーの入力に合わせて移動方向を設定
        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        // Rigidbodyに力を与えて球を動かす
        rb.AddForce(movement * speed);
    }

    // 球が他のオブジェクトにぶつかったときに呼び出される
    void OnTriggerEnter(Collider other)
    {
        // ぶつかったオブジェクトが収集アイテムだった場合
        if (other.gameObject.CompareTag("Pick Up"))
        {
            // そのアイテムを非表示にします
            other.gameObject.SetActive(false);

            // スコアを加算します
            score = score + 1;

            // UIの表示を更新します
            SetCountText();
        }
    }

    // UIの表示を更新する
    void SetCountText()
    {
        // スコアの表示を更新
        scoreText.text = "Count: " + score.ToString();

        // すべての収集アイテムを獲得した場合
        if (score >= 12)
        {
            // リザルトの表示を更新
            winText.text = "You Win!";
        }
    }
}
