using System;
using System.Collections.Generic;

namespace CurrieTechnologies.Blazor.SweetAlert2
{
    public sealed class SweetAlertPosition
    {
        private readonly string name;
        private static readonly Dictionary<string, SweetAlertPosition> Instance =
            new Dictionary<string, SweetAlertPosition>();


        public SweetAlertPosition(string name)
        {
            this.name = name;
            Instance[name] = this;
        }

        public static implicit operator SweetAlertPosition(string str)
        {
            if (Instance.TryGetValue(str, out SweetAlertPosition result))
            {
                return result;
            }
            else
            {
                throw new InvalidCastException();
            }
        }

        public override string ToString()
        {
            return name;
        }

        public static readonly SweetAlertPosition TOP = new SweetAlertPosition("top");
        public static readonly SweetAlertPosition TOP_START = new SweetAlertPosition("top-start");
        public static readonly SweetAlertPosition TOP_END = new SweetAlertPosition("top-end");
        public static readonly SweetAlertPosition TOP_LEFT = new SweetAlertPosition("top-left");
        public static readonly SweetAlertPosition TOP_RIGHT = new SweetAlertPosition("top-right");
        public static readonly SweetAlertPosition CENTER = new SweetAlertPosition("center");
        public static readonly SweetAlertPosition CENTER_START = new SweetAlertPosition("center-start");
        public static readonly SweetAlertPosition CENTER_END = new SweetAlertPosition("center-end");
        public static readonly SweetAlertPosition CENTER_LEFT = new SweetAlertPosition("center-left");
        public static readonly SweetAlertPosition CENTER_RIGHT = new SweetAlertPosition("center-right");
        public static readonly SweetAlertPosition BOTTOM = new SweetAlertPosition("bottom");
        public static readonly SweetAlertPosition BOTTOM_START = new SweetAlertPosition("bottom-start");
        public static readonly SweetAlertPosition BOTTOM_END = new SweetAlertPosition("bottom-end");
        public static readonly SweetAlertPosition BOTTOM_LEFT = new SweetAlertPosition("bottom-left");
        public static readonly SweetAlertPosition BOTTOM_RIGHT = new SweetAlertPosition("bottom-right");
    }


}
