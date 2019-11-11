using System;
using System.Collections.Generic;
using System.Text;

namespace Mediator
{
    class DropDownList
    {
        public List<string> Items { get; } = new List<string>();
    }

    class TextBox
    {
        public string Text { get; set; }
    }

    class CheckBox
    {
        private bool isChecked;
        public bool IsChecked 
        {
            get => isChecked;
            set
            {
                isChecked = value;
                OnCheckedChanged?.Invoke(this, isChecked);
            }
        }

        public event EventHandler<bool> OnCheckedChanged;
    }


    // 1. Encapsulate custom logic on UI.
    class UiMediator
    {
        private readonly DropDownList dropDownList;
        private readonly TextBox textBox;
        private readonly CheckBox checkBox;

        public UiMediator(DropDownList dropDownList, TextBox textBox, CheckBox checkBox)
        {
            this.dropDownList = dropDownList;
            this.textBox = textBox;
            this.checkBox = checkBox;
            this.checkBox.OnCheckedChanged += CheckBox_OnCheckedChanged;
        }

        private void CheckBox_OnCheckedChanged(object sender, bool isChecked)
        {
            if (isChecked)
            {
                dropDownList.Items.Clear();
                dropDownList.Items.AddRange(new[] { "1", "2", "3" });
                textBox.Text = "First";
            }
            else
            {
                dropDownList.Items.Clear();
                dropDownList.Items.AddRange(new[] { "4", "5", "6" });
                textBox.Text = "Second";
            }
        }
    }
}
