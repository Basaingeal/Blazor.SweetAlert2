using System;
using System.Collections.Generic;
using System.Text;

namespace CurrieTechnologies.Blazor.SweetAlert2
{
    public sealed class SweetAlertGrowDirection
    {
        private readonly string name;
        private static readonly Dictionary<string, SweetAlertGrowDirection> Instance =
            new Dictionary<string, SweetAlertGrowDirection>();


        public SweetAlertGrowDirection(string name)
        {
            this.name = name;
            Instance[name] = this;
        }

        public static explicit operator SweetAlertGrowDirection(string str)
        {
            if (Instance.TryGetValue(str, out SweetAlertGrowDirection result))
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

        public static readonly SweetAlertGrowDirection ROW = new SweetAlertGrowDirection("row");
        public static readonly SweetAlertGrowDirection COLUMN = new SweetAlertGrowDirection("column");
        public static readonly SweetAlertGrowDirection FULLSCREEN = new SweetAlertGrowDirection("fullscreen");
        public static readonly SweetAlertGrowDirection FALSE = new SweetAlertGrowDirection("false");
    }
}
