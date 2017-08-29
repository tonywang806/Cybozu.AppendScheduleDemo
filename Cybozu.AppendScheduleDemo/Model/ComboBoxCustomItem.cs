using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cybozu.AppendScheduleDemo.Model
{
    public class ComboBoxCustomItem
    {
        private string _value;
        private string _display;

        public string Value { get => _value; set => _value = value; }
        public string Display { get => _display; set => _display = value; }

        public ComboBoxCustomItem(string value,string display) {
            _value = value;
            _display = display;
        }
    }
}
