using System;
using System.Collections.Generic;

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


        public static implicit operator SweetAlertGrowDirection(string str)
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

        public static implicit operator SweetAlertGrowDirection(bool boolean)
        {
            if (boolean)
            {
                throw new InvalidCastException();
            }
            else
            {
                return False;
            }
        }

        public override string ToString()
        {
            return name;
        }

        public static readonly SweetAlertGrowDirection Row = new SweetAlertGrowDirection("row");
        public static readonly SweetAlertGrowDirection Column = new SweetAlertGrowDirection("column");
        public static readonly SweetAlertGrowDirection Fullscreen = new SweetAlertGrowDirection("fullscreen");
        public static readonly SweetAlertGrowDirection False = new SweetAlertGrowDirection("false");
    }
}
