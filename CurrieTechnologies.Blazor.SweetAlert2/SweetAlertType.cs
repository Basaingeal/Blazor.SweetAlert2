using System;
using System.Collections.Generic;
using System.Text;

namespace CurrieTechnologies.Blazor.SweetAlert2
{
    public sealed class SweetAlertType
    {
        private readonly string name;
        private readonly int value;
        private static readonly Dictionary<string, SweetAlertType> instance = new Dictionary<string, SweetAlertType>();

        private SweetAlertType(int value, string name)
        {
            this.name = name;
            this.value = value;
            instance[name] = this;
        }

        public override string ToString()
        {
            return name;
        }

        public static explicit operator SweetAlertType(string str)
        {
            if (instance.TryGetValue(str, out SweetAlertType result))
            {
                return result;
            }
            else
            {
                throw new InvalidCastException();
            }
        }

        public static readonly SweetAlertType SUCCESS = new SweetAlertType(1, "success");
        public static readonly SweetAlertType ERROR = new SweetAlertType(2, "error");
        public static readonly SweetAlertType WARNING = new SweetAlertType(3, "warning");
        public static readonly SweetAlertType INFO = new SweetAlertType(4, "info");
        public static readonly SweetAlertType QUESTION = new SweetAlertType(5, "question");

        
    }
}
