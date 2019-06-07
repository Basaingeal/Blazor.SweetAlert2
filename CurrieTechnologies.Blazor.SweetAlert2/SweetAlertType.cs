using System;
using System.Collections.Generic;

namespace CurrieTechnologies.Blazor.SweetAlert2
{
    public sealed class SweetAlertType
    {
        private readonly string name;
        private static readonly Dictionary<string, SweetAlertType> Instance =
            new Dictionary<string, SweetAlertType>();

        private SweetAlertType(string name)
        {
            this.name = name;
            Instance[name] = this;
        }

        public static implicit operator SweetAlertType(string str)
        {
            if (Instance.TryGetValue(str, out SweetAlertType result))
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

        public static readonly SweetAlertType SUCCESS = new SweetAlertType("success");
        public static readonly SweetAlertType ERROR = new SweetAlertType("error");
        public static readonly SweetAlertType WARNING = new SweetAlertType("warning");
        public static readonly SweetAlertType INFO = new SweetAlertType("info");
        public static readonly SweetAlertType QUESTION = new SweetAlertType("question");
    }
}
