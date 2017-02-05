using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Models
{
    /// <summary>
    /// 1つの費用項目に属する金額を格納する構造体。
    /// </summary>
    public struct Payments
    {
        /// <summary>
        /// 費用項目名
        /// </summary>
        private string _label;

        /// <summary>
        /// 費用項目に属する金額と各々の説明文
        /// </summary>
        private List<Payment> _payments;

        public string Label
        {
            get
            {
                return _label;
            }
            set
            {
                if (_label == value) return;
                _label = value;
            }
        }

        public List<Payment> Items
        {
            get
            {
                return _payments;
            }
            set
            {
                if (_payments == value) return;
                _payments = value;
            }
        }

        public int Total
        {
            get
            {
                if (_payments == null) return 0;

                int output = 0;
                foreach (Payment p in _payments)
                {
                    output += p.Amount;
                }

                return output;
            }
        }

        public Payments(string lab, List<Payment> p = null)
        {
            _label = lab;
            _payments = p;
        }
    }
}
