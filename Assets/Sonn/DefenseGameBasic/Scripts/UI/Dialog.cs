using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Sonn.DefenseGameBasic
{
    public class Dialog : MonoBehaviour
    {
        public TextMeshProUGUI titleTxt, contentTxt;

        public virtual void Show(bool isShow)
        {
            gameObject.SetActive(isShow);
        }

        public virtual void UpdateDialog(string title, string content)
        {
            if (titleTxt)
            {
                titleTxt.text = title;
            }
            if (contentTxt)
            {
                contentTxt.text = content;
            }
        }

        public virtual void UpdateDialog()
        {

        }
        public virtual void CloseDialog()
        {
            gameObject.SetActive(false);
        }
    }

}
