﻿using System;

namespace BanKai.Basic.Common
{
    internal class CustomizeEventArgsDemoClass
    {
        public event EventHandler<GreetingEventArgs> Greeting;

        public void Greet(string name)
        {
            OnGreeting("Hello " + name);
        }

        private void OnGreeting(string content)
        {
            var handler = Greeting;
            handler?.Invoke(this, new GreetingEventArgs(content));
        }
    }

    internal class GreetingEventArgs : EventArgs
    {
        private readonly string m_greetingContent;

        public GreetingEventArgs(string greetingContent)
        {
            m_greetingContent = greetingContent;
        }

        public string GreetingContent
        {
            get { return m_greetingContent; }
        }
    }
}