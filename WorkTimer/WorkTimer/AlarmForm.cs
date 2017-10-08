using System;
using System.Drawing;
using System.Windows.Forms;

namespace WorkTimer
{
    /// <summary>
    /// アラーム画面
    /// </summary>
    public partial class AlarmForm : Form
    {
        #region デリゲート型定義

        /// <summary>親フォーム更新処理用デリゲート型</summary>
        public delegate void UpdateParentDelegate();

        #endregion // デリゲート型定義

        #region 定数

        /// <summary>画面保持時間 [ミリ秒]</summary>
        private const int DURATION = 5000;
        /// <summary>RGBの最大値</summary>
        private const int RGB_MAX = 255;

        #endregion // 定数

        #region プロパティ

        /// <summary>親フォーム更新処理</summary>
        public UpdateParentDelegate UpdateParentHandler { private get; set; }

        #endregion // プロパティ

        #region privateフィールド

        /// <summary>画面表示時刻</summary>
        private DateTime startTime;
        /// <summary>背景色制御用カウンタ</summary>
        private int count;
        /// <summary>RGB値増減フラグ (true: 増加 / false: 減少)</summary>
        private bool isIncrementing;

        #endregion // privateフィールド

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        private AlarmForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="parent">親フォーム</param>
        public AlarmForm(TimerForm parent)
            : this()
        {
            this.Size = parent.Size;
        }

        #endregion // コンストラクタ

        // イベントハンドラー

        #region [イベント] フォーム表示
        /// <summary>
        /// [イベント] フォーム表示
        /// </summary>
        private void AlarmForm_Shown(object sender, EventArgs e)
        {
            this.startTime = DateTime.Now;
            this.count = 0;
            this.isIncrementing = true;

            if (this.UpdateParentHandler != null)
            {
                this.UpdateParentHandler();
            }

            this.flashTimer.Enabled = true;
            this.flashTimer.Interval = 10;
            this.flashTimer.Start();

        }
        #endregion // [イベント] フォーム表示

        #region [イベント] タイマー通知
        /// <summary>
        /// [イベント] タイマー通知
        /// </summary>
        private void flashTimer_Tick(object sender, EventArgs e)
        {
            UpdateFormColor();
        }
        #endregion // [イベント] フォームロード

        #region [イベント] フォームクリック
        /// <summary>
        /// [イベント] フォームクリック
        /// </summary>
        private void AlarmForm_Click(object sender, EventArgs e)
        {
            if (IsExpired())
            {
                CloseForm();
            }
        }
        #endregion // [イベント] フォームクリック

        #region [イベント] フォーム上でのキー入力
        /// <summary>
        /// [イベント] フォーム上でのキー入力
        /// </summary>
        private void AlarmForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (IsExpired())
            {
                CloseForm();
            }
        }
        #endregion // フォーム上でのキー入力

        // privateメソッド

        #region UpdateAlarmColor
        /// <summary>
        /// フォームの背景色を更新します。
        /// </summary>
        private void UpdateFormColor()
        {
            int countBorder = this.isIncrementing ? RGB_MAX * 3 : 0;
            this.count = (this.isIncrementing) ? Math.Min(this.count + 5, countBorder)
                                                : Math.Max(this.count - 5, countBorder);
            if (this.count == countBorder)
            {
                this.isIncrementing = !this.isIncrementing;
            }

            int redIntensity = Math.Max(Math.Min(this.count, RGB_MAX), 0);
            int greenIntensity = Math.Max(Math.Min(this.count - RGB_MAX, RGB_MAX), 0);
            int blueIntensity = Math.Max(Math.Min(this.count - RGB_MAX * 2, RGB_MAX), 0);

            this.BackColor = Color.FromArgb(redIntensity, greenIntensity, blueIntensity);
        }
        #endregion // UpdateAlarmColor

        #region CloseForm
        /// <summary>
        /// 必要な準備を行ってからフォームを閉じます。
        /// </summary>
        private void CloseForm()
        {
            this.flashTimer.Stop();
            Close();
        }
        #endregion // CloseForm

        #region IsExpired
        /// <summary>
        /// 画面表示から一定時間が経過しているかを調べます。
        /// </summary>
        /// <returns>true: 経過している / false: </returns>
        private bool IsExpired()
        {
            return DURATION <= (DateTime.Now - this.startTime).TotalMilliseconds;
        }
        #endregion // IsExpired
    }
}