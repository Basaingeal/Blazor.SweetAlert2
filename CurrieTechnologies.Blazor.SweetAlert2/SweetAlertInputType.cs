using System;
using System.Collections.Generic;

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

        public static readonly SweetAlertInputType Text = new SweetAlertInputType("text");
        public static readonly SweetAlertInputType Email = new SweetAlertInputType("email");
        public static readonly SweetAlertInputType Password = new SweetAlertInputType("password");
        public static readonly SweetAlertInputType Number = new SweetAlertInputType("number");
        public static readonly SweetAlertInputType Tel = new SweetAlertInputType("tel");
        public static readonly SweetAlertInputType Range = new SweetAlertInputType("range");
        public static readonly SweetAlertInputType Textarea = new SweetAlertInputType("textarea");
        public static readonly SweetAlertInputType Select = new SweetAlertInputType("select");
        public static readonly SweetAlertInputType Radio = new SweetAlertInputType("radio");
        public static readonly SweetAlertInputType Checkbox = new SweetAlertInputType("checkbox");
        internal static readonly SweetAlertInputType File = new SweetAlertInputType("file");
        public static readonly SweetAlertInputType Url = new SweetAlertInputType("url");
    }
}
