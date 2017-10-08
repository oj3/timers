using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System. Windows.Forms;

namespace WorkTimer
{
    public class ControlMap
    {
        /// <summary>上下左右</summary>
        public enum Direction
        {
            /// <summary>上</summary>
            Up,
            /// <summary>下</summary>
            Down,
            /// <summary>左</summary>
            Left,
            /// <summary>右</summary>
            Right,
        }
    }

    public class MapElement
    {
        /// <summary>接続の向き</summary>
        public enum ConnectionType
        {
            /// <summary>一方向</summary>
            OneWay = 0,
            /// <summary>双方向</summary>
            Mutual = 1
        }

        protected Control element;

        /// <summary>上方向オブジェクト</summary>
        protected MapElement up;
        /// <summary>下方向オブジェクト</summary>
        protected MapElement down;
        /// <summary>左方向オブジェクト</summary>
        protected MapElement left;
        /// <summary>右方向オブジェクト</summary>
        protected MapElement right;

        /// <summary>上方向オブジェクト</summary>
        public MapElement Up { get { return this.up; } }
        /// <summary>下方向オブジェクト</summary>
        public MapElement Down { get { return this.down; } }
        /// <summary>右方向オブジェクト</summary>
        public MapElement Left { get { return this.left; } }
        /// <summary>左方向オブジェクト</summary>
        public MapElement Right { get { return this.right; } }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MapElement()
        {
            this.up = null;
            this.down = null;
            this.left = null;
            this.right = null;
        }

    }
}