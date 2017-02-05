using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Models
{
    /// <summary>
    /// 1回の支払い／収入の金額と説明文を格納する構造体。
    /// </summary>
    public struct Payment
    {
        private int _amount;
        private string _comment;

        public int Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (_amount == value) return;
                _amount = value;
            }
        }

        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                if (_comment == value) return;
                _comment = value;
            }
        }

        public Payment(int m, string c = null)
        {
            if (m < 0)
            {
                throw new ArgumentOutOfRangeException("m");
            }

            _amount = m;
            _comment = c;
        }
    }
}
