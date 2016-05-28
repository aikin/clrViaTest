using System;

namespace BanKai.Basic.Common
{
    internal class CustomizeEventAccessorDemoClass
    {
        private EventHandler m_event;

        public event EventHandler Event
        {
            add
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                m_event += value;
            }
            
            // ReSharper disable once DelegateSubtraction
            remove { m_event -= value; }
        }

        private void OnTiggered()
        {
            var handler = m_event;
            handler?.Invoke(this, EventArgs.Empty);
        }

        public void Tigger()
        {
            OnTiggered();
        }
    }
}