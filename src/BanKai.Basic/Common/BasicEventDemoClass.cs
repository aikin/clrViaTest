﻿using System;

namespace BanKai.Basic.Common
{
    internal class BasicEventDemoClass
    {
        public event EventHandler Event;

        public void TriggerEvent()
        {
            OnTriggerEvent();
        }

        private void OnTriggerEvent()
        {
            var handler = Event;
            handler?.Invoke(this, EventArgs.Empty);
        }
    }
}