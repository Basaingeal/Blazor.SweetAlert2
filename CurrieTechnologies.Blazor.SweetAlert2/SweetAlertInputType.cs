using System;
using System.Collections.Generic;
using System.Text;

namespace CurrieTechnologies.Blazor.SweetAlert2
{
    public sealed class SweetAlertInputType
    {
        private readonly string name;
        private static readonly Dictionary<string, SweetAlertInputType> Instance =
            new Dictionary<string, SweetAlertInputType>();


        public SweetAlertInputType(string name)
        {
            this.name = name;
            Instance[name] = this;
        }

        public static implicit operator SweetAlertInputType(string str)
        {
            if (Instance.TryGetValue(str, out SweetAlertInputType result))
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

        public static readonly SweetAlertInputType TEXT = new SweetAlertInputType("text");
        public static readonly SweetAlertInputType EMAIL = new SweetAlertInputType("email");
        public static readonly SweetAlertInputType PASSWORD = new SweetAlertInputType("password");
        public static readonly SweetAlertInputType NUMBER = new SweetAlertInputType("number");
        public static readonly SweetAlertInputType TEL = new SweetAlertInputType("tel");
        public static readonly SweetAlertInputType RANGE = new SweetAlertInputType("range");
        public static readonly SweetAlertInputType TEXTAREA = new SweetAlertInputType("textarea");
        public static readonly SweetAlertInputType SELECT = new SweetAlertInputType("select");
        public static readonly SweetAlertInputType RADIO = new SweetAlertInputType("radio");
        public static readonly SweetAlertInputType CHECKBOX = new SweetAlertInputType("checkbox");
        internal static readonly SweetAlertInputType FILE = new SweetAlertInputType("file");
        public static readonly SweetAlertInputType URL = new SweetAlertInputType("url");
    }
}
