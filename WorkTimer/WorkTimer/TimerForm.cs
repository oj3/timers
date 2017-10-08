using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WorkTimer
{
    /// <summary>
    /// タイマー画面
    /// </summary>
    public partial class TimerForm : Form
    {
        #region private 定数、列挙体

        /// <summary>
        /// タイマーの状態
        /// </summary>
        private enum TimerState
        {
            /// <summary>計時中</summary>
            Active = 0,
            /// <summary>一時停止中</summary>
            Paused,
            /// <summary>アラーム鳴動中</summary>
            AlarmSignaling,
            /// <summary>計時終了</summary>
            Finished
        }

        /// <summary>
        /// ボタンの状態
        /// </summary>
        private enum ButtonState
        {
            /// <summary>アクティブ</summary>
            Active = 0,
            /// <summary>非アクティブ</summary>
            NotActive
        }

        /// <summary>
        /// ロックの状態
        /// </summary>
        private enum LockState
        {
            /// <summary>ロック中</summary>
            Locked = 0,
            /// <summary>ロックなし</summary>
            UnLocked
        }

        /// <summary>
        /// UP/DOWN
        /// </summary>
        private enum UpDown
        {
            /// <summary>UP</summary>
            Up = 0,
            /// <summary>DOWN</summary>
            Down
        }

        /// <summary>時刻表示のフォーマット</summary>
        private const string TIME_FORMAT = "{0:000}:{1:00}.{2:000}";

        /// <summary>デフォルトのタイマー設定時間</summary>
        private static readonly TimeSpan DEFAULT_TIME_SPAN = new TimeSpan(0, 0, 25, 0, 0);
        /// <summary>デフォルトのステップ</summary>
        private const int DEFAULT_STEP = 5;

        /// <summary>時刻設定最大値 [分]</summary>
        private const int MIN_MAX = 999;
        /// <summary>時刻設定最大値 [秒]</summary>
        private const int SEC_MAX = 59;
        /// <summary>時刻設定最大値 [ミリ秒]</summary>
        private const int MILLISEC_MAX = 999;
        /// <summary>ステップ設定最大値</summary>
        private const int STEP_MAX = 10;
        /// <summary>UP/DOWNボタンによる設定値変更を一時停止する時間の長さ [ミリ秒]</summary>
        private const int STOP_UPDOWN_INTERVAL = 300;

        /// <summary>ボタンアイコン - 開始</summary>
        private const string START_ICON = "●";
        /// <summary>ボタンアイコン - 停止</summary>
        private const string STOP_ICON = "■";
        /// <summary>ボタンアイコン - リセット</summary>
        private const string RESET_ICON = "○";
        /// <summary>ボタンアイコン - ロック</summary>
        private const string LOCK_ICON = "〆";
        /// <summary>ボタンアイコン - ロック解除</summary>
        private const string UNLOCK_ICON = "¶";

        /// <summary>ボタンの背景色 - アクティブ時</summary>
        private static readonly Color BUTTON_COLOR_ACTIVE = SystemColors.GradientActiveCaption;

        #endregion // private 定数、列挙体

        #region private フィールド

        /// <summary>現在の残り時間</summary>
        private TimeSpan remainingTime;
        /// <summary>前回の設定時間</summary>
        private TimeSpan prevTimeSetting;
        /// <summary>前回のタイマーTick時刻</summary>
        private DateTime prevTickTime;

        /// <summary>タイマーの状態</summary>
        private TimerState state;
        /// <summary>タイマー開始ボタンのロックフラグ (true: ロック中 / false: ロックなし)</summary>
        private bool isLocked;

        /// <summary>ステップ設定値</summary>
        private int step;
        /// <summary>UP/DOWNボタンによる設定値変更を一時停止した時刻</summary>
        private DateTime stopUpDownTime;

        /// <summary>最後に選択した時間設定DOWNボタン</summary>
        private Button prevTimeDownButton;
        /// <summary>↑キー入力時のコントロール移動先設定</summary>
        private Dictionary<Control, Control> controlMapUp;
        /// <summary>↓キー入力時のコントロール移動先設定</summary>
        private Dictionary<Control, Control> controlMapDown;
        /// <summary>←キー入力時のコントロール移動先設定</summary>
        private Dictionary<Control, Control> controlMapLeft;
        /// <summary>→キー入力時のコントロール移動先設定</summary>
        private Dictionary<Control, Control> controlMapRight;

        /// <summary>非アクティブ時のボタン背景色</summary>
        private Color inactiveButtonColor;

        #endregion // private フィールド

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TimerForm()
        {
            InitializeComponent();

            this.timeLabel.Location = new Point(16, 18);
            this.timeLabel.Text = "";
            this.timeLabel.Visible = false;

            this.remainingTime = DEFAULT_TIME_SPAN;
            this.prevTimeSetting = DEFAULT_TIME_SPAN;
            this.prevTickTime = DateTime.Now;
            this.step = DEFAULT_STEP;
            UpdateTextBoxes(this.prevTimeSetting, this.step);

            this.state = TimerState.Finished;
            UpdateControls(this.state);

            this.prevTimeDownButton = this.minDownButton;
            SetButtonMaps();

            this.mainTimer.Enabled = true;
            this.mainTimer.Interval = 11;

            this.ActiveControl = this.startButton;
            this.isLocked = false;
        }
        #endregion // コンストラクタ

        // イベントハンドラー

        #region [イベント] 文字以外のキー入力
        /// <summary>
        /// [イベント] 文字以外のキー入力
        /// </summary>
        private void Control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Control nextSelection = null;
            bool isArrowKey = true;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    nextSelection = this.controlMapUp[sender as Control];
                    break;
                case Keys.Down:
                    nextSelection = this.controlMapDown[sender as Control];
                    break;
                case Keys.Left:
                    nextSelection = this.controlMapLeft[sender as Control];
                    break;
                case Keys.Right:
                    nextSelection = this.controlMapRight[sender as Control];
                    break;
                default:
                    isArrowKey = false;
                    break;
            }

            if (isArrowKey)
            {
                if (nextSelection != null && nextSelection.Enabled)
                {
                    this.ActiveControl = nextSelection;
                }
                e.IsInputKey = true;
            }
        }
        #endregion // [イベント] 文字以外のキー入力

        #region [イベント] テキストボックスへのキー入力
        /// <summary>
        /// [イベント] テキストボックスへのキー入力
        /// </summary>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        #endregion // [イベント] テキストボックスへのキー入力

        #region [イベント] 設定値UPボタンクリック
        /// <summary>
        /// [イベント] 設定値UPボタンクリック
        /// </summary>
        private void UpButton_Click(object sender, EventArgs e)
        {
            if (sender == this.stepUpButton)
            {
                SetStepUpOrDown(UpDown.Up);
                return;
            }

            if ((DateTime.Now - this.stopUpDownTime).TotalMilliseconds < STOP_UPDOWN_INTERVAL)
            {
                return;
            }

            var target = (sender == this.minUpButton) ? this.minTextBox :
                        (sender == this.secUpButton) ? this.secTextBox : this.millisecTextBox;
            SetTimeUpOrDown(target, UpDown.Up);
        }
        #endregion // [イベント] 設定値UPボタンクリック

        #region [イベント] 設定値DOWNボタンクリック
        /// <summary>
        /// [イベント] 設定値DOWNボタンクリック
        /// </summary>
        private void DownButton_Click(object sender, EventArgs e)
        {
            if (sender == this.stepDownButton)
            {
                SetStepUpOrDown(UpDown.Down);
                return;
            }

            if ((DateTime.Now - this.stopUpDownTime).TotalMilliseconds < STOP_UPDOWN_INTERVAL)
            {
                return;
            }

            var target = (sender == this.minDownButton) ? this.minTextBox :
                        (sender == this.secDownButton) ? this.secTextBox : this.millisecTextBox;
            SetTimeUpOrDown(target, UpDown.Down);
        }
        #endregion // [イベント] 設定値DOWNボタンクリック

        #region [イベント] テキストボックスからフォーカスが離れた
        /// <summary>
        /// [イベント] テキストボックスからフォーカスが離れた
        /// </summary>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            var target = sender as TextBox;
            target.Text = target.Text.PadLeft(target.MaxLength, '0');
        }
        #endregion // [イベント] テキストボックスからフォーカスが離れた

        #region [イベント] ボタンがフォーカスされた
        /// <summary>
        /// [イベント] ボタンがフォーカスされた
        /// </summary>
        private void Button_Enter(object sender, EventArgs e)
        {
            OnEnterOrLeaveButton(sender as Button, ButtonState.Active);
        }
        #endregion // [イベント] ボタンがフォーカスされた

        #region [イベント] ボタンからフォーカスが外れた
        /// <summary>
        /// [イベント] ボタンからフォーカスが外れた
        /// </summary>
        private void Button_Leave(object sender, EventArgs e)
        {
            OnEnterOrLeaveButton(sender as Button, ButtonState.NotActive);
        }
        #endregion // [イベント] ボタンからフォーカスが外れた

        #region [イベント] 時刻設定値DOWNボタンがフォーカスされた
        /// <summary>
        /// [イベント] 時刻設定値DOWNボタンがフォーカスされた
        /// </summary>
        private void TimeDownButton_Enter(object sender, EventArgs e)
        {
            this.prevTimeDownButton = sender as Button;
            this.controlMapUp[this.startButton] = this.prevTimeDownButton;
        }
        #endregion // [イベント] 時刻設定値DOWNボタンがフォーカスされた

        #region [イベント] タイマー開始/修了ボタンクリック
        /// <summary>
        /// [イベント] タイマー開始/修了ボタンクリック
        /// </summary>
        private void startButton_Click(object sender, EventArgs e)
        {
            if (this.state == TimerState.Active)
            {
                StopTimer();
            }
            else
            {
                StartTimer();
            }
        }
        #endregion // [イベント] タイマー開始/修了ボタンクリック

        #region [イベント] タイマー設定リセットボタンクリック
        /// <summary>
        /// [イベント] タイマー設定リセットボタンクリック
        /// </summary>
        private void ResetTimerButton_Click(object sender, EventArgs e)
        {
            if (this.state == TimerState.Active)
            {
                UpdateLockState(this.isLocked ? LockState.UnLocked : LockState.Locked);
            }
            else
            {
                this.state = TimerState.Finished;
                UpdateTextBoxes(DEFAULT_TIME_SPAN, DEFAULT_STEP);
            }
        }
        #endregion // [イベント] タイマー設定リセットボタンクリック

        #region [イベント] メインタイマーの処理
        /// <summary>
        /// [イベント] メインタイマーの処理
        /// </summary>
        private void mainTimer_Tick(object sender, EventArgs e)
        {
            var currentTime = DateTime.Now;
            var timeLapse = currentTime - this.prevTickTime;
            if (timeLapse.Ticks < this.remainingTime.Ticks)
            {
                this.remainingTime -= timeLapse;
                this.prevTickTime = currentTime;

                UpdateTimeLabel(this.remainingTime);
            }
            else
            {
                this.remainingTime = new TimeSpan(0);
                StopTimer();
            }
        }
        #endregion // [イベント] メインタイマーの処理

        // privateメソッド

        #region OnEnterOrLeaveButton
        /// <summary>
        /// ボタンの状態が変わった時の処理を行います。
        /// </summary>
        /// <param name="button">対象のボタン</param>
        /// <param name="newState">新しい状態</param>
        private void OnEnterOrLeaveButton(Button button, ButtonState newState)
        {
            if (newState == ButtonState.Active)
            {
                this.inactiveButtonColor = button.BackColor;
                button.BackColor = BUTTON_COLOR_ACTIVE;
            }
            else
            {
                button.BackColor = this.inactiveButtonColor;
            }
        }
        #endregion // OnEnterOrLeaveButton

        #region SetButtonMaps
        /// <summary>
        /// 矢印キーによる選択項目移動先を設定します。
        /// </summary>
        private void SetButtonMaps()
        {
            this.controlMapUp = new Dictionary<Control, Control>();

            this.controlMapUp.Add(this.minTextBox, null);
            this.controlMapUp.Add(this.secTextBox, null);
            this.controlMapUp.Add(this.millisecTextBox, null);
            this.controlMapUp.Add(this.minUpButton, this.minTextBox);
            this.controlMapUp.Add(this.minDownButton, this.minUpButton);
            this.controlMapUp.Add(this.secUpButton, this.secTextBox);
            this.controlMapUp.Add(this.secDownButton, this.secUpButton);
            this.controlMapUp.Add(this.millisecUpButton, this.millisecTextBox);
            this.controlMapUp.Add(this.millisecDownButton, this.millisecUpButton);
            this.controlMapUp.Add(this.stepUpButton, null);
            this.controlMapUp.Add(this.stepDownButton, this.stepUpButton);
            this.controlMapUp.Add(this.startButton, this.prevTimeDownButton);
            this.controlMapUp.Add(this.resetTimerButton, this.stepDownButton);

            this.controlMapDown = new Dictionary<Control, Control>();
            this.controlMapDown.Add(this.minTextBox, this.minUpButton);
            this.controlMapDown.Add(this.secTextBox, this.secUpButton);
            this.controlMapDown.Add(this.millisecTextBox, this.millisecUpButton);
            this.controlMapDown.Add(this.minUpButton, this.minDownButton);
            this.controlMapDown.Add(this.minDownButton, this.startButton);
            this.controlMapDown.Add(this.secUpButton, this.secDownButton);
            this.controlMapDown.Add(this.secDownButton, this.startButton);
            this.controlMapDown.Add(this.millisecUpButton, this.millisecDownButton);
            this.controlMapDown.Add(this.millisecDownButton, this.startButton);
            this.controlMapDown.Add(this.stepUpButton, this.stepDownButton);
            this.controlMapDown.Add(this.stepDownButton, this.resetTimerButton);
            this.controlMapDown.Add(this.startButton, null);
            this.controlMapDown.Add(this.resetTimerButton, null);

            this.controlMapLeft = new Dictionary<Control, Control>();
            this.controlMapLeft.Add(this.minTextBox, null);
            this.controlMapLeft.Add(this.secTextBox, null);
            this.controlMapLeft.Add(this.millisecTextBox, null);
            this.controlMapLeft.Add(this.minUpButton, this.stepUpButton);
            this.controlMapLeft.Add(this.minDownButton, this.stepDownButton);
            this.controlMapLeft.Add(this.secUpButton, this.minUpButton);
            this.controlMapLeft.Add(this.secDownButton, this.minDownButton);
            this.controlMapLeft.Add(this.millisecUpButton, this.secUpButton);
            this.controlMapLeft.Add(this.millisecDownButton, this.secDownButton);
            this.controlMapLeft.Add(this.stepUpButton, this.millisecUpButton);
            this.controlMapLeft.Add(this.stepDownButton, this.millisecDownButton);
            this.controlMapLeft.Add(this.startButton, this.resetTimerButton);
            this.controlMapLeft.Add(this.resetTimerButton, this.startButton);

            this.controlMapRight = new Dictionary<Control, Control>();
            this.controlMapRight.Add(this.minTextBox, null);
            this.controlMapRight.Add(this.secTextBox, null);
            this.controlMapRight.Add(this.millisecTextBox, null);
            this.controlMapRight.Add(this.minUpButton, this.secUpButton);
            this.controlMapRight.Add(this.minDownButton, this.secDownButton);
            this.controlMapRight.Add(this.secUpButton, this.millisecUpButton);
            this.controlMapRight.Add(this.secDownButton, this.millisecDownButton);
            this.controlMapRight.Add(this.millisecUpButton, this.stepUpButton);
            this.controlMapRight.Add(this.millisecDownButton, this.stepDownButton);
            this.controlMapRight.Add(this.stepUpButton, this.minUpButton);
            this.controlMapRight.Add(this.stepDownButton, this.minDownButton);
            this.controlMapRight.Add(this.startButton, this.resetTimerButton);
            this.controlMapRight.Add(this.resetTimerButton, this.startButton);
        }
        #endregion // SetButtonMaps

        #region SetTimeUpOrDown
        /// <summary>
        /// 時間テキストボックスにUP/DOWN操作に応じた新しい値を設定します。
        /// </summary>
        /// <param name="target">対象の時間テキストボックス</param>
        /// <param name="upDown">UP/DOWN操作</param>
        private void SetTimeUpOrDown(TextBox target, UpDown upDown)
        {
            int currentNumber = int.Parse(target.Text);
            int maxNum = (target == this.minTextBox) ? MIN_MAX :
                        (target == this.secTextBox) ? SEC_MAX : MILLISEC_MAX;

            if (upDown == UpDown.Up)
            {
                int newNumber = (currentNumber == maxNum) ? 0
                                                            : Math.Min(currentNumber + this.step, maxNum);
                target.Text = newNumber.ToString().PadLeft(target.MaxLength, '0');

                if (newNumber == maxNum)
                {
                    this.stopUpDownTime = DateTime.Now;
                }
            }
            else
            {
                int newNumber = (currentNumber == 0) ? (maxNum + 1) - this.step
                                                        : Math.Max(currentNumber - this.step, 0);
                target.Text = newNumber.ToString().PadLeft(target.MaxLength, '0');

                if (newNumber == 0)
                {
                    this.stopUpDownTime = DateTime.Now;
                }
            }
        }
        #endregion // SetTimeUpOrDown

        #region SetStepUpOrDown
        /// <summary>
        /// ステップテキストボックスにUP/DOWN操作に応じた新しい値を設定します。
        /// </summary>
        /// <param name="upDown"></param>
        private void SetStepUpOrDown(UpDown upDown)
        {
            int newStep = this.step + ((upDown == UpDown.Up) ? +1 : -1);
            this.step = (0 < (newStep % STEP_MAX)) ? (newStep % STEP_MAX) : STEP_MAX;

            this.stepTextBox.Text = this.step.ToString().PadLeft(this.stepTextBox.MaxLength, '0');
        }
        #endregion // SetStepUpOrDown

        #region UpdateControls
        /// <summary>
        /// 現在のタイマーの状態に基づき、画面のコントロールを更新します。
        /// </summary>
        /// <param name="timerState">タイマー状態</param>
        private void UpdateControls(TimerState timerState)
        {
            if (timerState == TimerState.AlarmSignaling)
            {
                ShowAlarmForm();
                return;
            }

            switch (timerState)
            {
                case TimerState.Active:
                    this.startButton.Text = STOP_ICON;
                    UpdateTimeLabel(this.remainingTime);
                    break;
                case TimerState.Paused:
                    this.startButton.Text = START_ICON;
                    UpdateTextBoxes(this.remainingTime, this.step);
                    break;
                case TimerState.Finished:
                    this.startButton.Text = START_ICON;
                    UpdateTextBoxes(this.prevTimeSetting, this.step);
                    break;
            }

            bool isActive = (timerState == TimerState.Active);
            this.timeLabel.Visible = isActive;
            this.inputPanel.Visible = !isActive;

            this.minUpButton.Enabled = !isActive;
            this.minDownButton.Enabled = !isActive;
            this.secUpButton.Enabled = !isActive;
            this.secDownButton.Enabled = !isActive;
            this.millisecUpButton.Enabled = !isActive;
            this.millisecDownButton.Enabled = !isActive;
            this.stepUpButton.Enabled = !isActive;
            this.stepDownButton.Enabled = !isActive;

            // ロック制御
            UpdateLockState(LockState.UnLocked);
            this.resetTimerButton.Text = isActive ? LOCK_ICON : RESET_ICON;
        }
        #endregion // UpdateControls

        #region UpdateTextBoxes
        /// <summary>
        /// テキストボックスの時間、ステップ表示を更新します。
        /// </summary>
        /// <param name="time">表示する時間情報</param>
        /// <param name="step">ステップ</param>
        private void UpdateTextBoxes(TimeSpan time, int step)
        {
            this.minTextBox.Text = GetTotalMinutes(time).ToString().PadLeft(this.minTextBox.MaxLength, '0');
            this.secTextBox.Text = time.Seconds.ToString().PadLeft(this.secTextBox.MaxLength, '0');
            this.millisecTextBox.Text = time.Milliseconds.ToString().PadLeft(this.millisecTextBox.MaxLength, '0');

            this.stepTextBox.Text = this.step.ToString().PadLeft(this.stepTextBox.MaxLength, '0');
        }
        #endregion // UpdateTextBoxes

        #region UpdateTimeLabel
        /// <summary>
        /// ラベルの時間表示を更新します。
        /// </summary>
        /// <param name="time">表示する時間情報</param>
        private void UpdateTimeLabel(TimeSpan time)
        {
            this.timeLabel.Text = string.Format(TIME_FORMAT,
                                                GetTotalMinutes(time), time.Seconds, time.Milliseconds);
        }
        #endregion // UpdateTimeLabel

        #region GetTotalMinutes
        /// <summary>
        /// 指定した時間構造体の合計分数を取得します。
        /// </summary>
        /// <param name="time">時間構造体</param>
        /// <returns>合計分数</returns>
        private int GetTotalMinutes(TimeSpan time)
        {
            return (time.Days * 24 + time.Hours) * 60 + time.Minutes;
        }
        #endregion // GetTotalMinutes

        #region UpdateLockState
        /// <summary>
        /// ロック状態を更新します。
        /// </summary>
        /// <param name="newState">更新後の状態</param>
        private void UpdateLockState(LockState newState)
        {
            this.isLocked = (newState == LockState.Locked);
            this.resetTimerButton.Text = this.isLocked ? UNLOCK_ICON : LOCK_ICON;
            this.startButton.Enabled = !this.isLocked;
        }
        #endregion // UpdateLockState

        #region StartTimer
        /// <summary>
        /// タイマー開始時の処理を行います。
        /// </summary>
        private void StartTimer()
        {
            int minDisp = int.Parse(this.minTextBox.Text);
            int secDisp = int.Parse(this.secTextBox.Text);
            int millisecDisp = int.Parse(this.millisecTextBox.Text);
            if (minDisp == 0 && secDisp == 0 && millisecDisp == 0)
            {
                return;
            }

            var remainingTimeDisplayed = new TimeSpan(0, 0, minDisp, secDisp, millisecDisp);

            int prevMin = GetTotalMinutes(this.remainingTime);
            int prevSec = this.remainingTime.Seconds;
            int prevMillisec = this.remainingTime.Milliseconds;
            var prevRemainingTime = new TimeSpan(0, 0, prevMin, prevSec, prevMillisec);
            bool textChanged = (remainingTimeDisplayed != prevRemainingTime);

            if (this.state == TimerState.Finished || textChanged)
            {
                this.remainingTime = remainingTimeDisplayed;
                this.prevTimeSetting = this.remainingTime;
            }

            this.state = TimerState.Active;
            UpdateControls(this.state);

            this.prevTickTime = DateTime.Now;
            this.mainTimer.Start();
        }
        #endregion // StartTimer

        #region StopTimer
        /// <summary>
        /// タイマー停止時の処理を行います。
        /// </summary>
        private void StopTimer()
        {
            this.mainTimer.Stop();

            this.state = (this.remainingTime.Ticks == 0) ? TimerState.AlarmSignaling : TimerState.Paused;
            UpdateControls(this.state);
        }
        #endregion // StopTimer

        #region ShowAlarmForm
        /// <summary>
        /// アラーム画面を表示します。
        /// </summary>
        private void ShowAlarmForm()
        {
            if (this.WindowState != FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Normal;
            }

            using (var form = new AlarmForm(this))
            {
                // ちらつき防止のためにモーダル表示の裏で画面を更新
                form.UpdateParentHandler = new AlarmForm.UpdateParentDelegate(() =>
                {
                    this.state = TimerState.Finished;
                    UpdateControls(this.state);
                    Application.DoEvents();
                });

                form.ShowDialog(this);
            }
        }
        #endregion // ShowAlarmForm
    }
}